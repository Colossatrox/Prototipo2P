using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo2PPrincipal
{
    public partial class MDIParent1 : Form
    {
        

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CapaVista.FrmInventario frmInv = new CapaVista.FrmInventario();
            frmInv.Show();
            frmInv.MdiParent = this;
        }
    }
}
