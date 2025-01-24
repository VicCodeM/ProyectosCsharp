using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ODS.Datos
{
    public class ConexionDB
    {
        public ConexionDB() { }

        private string connectionString = "Data Source=VICTOR-HP\\SQLVICTOR;Initial Catalog=ods5;User ID=sa;Password=6433"; // Tu cadena de conexión

        // Método para conectar a SQL Server
        public SqlConnection ConectarSQL()
        {
            SqlConnection conexion = null; // Inicializar la conexión como null

            try
            {
                // Crear una nueva instancia de SqlConnection
                conexion = new SqlConnection(connectionString);
                conexion.Open(); // Abrir la conexión

                return conexion; // Devolver la conexión abierta
            }
            catch (Exception ex)
            {
                // Manejo de excepciones si ocurre un error al crear o abrir la conexión
                XtraMessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Cerrar la conexión si se abrió pero ocurrió un error después
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }

                throw; // Lanza la excepción para ser manejada por el código que llama a este método
            }
        }
    }
}