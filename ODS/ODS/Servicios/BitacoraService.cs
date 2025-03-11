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
        public void RegistrarAccionEnBitacora(int idOrden, int idUsuarioAdmin, string accion, string descripcion)
        {
            try
            {
                // 1. Obtener el Id_Empleado del administrador que realiza la acción
                string queryEmpleadoAdmin = @"
            SELECT e.Id_Empleado 
            FROM Login l 
            INNER JOIN Empleados e ON l.Id_Empleado = e.Id_Empleado 
            WHERE l.Id_Usuario = @Id_UsuarioAdmin";

                SqlParameter paramAdmin = new SqlParameter("@Id_UsuarioAdmin", SqlDbType.Int) { Value = idUsuarioAdmin };
                int idEmpleadoAdmin = Convert.ToInt32(conexionBD.ExecuteScalar(queryEmpleadoAdmin, new[] { paramAdmin }));

                // 2. Obtener el Id_Empleado que creó la orden original
                string queryEmpleadoOriginal = @"
            SELECT l.Id_Empleado 
            FROM OrdenServicio os 
            INNER JOIN Login l ON os.Id_Usuario = l.Id_Usuario 
            WHERE os.Id_Orden = @Id_Orden";

                SqlParameter paramOrden = new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden };
                int idEmpleadoOriginal = Convert.ToInt32(conexionBD.ExecuteScalar(queryEmpleadoOriginal, new[] { paramOrden }));

                // 3. Insertar en la bitácora
                string queryInsert = @"
            INSERT INTO Bitacora (
                Id_Orden, 
                Id_Usuario, 
                Accion, 
                Fecha_Accion, 
                Descripcion, 
                Id_Empleado) 
            VALUES (
                @Id_Orden, 
                @Id_Usuario, 
                @Accion, 
                GETDATE(), 
                @Descripcion, 
                @Id_Empleado_Creador)";

                SqlParameter[] parameters = {
            new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden },
            new SqlParameter("@Id_Usuario", SqlDbType.Int) { Value = idUsuarioAdmin }, // Usuario admin
            new SqlParameter("@Accion", SqlDbType.VarChar) { Value = accion },
            new SqlParameter("@Descripcion", SqlDbType.Text) { Value = descripcion },
            new SqlParameter("@Id_Empleado_Creador", SqlDbType.Int) { Value = idEmpleadoOriginal } // Empleado creador
        };

                conexionBD.ExecuteNonQuery(queryInsert, parameters);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error al registrar en bitácora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // Obtener datos de la base de datos de la tabla bitácora
        public DataTable ObtenerDatosBitacora()
        {
            try
            {
                string query = @"
SELECT 
    b.Id_Bitacora,
    b.Id_Orden,
    -- Formatear FechaCreacionOrden correctamente
    CASE 
        WHEN os.Fecha_Creacion IS NOT NULL THEN CONVERT(VARCHAR(20), os.Fecha_Creacion, 120)
        ELSE 'No existe'
    END AS FechaCreacionOrden,
    -- Formatear FechaAccionAdmin y HoraAccionAdmin correctamente
    CONVERT(VARCHAR(10), b.Fecha_Accion, 120) AS FechaAccionAdmin, -- YYYY-MM-DD
    b.Accion,
    -- Concatenar nombres con manejo de NULLs
    ISNULL(
        creator.Nombre_Empleado + ' ' + creator.Apellido_Paterno + ' ' + creator.Apellido_Materno,
        'No disponible'
    ) AS NombreCreador,
    -- Formato HH:mm para HoraAccionAdmin
    RIGHT('0' + CONVERT(VARCHAR(2), DATEPART(HOUR, b.Fecha_Accion)), 2) + ':' + 
    RIGHT('0' + CONVERT(VARCHAR(2), DATEPART(MINUTE, b.Fecha_Accion)), 2) AS HoraAccionAdmin,
    b.Descripcion,
    -- Nombre del administrador con manejo de NULLs
    ISNULL(
        admin.Nombre_Empleado + ' ' + admin.Apellido_Paterno + ' ' + admin.Apellido_Materno,
        'No disponible'
    ) AS NombreAdmin
FROM 
    Bitacora AS b
    INNER JOIN Login AS l ON b.Id_Usuario = l.Id_Usuario
    INNER JOIN Empleados AS admin ON l.Id_Empleado = admin.Id_Empleado
    LEFT JOIN Empleados AS creator ON b.Id_Empleado = creator.Id_Empleado
    LEFT JOIN OrdenServicio AS os ON b.Id_Orden = os.Id_Orden
ORDER BY 
    b.Fecha_Accion DESC;";

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

