using DevExpress.XtraEditors;
using ODS.Datos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ODS.Modelo
{

    public class UsuarioConsultas
    {
        private ConexionDB conexionBD; // Instancia de ConexionDB

        public UsuarioConsultas()
        {
            conexionBD = new ConexionDB(); // Inicializar la instancia de ConexionDB
        }

        #region Métodos de Pruebas
        //métodos de prueba..
        //parametro corregidos
        public string ObtenerNombreEmpleadoPorOrden(int idOrden)
        {
            string query = @"
        SELECT e.Nombre_Empleado + ' ' + e.Apellido_Paterno + ' ' + e.Apellido_Materno AS NombreCompleto
            FROM OrdenServicio o
            INNER JOIN Login l ON o.Id_Usuario = l.Id_Usuario
            INNER JOIN Empleados e ON l.Id_Empleado = e.Id_Empleado
            WHERE o.Id_Orden = @Id_Orden
            ";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden }
            };

            object result = conexionBD.ExecuteScalar(query, parameters);

            return result != null ? result.ToString() : "Desconocido";
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
        //fin métodos de prueba 
        #endregion


        //consulta con parametro usuarios
        public DataTable EjecutarConsultaConParametros(string consulta, SqlParameter[] parametros)
        {
            SqlConnection conexion = null; // Declarar la conexión localmente
            try
            {
                conexion = conexionBD.ConectarSQL(); // Obtener la conexión abierta
                using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddRange(parametros); // Agregar parámetros
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); // Llenar el DataTable con los resultados
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar consulta con parámetros: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión si está abierta
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        //Validar usuario login
        public string ValidarUsuario(string usuario, string password)
        {
            try
            {
                string query = "SELECT Tipo_Usuario FROM Login WHERE Usuario = @Usuario AND Password = @Password";
                SqlParameter[] parametros =
                {
                    new SqlParameter("@Usuario", usuario),
                    new SqlParameter("@Password", password) // Se recomienda encriptar la contraseña
                };
                DataTable resultado = EjecutarConsultaConParametros(query, parametros);

                // Validar si hay resultados
                if (resultado.Rows.Count > 0 && resultado.Rows[0]["Tipo_Usuario"] != DBNull.Value)
                {
                    return resultado.Rows[0]["Tipo_Usuario"].ToString();
                }
                return string.Empty; // Retorna cadena vacía si no se encuentra el usuario
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar usuario: " + ex.Message);
            }
        }
        //Obtener datos del usuario
        public DataTable ObtenerDatosUsuario(string usuario)
        {
            try
            {
                string query = @"
            SELECT 
                l.Id_Usuario,  -- Asegurar que Id_Usuario está en la consulta
                e.Nombre_Empleado + ' ' + e.Apellido_Paterno + ' ' + e.Apellido_Materno AS NombreCompleto,
                e.Correo_Electronico AS Correo,
                d.Nombre_Departamento AS Departamento,
                l.Tipo_Usuario,
                l.Usuario
            FROM Login l
            INNER JOIN Empleados e ON l.Id_Empleado = e.Id_Empleado
            INNER JOIN Departamentos d ON e.Id_Departamento = d.Id_Departamento
            WHERE l.Usuario = @Usuario";

                SqlParameter[] parametros =
                {
            new SqlParameter("@Usuario", usuario)
        };

                return EjecutarConsultaConParametros(query, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos del usuario: " + ex.Message);
            }
        }



    }
}

