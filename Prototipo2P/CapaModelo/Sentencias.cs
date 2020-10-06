using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class Sentencias
    {
        Conexion con = new Conexion();
        public OdbcDataAdapter llenarTbl()// metodo  que obtinene el contenio de una tabla
        {
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT P.CODIGO_PRODUCTO ,P.NOMBRE_PRODUCTO, P.PRECIO_PRODUCTO , M.NOMBRE_MARCA , L.NOMBRE_LINEA , P.ESTATUS_PRODUCTO " +
                "FROM PRODUCTO P, LINEA L, MARCA M WHERE P.CODIGO_LINEA=L.CODIGO_LINEA AND P.CODIGO_MARCA=M.CODIGO_MARCA ORDER BY P.CODIGO_PRODUCTO;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, con.conexion());
            return dataTable;
        }

        public string[] llenarCmb(string tabla, string campo1, string estado)
        {

            string[] Campos = new string[100];
            int i = 0;
            string sql = "SELECT " + campo1 + " FROM " + tabla + " where " + estado + "= 1 ;";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Campos[i] = reader.GetValue(0).ToString();
                    i++;


                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -" + tabla + "\n -" + campo1); }
            return Campos;
        }

        public int procInsertar()
        {
            int codigo = 0;
            string sql = "SELECT MAX( codigo_producto) FROM producto ;";

            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    codigo = reader.GetInt16(0);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -"); }
            codigo++;

            return codigo;
        }

        public bool agregar(int codigo,string nombre, double precio, int linea, int marca)
        {
            try
            {
                string insertarEncabezado = "INSERT INTO PRODUCTO VALUES ("+ codigo +",'"+nombre+"',"+precio+","+linea+","+marca+",1)";
                OdbcCommand comm = new OdbcCommand(insertarEncabezado, con.conexion());
                comm.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public bool eliminar(int codigo)
        {
            string sql = "SELECT CODIGO_PRODUCTO FROM producto WHERE CODIGO_PRODUCTO="+codigo+";";
            bool encontrado = false;
            try
            {
                OdbcCommand command = new OdbcCommand(sql, con.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    encontrado = true;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message.ToString() + " \nError en asignarCombo, revise los parametros \n -\n -"); }
            if (encontrado == true)
            {
                try
                {
                    string insertarEncabezado = "UPDATE PRODUCTO SET ESTATUS_PRODUCTO=0 WHERE CODIGO_PRODUCTO=" + codigo;
                    OdbcCommand comm = new OdbcCommand(insertarEncabezado, con.conexion());
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            

        }
    }
}
