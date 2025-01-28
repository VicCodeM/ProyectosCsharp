using System;
using System.Data;
using System.Data.SqlClient;

namespace ODS.Datos
{
    public class ProcedimientosAlmacenadosDB
    {
        private readonly ConexionDB conexionBD;

        // Constructor
        public ProcedimientosAlmacenadosDB()
        {
            conexionBD = new ConexionDB();
        }

        /// <summary>
        /// Guarda una orden de servicio en la base de datos utilizando un procedimiento almacenado.
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <param name="idTipoFallaHardware">ID del tipo de falla de hardware</param>
        /// <param name="idTipoFallaSoftware">ID del tipo de falla de software</param>
        /// <param name="descripcionProblema">Descripción del problema</param>
        /// <param name="observaciones">Observaciones adicionales</param>
        /// <param name="estado">Estado de la orden</param>
        /// <param name="fechaAtendida">Fecha en la que se atendió</param>
        /// <param name="fechaCerrada">Fecha en la que se cerró</param>
        public void GuardarOrdenServicio(
            int idUsuario,
            int idTipoFallaHardware,
            int idTipoFallaSoftware,
            string descripcionProblema,
            string observaciones,
            string estado = "Pendiente",
            DateTime? fechaAtendida = null,
            DateTime? fechaCerrada = null)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = conexionBD.ConectarSQL();
               // conexion.Open();

                using (SqlCommand comando = new SqlCommand("sp_Pruebaservicio", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // Agregar los parámetros al comando
                    comando.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                    comando.Parameters.AddWithValue("@Id_TipoFallaHardware", idTipoFallaHardware);
                    comando.Parameters.AddWithValue("@Id_TipoFallaSoftware", idTipoFallaSoftware);
                    comando.Parameters.AddWithValue("@Descripcion_Problema", descripcionProblema);

                    // Si 'observaciones' es null o vacío, se pasa como DBNull.Value
                    comando.Parameters.AddWithValue("@Observaciones", string.IsNullOrWhiteSpace(observaciones) ? DBNull.Value : (object)observaciones);

                    comando.Parameters.AddWithValue("@Estado", estado);

                    // Validar fechas para evitar errores al insertar nulos
                    comando.Parameters.AddWithValue("@Fecha_Atendida", fechaAtendida ?? (object)DBNull.Value);
                    comando.Parameters.AddWithValue("@Fecha_Cerrada", fechaCerrada ?? (object)DBNull.Value);

                    // Ejecutar el procedimiento almacenado
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en GuardarOrdenServicio: {ex.Message}");
            }
            finally
            {
                // Asegurar el cierre de la conexión
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

    }
}
