using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ODS.Datos
{
    public class ConexionDB
    {
        private string connectionString = "Data Source=VICTOR-PC\\SQLVICTOR;Initial Catalog=test1;User ID=sa;Password=6433"; // Tu cadena de conexión
        private SqlConnection conexion; // Declarar la variable conexión a nivel de clase

        public ConexionDB() { }

        // Método para conectar a SQL Server
        public SqlConnection ConectarSQL()
        {
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

        //metodo para ejecutar consulta usuarios

        public DataTable EjecutarConsulta(string consulta)
        {
            try
            {
                using (SqlConnection conn = ConectarSQL())
                {
                    using (SqlCommand cmd = new SqlCommand(consulta, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al ejecutar la consulta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void EjecutarComandoConParametros(string query, SqlParameter[] parametros)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddRange(parametros);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }



        public void EjecutarComando(string comando)
        {
            try
            {
                using (SqlConnection conn = ConectarSQL())
                {
                    using (SqlCommand cmd = new SqlCommand(comando, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al ejecutar el comando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Método para abrir la conexión
        public void AbrirConexion()
        {
            try
            {
                if (conexion == null || string.IsNullOrEmpty(conexion.ConnectionString))
                {
                    ConectarSQL(); // Llamar al método ConectarSQL para inicializar la conexión
                }

                if (conexion?.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open(); // Abrir la conexión
                   // XtraMessageBox.Show("Conexión abierta exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("La conexión ya está abierta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show($"Error al abrir la conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Considera registrar el error en un log para futuras investigaciones
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error inesperado al abrir la conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Considera registrar el error en un log para futuras investigaciones
            }
        }

        // Método para cerrar la conexión
        public void CerrarConexion()
        {
            try
            {
                if (conexion?.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    conexion.Dispose(); // Liberar recursos
                    //XtraMessageBox.Show("Conexión cerrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   // XtraMessageBox.Show("La conexión ya está cerrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al cerrar la conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Considera registrar el error en un log para futuras investigaciones
            }
            finally
            {
                // Siempre intenta liberar recursos
                conexion?.Dispose();
            }
        }
    }
}