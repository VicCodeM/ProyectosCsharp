using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
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
                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tiposFallaHardware.Add(reader["Descripcion"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los tipos de falla de hardware: {ex.Message}");
            }

            return tiposFallaHardware;
        }


        // Método para obtener los tipos de falla de software
        public List<string> ObtenerTiposFallaSoftware()
        {
            List<string> tiposFallaSoftware = new List<string>();

            try
            {
                string query = "SELECT Descripcion FROM TiposFallaSoftware";

                using (SqlConnection conexion = conexionBD.ConectarSQL())
                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tiposFallaSoftware.Add(reader["Descripcion"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los tipos de falla de software: {ex.Message}");
            }

            return tiposFallaSoftware;
        }

        // Método para obtener las órdenes de servicio por Id_Usuario   
        public DataTable ObtenerOrdenesPorUsuario(int idUsuario)
        {
            DataTable tablaOrdenes = new DataTable();

            try
            {
                // Configura tu conexión a la base de datos
                using (SqlConnection conexion = conexionBD.ConectarSQL())
                {
                    // Consulta SQL para obtener las órdenes del usuario
                    string query = @"
                SELECT 
                    os.Id_Orden AS Id,
                    os.Fecha_Creacion AS Fecha_Registro,
                    os.Fecha_Atendida AS Fecha_Atencion,
                    os.Fecha_Cerrada AS Fecha_Cierre,
                    l.Usuario AS Usuario,
                    d.Nombre_Departamento AS Departamento,
                    th.Descripcion AS Hardware,
                    ts.Descripcion AS Software,
                    os.Descripcion_Problema AS Descripcion,
                    os.Observaciones AS Observaciones,
                    os.Estado
                FROM 
                    OrdenServicio os
                LEFT JOIN 
                    Login l ON os.Id_Usuario = l.Id_Usuario
                LEFT JOIN 
                    Empleados e ON l.Id_Empleado = e.Id_Empleado
                LEFT JOIN 
                    Departamentos d ON e.Id_Departamento = d.Id_Departamento
                LEFT JOIN 
                    TiposFallaHardware th ON os.Id_TipoFallaHardware = th.Id_TipoFallaHardware
                LEFT JOIN 
                    TiposFallaSoftware ts ON os.Id_TipoFallaSoftware = ts.Id_TipoFallaSoftware
                WHERE 
                    os.Id_Usuario = @IdUsuario
                ORDER BY 
                    os.Fecha_Creacion DESC;
            ";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        // Agregar parámetro para evitar inyección SQL
                        comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario; // Cambié VarChar a Int

                        // Llena la tabla con los resultados
                        using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                        {
                            adapter.Fill(tablaOrdenes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                XtraMessageBox.Show(
                    $"Error al obtener las órdenes: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return tablaOrdenes;
        }



        //incertar ordenees usuarios
        // Método para cargar fallas de hardware
        //public DataTable ObtenerTiposFallaHardware()
        //{
        //    string query = "SELECT Id_TipoFallaHardware, Descripcion FROM TiposFallaHardware";

        //    using (SqlConnection conn = conexionBD.ConectarSQL())
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}

        //// Método para cargar fallas de software
        //public DataTable ObtenerTiposFallaSoftware()
        //{
        //    string query = "SELECT Id_TipoFallaSoftware, Descripcion FROM TiposFallaSoftware";

        //    using (SqlConnection conn = conexionBD.ConectarSQL())
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter(query, conn);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}

        // Método para validar si un usuario existe
        public bool UsuarioExiste(int idUsuario)
        {
            string query = "SELECT COUNT(1) FROM Login WHERE Id_Usuario = @Id_Usuario";

            using (SqlConnection conn = conexionBD.ConectarSQL())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Método para insertar una orden de servicio
        public void InsertarOrdenServicio(int idUsuario, int? idFallaHardware, int? idFallaSoftware, string descripcionProblema, string estado)
        {
            string query = @"
        INSERT INTO OrdenServicio 
        (Id_Usuario, Id_TipoFallaHardware, Id_TipoFallaSoftware, Descripcion_Problema, Estado, Fecha_Creacion) 
        VALUES (@Id_Usuario, @Id_TipoFallaHardware, @Id_TipoFallaSoftware, @Descripcion_Problema, @Estado, @Fecha_Creacion)";

            using (SqlConnection conn = conexionBD.ConectarSQL())
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                cmd.Parameters.AddWithValue("@Id_TipoFallaHardware", idFallaHardware.HasValue ? (object)idFallaHardware.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_TipoFallaSoftware", idFallaSoftware.HasValue ? (object)idFallaSoftware.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@Descripcion_Problema", descripcionProblema);
                cmd.Parameters.AddWithValue("@Estado", estado);

                // Agregar la fecha actual con la hora
                cmd.Parameters.AddWithValue("@Fecha_Creacion", DateTime.Now);  // Fecha y hora actuales

                cmd.ExecuteNonQuery();
            }
        }

    }
}
