using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_DataGridView
{
    /// <summary>
    /// CRUD = CREATE, READ, UPDATE, DELETE
    /// </summary>
    class Conexion
    {
        SqlConnection conexion; // atributo para realizar la conn a la base de datos
        SqlCommand terminal; // atributo para realizar los querys
        SqlDataReader lector; // leer la data que viene de la terminal
        DataTable tabla; // esta tabla va a almacenar los registros que traiga la consulta
        SqlDataAdapter adaptador; // adaptador para adaptar la data que viene del lector al DataTable
        

        public Conexion(string conexionString)
        {
            
            try
            {
                conexion = new SqlConnection(conexionString);
                conexion.Open();
                estatus("La conexion fue exitosa");
            }
            catch (Exception e)
            {
                estatus(e.ToString());
            }
        }

        public DataTable obtenerTablaParaDGV(string nombreTabla)
        {
            tabla = new DataTable();
            try
            {
                // hacer una consulta a la conexion
                terminal = new SqlCommand("SELECT * FROM "+nombreTabla+";", conexion);
                terminal.CommandType = CommandType.Text;
                adaptador = new SqlDataAdapter(terminal);
                adaptador.Fill(tabla);
               
            }
            catch (Exception e)
            {
                estatus(e.ToString());
            }
            return tabla;
        }

        private void leerUnSoloRegistro(IDataRecord registros)
        {
            // cada registro se devuelve como un objeto de tipo IDataRecord
            Console.WriteLine(String.Format("cedula: {0} nombre: {1} email: {2}", registros[0], registros[1], registros[2]));
        }

        private void estatus(string texto)
        {
            MessageBox.Show(texto);
        }
    }
}
