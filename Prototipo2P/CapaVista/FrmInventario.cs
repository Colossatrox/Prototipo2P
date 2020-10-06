using CapaControlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmInventario : Form
    {
        Controlador cn = new Controlador();
        int operacion = 0;
        public FrmInventario()
        {
            InitializeComponent();
            
        }
        public void actualizardatagriew()
        {
            DataTable dt = cn.llenarTbl();
            dgvProductos.DataSource = dt;

        }
        public void llenarCmb(string tabla, string campo1,string estado, ComboBox cmbAgregar)
        {
            string[] items = cn.items(tabla, campo1,estado);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        cmbAgregar.Items.Add(items[i]);
                    }
                }

            }
        }
        private void FrmInventario_Load(object sender, EventArgs e)
        {
            actualizardatagriew();
            cmbIdLinea.Items.Add("Seleccione...");
            cmbLinea.Items.Add("Seleccione...");
            cmbMarca.Items.Add("Seleccione...");
            cmbIdMarca.Items.Add("Seleccione...");
            llenarCmb("marca", "codigo_marca","estatus_marca", cmbIdMarca);
            llenarCmb("marca", "nombre_marca", "estatus_marca", cmbMarca);
            llenarCmb("linea", "codigo_linea", "estatus_linea", cmbIdLinea);
            llenarCmb("linea", "nombre_linea", "estatus_linea", cmbLinea);
            cmbLinea.SelectedIndex = 0;
            cmbMarca.SelectedIndex = 0;
        }

        private void cmbLinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIdLinea.SelectedIndex = cmbLinea.SelectedIndex;
        }

        private void cmbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIdMarca.SelectedIndex = cmbMarca.SelectedIndex;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codigo = cn.codigoMax();
            txtCodigo.Text = codigo.ToString();
            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            cmbLinea.Enabled = true;
            cmbMarca.Enabled = true;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnInsertar.Enabled = false;
            btnGuardar.Enabled = true;
            operacion = 1;
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            cmbLinea.Enabled = false;
            cmbMarca.Enabled = false;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            btnInsertar.Enabled = false;
            btnGuardar.Enabled = true;
            operacion = 2;
        }
        public void limpiar()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            cmbLinea.Enabled = false;
            cmbMarca.Enabled = false;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            btnInsertar.Enabled = true;
            btnGuardar.Enabled = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            cmbLinea.SelectedIndex = 0;
            cmbMarca.SelectedIndex = 0;
            operacion = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (operacion == 1)
            {
                if (txtNombre.Text == "")
                {
                    MessageBox.Show("FALTA ESCRIBIR EL NOMBRE");
                }
                else if (txtPrecio.Text == "")
                {
                    MessageBox.Show("FALTA ESCRIBIR EL PRECIO");
                }
                else if (cmbMarca.SelectedIndex == 0)
                {
                    MessageBox.Show("FALTA SELECCIONAR LA MARCA");
                }
                else if (cmbLinea.SelectedIndex == 0)
                {
                    MessageBox.Show("FALTA SELECCIONAR LA LINEA");
                }
                else
                {
                    try
                    {
                        double.Parse(txtPrecio.Text.ToString());
                        bool res = cn.agregar(int.Parse(txtCodigo.Text.ToString()), txtNombre.Text.ToString(), double.Parse(txtPrecio.Text.ToString()), int.Parse(cmbIdLinea.SelectedItem.ToString()), int.Parse(cmbIdMarca.SelectedItem.ToString()));
                        if (res == true)
                        {
                            MessageBox.Show("PRODUCTO AGREGADO CORRECTAMENTE");
                            limpiar();
                            actualizardatagriew();
                        }
                        else
                        {
                            MessageBox.Show("HUBO UN ERROR");
                        }

                    }catch(Exception ex)
                    {
                        MessageBox.Show("ERROR AL INGRESAR EL PRECIO");
                    }
                    
                }
            }
            else if (operacion == 2)
            {
                if (txtCodigo.Text == "")
                {
                    MessageBox.Show("FALTA ESCRIBIR EL CODIGO");
                }
                else
                {
                    bool res = cn.eliminar(int.Parse(txtCodigo.Text.ToString()));
                    if (res == true)
                    {
                        MessageBox.Show("PRODUCTO CAMBIADO DE ESTADO CORRECTAMENTE");
                        limpiar();
                        actualizardatagriew();
                    }
                    else
                    {
                        MessageBox.Show("CODIGO NO ENCONTRADO");
                    }
                }
            }
            
        }
    }
}
