using ODS.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODS.Modelo
{
   
    public class UsuarioConsultas
    {
        private ConexionDB conexionBD; // Instancia de ConexionDB

        public UsuarioConsultas()
        {
            conexionBD = new ConexionDB(); // Inicializar la instancia de ConexionDB
        }
        public static string NombreCompleto { get; set; }
        public static string Correo { get; set; }
        public static string Departamento { get; set; }
        public static string TipoUsuario { get; set; }
        public static string NombreUsuario { get; set; }




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

