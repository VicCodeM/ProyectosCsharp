﻿using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ODS.Datos
{
    public class ConexionDB
    {

        private SqlConnection conexion; // Declarar la variable conexión a nivel de clase

        public ConexionDB()
        {
            // Configurar la cadena de conexión según el estado global
            ActualizarConnectionString();
        }

        // Variable estática para almacenar el estado de la conexión (true o false)
        public static bool conexionActivaGlobal = true; // true es para Servidor y false para Local

        // Cadena de conexión por defecto (se configura automáticamente según el estado global)
        private string connectionString = string.Empty;

        // Propiedad estática para configurar el estado global UNA SOLA VEZ
        public static void ConfigurarConexionGlobal(bool conexionActiva)
        {
            if (conexionActivaGlobal != conexionActiva) // Solo actualizamos si cambia el valor
            {
                conexionActivaGlobal = conexionActiva;
            }
        }
        //private string connectionString = "Data Source=VICTOR-PC\\SQLVICTOR;Initial Catalog=test3;User ID=sa;Password=6433"; // Tu cadena de conexión
        //  private string connectionString = ""; // Tu cadena de conexión


        // Método privado para actualizar la cadena de conexión
        private void ActualizarConnectionString()
        {
            if (conexionActivaGlobal == true)
            {
                // Conexión 1 true
                connectionString = "Data Source=10.10.1.144;Initial Catalog=Adm_JMAS;User ID=sa;Password=Mrrobot2025";
            }
            else
            {
                // Conexión 2 false
                connectionString = "Data Source=VICTOR-HP\\SQLVICTOR;Initial Catalog=test3;User ID=sa;Password=6433";
            }
        }

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


        // Método para ejecutar una consulta SQL y devolver un DataTable
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta: " + ex.Message);
            }

            return dataTable;
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


        //non query paramtros
        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Añadir parámetros si los hay
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        // Ejecutar el comando (INSERT, UPDATE, DELETE)
                        int rowsAffected = command.ExecuteNonQuery();

                        // Si necesitas saber cuántas filas fueron afectadas, puedes usar rowsAffected
                        Console.WriteLine($"{rowsAffected} filas afectadas.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta SQL: " + ex.Message);
            }
        }



        //ejectura consulta login y actualizar
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
        //ejcutar paramatros escalados
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros si existen
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar la consulta: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}