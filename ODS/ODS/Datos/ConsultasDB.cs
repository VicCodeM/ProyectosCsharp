using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ODS.Datos
{
    public class ConsultasDB
    {
        private ConexionDB conexionBD;

        public ConsultasDB()
        {
            conexionBD = new ConexionDB(); // Crear una instancia de ConexionBD
        }

        // Método para obtener el nombre de usuario por Id_Usuario
        public string ObtenerNombreUsuario(int idUsuario)
        {
            string nombreUsuario = string.Empty;

            // Consulta SQL para obtener el nombre de usuario
            string query = "SELECT Usuario FROM Login WHERE Id_Usuario = @IdUsuario";

            // Usar la conexión de ConexionDB
            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                // Crear un comando para ejecutar la consulta
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                try
                {
                    // Ejecutar la consulta y obtener el resultado
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        nombreUsuario = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    XtraMessageBox.Show($"Error al obtener el nombre de usuario: {ex.Message}", "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return nombreUsuario;
        }

        // Obtener departamento del usuario
        public string ObtenerDepartamentoPorUsuario(int idUsuario)
        {
            string departamento = string.Empty;

            // Usar la conexión de ConexionDB
            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                try
                {
                    // Consulta SQL para obtener el departamento asociado al usuario
                    string query = @"
                        SELECT d.Nombre_Departamento
                        FROM Departamentos d
                        INNER JOIN Empleados e ON d.Id_Departamento = e.Id_Departamento
                        INNER JOIN Login l ON e.Id_Empleado = l.Id_Empleado
                        WHERE l.Id_Usuario = @IdUsuario";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        // Ejecutar la consulta y obtener el resultado
                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            departamento = resultado.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception($"Error al obtener el departamento: {ex.Message}");
                }
            }

            return departamento;
        }

        // Obtener nombres y apellidos completos del usuario
        public string ObtenerNombreCompletoUsuario(int idUsuario)
        {
            string nombreCompleto = string.Empty;

            // Usar la conexión de ConexionDB
            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                try
                {
                    // Consulta SQL para obtener el nombre completo del usuario
                    string query = @"
                        SELECT CONCAT(e.Nombre_Empleado, ' ', e.Apellido_Paterno, ' ', e.Apellido_Materno) AS NombreCompleto
                        FROM Empleados e
                        INNER JOIN Login l ON e.Id_Empleado = l.Id_Empleado
                        WHERE l.Id_Usuario = @IdUsuario";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        // Ejecutar la consulta y obtener el resultado
                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            nombreCompleto = resultado.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    throw new Exception($"Error al obtener el nombre completo: {ex.Message}");
                }
            }

            return nombreCompleto;
        }

        // Método para obtener los tipos de falla de hardware
        public List<string> ObtenerTiposFallaHardware()
        {
            List<string> tiposFallaHardware = new List<string>();

            try
            {
                string query = "SELECT Descripcion FROM TiposFallaHardware";

                using (SqlConnection conexion = conexionBD.ConectarSQL())
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tiposFallaHardware.Add(reader["Descripcion"].ToString());
                            }
                            conexion.Close();
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los tipos de falla de hardware: {ex.Message}");
            }

            return tiposFallaHardware;
        }

    }
}
