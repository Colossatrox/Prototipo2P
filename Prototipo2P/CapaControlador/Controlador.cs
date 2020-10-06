using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControlador
{
    public class Controlador
    {
        Sentencias sn = new Sentencias();
        public DataTable llenarTbl()
        {
            OdbcDataAdapter dt = sn.llenarTbl();
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        public string[] items(string tabla, string campo1,string estado)
        {
            string[] Items = sn.llenarCmb(tabla, campo1,estado);

            return Items;
        }
        public int codigoMax()
        {
            int codigo = sn.procInsertar();
            return codigo;
        }

        public bool agregar(int codigo, string nombre, double precio, int linea, int marca)
        {
            bool respuesta = sn.agregar(codigo,nombre,precio,linea,marca);
            return respuesta;
        }
        public bool eliminar(int codigo)
        {
            bool respuesta = sn.eliminar(codigo);
            return respuesta;
        }
    }
}
