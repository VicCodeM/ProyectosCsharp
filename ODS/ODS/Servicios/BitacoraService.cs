using DevExpress.XtraEditors;
using ODS.Datos;
using ODS.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ODS.Servicios
{
    public class BitacoraService
    {
        // Instancia de la clase ConexionDB
        ConexionDB conexionBD;
        UsuarioConsultas usuarioConsultas = new UsuarioConsultas();



        // Constructor para inicializar la instancia de ConexionDB
        public BitacoraService()
        {
            conexionBD = new ConexionDB();
        }


        //Registrar acciones en bitacora modo consulta
        public void RegistrarAccionEnBitacora(int idOrden, int idUsuarioAdmin, string accion, string descripcion, int idEmpleado)
        {
            try
            {
                // Depuración: Verificar valores de entrada
                Console.WriteLine($"idOrden: {idOrden}, idUsuarioAdmin: {idUsuarioAdmin}, idEmpleado: {idEmpleado}");

                if (idOrden <= 0 || idUsuarioAdmin <= 0)
                {
                    XtraMessageBox.Show("Error: idOrden o idUsuarioAdmin inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Consulta para obtener el Id_Empleado que generó la orden
                string queryEmpleado = @"
            SELECT Id_Usuario
            FROM OrdenServicio
            WHERE Id_Orden = @Id_Orden";

                SqlParameter[] paramEmpleado = new SqlParameter[]
                {
            new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden }
                };

                object result = conexionBD.ExecuteScalar(queryEmpleado, paramEmpleado);
                int idEmpleadoGeneroOrden = result != null ? Convert.ToInt32(result) : 0;

                // Depuración: Verificar el idEmpleado obtenido
                Console.WriteLine($"idEmpleado obtenido: {idEmpleadoGeneroOrden}");

                if (idEmpleadoGeneroOrden == 0)
                {
                    XtraMessageBox.Show("No se encontró el empleado que generó la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insertar en la bitácora con el Id_Empleado correcto
                string queryInsert = @"
            INSERT INTO Bitacora (Id_Orden, Id_Usuario, Accion, Fecha_Accion, Descripcion, Id_Empleado)
            VALUES (@Id_Orden, @Id_Usuario, @Accion, GETDATE(), @Descripcion, @Id_Empleado)";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden },
            new SqlParameter("@Id_Usuario", SqlDbType.Int) { Value = idUsuarioAdmin }, // Admin que actualizó
            new SqlParameter("@Accion", SqlDbType.VarChar) { Value = accion },
            new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = descripcion },
            new SqlParameter("@Id_Empleado", SqlDbType.Int) { Value = idEmpleadoGeneroOrden } // Empleado que generó la orden
                };

                conexionBD.ExecuteNonQuery(queryInsert, parameters);

                // Depuración: Confirmar inserción exitosa
                Console.WriteLine("Acción registrada correctamente en la bitácora.");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al registrar en la bitácora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //obtener datos de la bse datos de la tabla bitacora
        public DataTable ObtenerDatosBitacora()
        {
            try
            {
                string query = @"
                    SELECT 
                        b.Id_Bitacora AS Id,
                        b.Id_Orden,
                        u.Usuario AS Administrador,
                        ISNULL(emp.Nombre_Empleado + ' ' + emp.Apellido_Paterno + ' ' + emp.Apellido_Materno, 'Sin Empleado') AS Nombre_Empleado,
                        b.Accion,
                        CAST(o.Fecha_Creacion AS DATE) AS Fecha_Orden,  -- Fecha de creación de la orden
                        LEFT(RIGHT(CONVERT(VARCHAR, o.Fecha_Creacion, 100), 7), 5) + ' ' + RIGHT(CONVERT(VARCHAR, o.Fecha_Creacion, 100), 2) AS Hora_Orden,  -- Hora de creación de la orden
                        CAST(b.Fecha_Accion AS DATE) AS Fecha_Accion,  -- Fecha de la acción
                        LEFT(RIGHT(CONVERT(VARCHAR, b.Fecha_Accion, 100), 7), 5) + ' ' + RIGHT(CONVERT(VARCHAR, b.Fecha_Accion, 100), 2) AS Hora_Accion,  -- Hora de la acción
                        b.Descripcion
                    FROM Bitacora b
                    INNER JOIN Login u ON b.Id_Usuario = u.Id_Usuario  -- Admin que realizó la acción
                    LEFT JOIN Login e ON b.Id_Empleado = e.Id_Usuario  -- Usuario asociado a la acción
                    LEFT JOIN Empleados emp ON e.Id_Empleado = emp.Id_Empleado  -- Empleado asociado al usuario
                    LEFT JOIN OrdenServicio o ON b.Id_Orden = o.Id_Orden  -- Orden asociada a la bitácora
                    ORDER BY b.Fecha_Accion DESC;";

                return conexionBD.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener datos de la bitácora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

