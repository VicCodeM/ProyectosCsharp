using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static ODS.Modelo.OrdenService;

namespace ODS.Datos
{
    public class ConsultasDB
    {
        private ConexionDB conexionBD;

        public ConsultasDB()
        {
            conexionBD = new ConexionDB(); // Crear una instancia de ConexionBD
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

        //Mostrar todas las ordenes
        public DataTable ObtenerTodasLasOrdenes()
        {
            DataTable tablaOrdenes = new DataTable();

            try
            {
                // Configura tu conexión a la base de datos
                using (SqlConnection conexion = conexionBD.ConectarSQL())
                {
                    // Consulta SQL para obtener todas las órdenes
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
                ORDER BY 
                    os.Fecha_Creacion DESC;
            ";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
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

        // Método para obtener los datos de la orden seleccionada
        public DataRow CargarDatosOrdenSeleccionada(int idOrden)
        {
            DataTable tablaOrden = new DataTable();

            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                string consulta = @"
            SELECT 
                os.Id_Orden,
                os.Fecha_Creacion,
                os.Fecha_Atendida,
                os.Fecha_Cerrada,
                os.Id_Usuario,
                os.Id_TipoFallaHardware,
                os.Id_TipoFallaSoftware,
                os.Descripcion_Problema,
                os.Observaciones,
                os.Estado
            FROM 
                OrdenServicio os
            WHERE 
                os.Id_Orden = @IdOrden";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdOrden", idOrden);

                // Ejecutar el comando y llenar el DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(tablaOrden);
            }

            // Verificar si se ha obtenido alguna fila
            if (tablaOrden.Rows.Count > 0)
            {
                return tablaOrden.Rows[0]; // Retornar la primera fila
            }

            return null; // Si no se encontró la orden
        }

        // Método para cargar las listas desplegables
        public void CargarListasDesplegables(out DataTable tablaUsuarios, out DataTable tablaHardware, out DataTable tablaSoftware)
        {
            tablaUsuarios = new DataTable();
            tablaHardware = new DataTable();
            tablaSoftware = new DataTable();

            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                // Llenar DataTable para usuarios
                string consultaUsuarios = "SELECT Id_Usuario, Usuario FROM Login";
                SqlDataAdapter adaptadorUsuarios = new SqlDataAdapter(consultaUsuarios, conexion);
                adaptadorUsuarios.Fill(tablaUsuarios);

                // Llenar DataTable para Tipos de Falla Hardware
                string consultaHardware = "SELECT Id_TipoFallaHardware, Descripcion FROM TiposFallaHardware";
                SqlDataAdapter adaptadorHardware = new SqlDataAdapter(consultaHardware, conexion);
                adaptadorHardware.Fill(tablaHardware);

                // Llenar DataTable para Tipos de Falla Software
                string consultaSoftware = "SELECT Id_TipoFallaSoftware, Descripcion FROM TiposFallaSoftware";
                SqlDataAdapter adaptadorSoftware = new SqlDataAdapter(consultaSoftware, conexion);
                adaptadorSoftware.Fill(tablaSoftware);
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


        // Método para actualizar una orden de servicio
        public void ActualizarOrden(int idOrden, DateTime? fechaAtendida, DateTime? fechaCerrada,
            int idUsuario, int? idFallaHardware, int? idFallaSoftware, string descripcion,
             string observaciones, string estado)
        {
            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                string consultaActualizar = @"
                UPDATE OrdenServicio
                SET
                    Fecha_Atendida = @FechaAtendida,
                    Fecha_Cerrada = @FechaCerrada,
                    Id_Usuario = @IdUsuario,
                    Id_TipoFallaHardware = @IdFallaHardware,
                    Id_TipoFallaSoftware = @IdFallaSoftware,
                    Descripcion_Problema = @Descripcion,
                    Observaciones = @Observaciones,
                    Estado = @Estado
                WHERE
                    Id_Orden = @IdOrden";

                SqlCommand comando = new SqlCommand(consultaActualizar, conexion);

                // Agregar los parámetros
                comando.Parameters.AddWithValue("@IdOrden", idOrden);
                comando.Parameters.AddWithValue("@FechaAtendida", fechaAtendida ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@FechaCerrada", fechaCerrada ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                comando.Parameters.AddWithValue("@IdFallaHardware", idFallaHardware ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@IdFallaSoftware", idFallaSoftware ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                comando.Parameters.AddWithValue("@Observaciones", observaciones);
                comando.Parameters.AddWithValue("@Estado", estado);

                // Ejecutar el comando
                comando.ExecuteNonQuery();
            }
        }


        //Metodo de Eliniar orden
        public bool EliminarOrden(int idOrden)
        {
            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                SqlTransaction transaction = conexion.BeginTransaction();
                try
                {
                    // Actualizar Bitacora para poner NULL en Id_Orden antes de eliminar la orden
                    string queryActualizarBitacora = "UPDATE Bitacora SET Id_Orden = NULL WHERE Id_Orden = @IdOrden";
                    SqlCommand cmdActualizarBitacora = new SqlCommand(queryActualizarBitacora, conexion, transaction);
                    cmdActualizarBitacora.Parameters.AddWithValue("@IdOrden", idOrden);
                    cmdActualizarBitacora.ExecuteNonQuery();

                    // Ahora eliminar la orden en OrdenServicio
                    string queryEliminarOrden = "DELETE FROM OrdenServicio WHERE Id_Orden = @IdOrden";
                    SqlCommand cmdEliminarOrden = new SqlCommand(queryEliminarOrden, conexion, transaction);
                    cmdEliminarOrden.Parameters.AddWithValue("@IdOrden", idOrden);
                    int filasAfectadas = cmdEliminarOrden.ExecuteNonQuery();

                    transaction.Commit();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error al eliminar la orden: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Método para obtener los detalles de una orden por su ID
        public Orden ObtenerOrdenPorId(int idOrden)
        {
            Orden orden = null;

            using (SqlConnection conexion = conexionBD.ConectarSQL())
            {
                string query = @"
                SELECT
                    Fecha_Atendida,
                    Fecha_Cerrada,
                    Id_TipoFallaHardware,
                    Id_TipoFallaSoftware,
                    Descripcion_Problema,
                    Observaciones,
                    Estado
                FROM OrdenServicio
                WHERE Id_Orden = @IdOrden";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdOrden", idOrden);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            orden = new Orden
                            {
                                FechaAtendida = reader.IsDBNull(reader.GetOrdinal("Fecha_Atendida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha_Atendida")),
                                FechaCerrada = reader.IsDBNull(reader.GetOrdinal("Fecha_Cerrada")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha_Cerrada")),
                                IdFallaHardware = reader.IsDBNull(reader.GetOrdinal("Id_TipoFallaHardware")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Id_TipoFallaHardware")),
                                IdFallaSoftware = reader.IsDBNull(reader.GetOrdinal("Id_TipoFallaSoftware")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Id_TipoFallaSoftware")),
                                Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion_Problema")) ? null : reader.GetString(reader.GetOrdinal("Descripcion_Problema")),
                                Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? null : reader.GetString(reader.GetOrdinal("Observaciones")),
                                Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? null : reader.GetString(reader.GetOrdinal("Estado"))
                            };
                        }
                    }
                }
            }

            return orden;
        }



    }
}
