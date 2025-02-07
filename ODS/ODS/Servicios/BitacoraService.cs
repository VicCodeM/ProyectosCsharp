using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using ODS.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraEditors;
using ODS.Modelo;

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
            ConsultasDB consultasDB = new ConsultasDB();
        }
        public string DatosBitacora()
            {
                return @"
        SELECT 
    b.Id_Bitacora,
    b.Fecha_Accion,
    b.Id_Orden,
    o.Observaciones,
    b.Descripcion,
    b.Accion,
    e.Nombre_Empleado + ' ' + e.Apellido_Paterno + ' ' + e.Apellido_Materno AS Nombre_Completo,
    l.Usuario AS Usuario,
    e.Id_Empleado AS Id_Empleado  -- Cambié esto para que coincida con la tabla Empleados
FROM Bitacora b
LEFT JOIN OrdenServicio o ON b.Id_Orden = o.Id_Orden
LEFT JOIN Login l ON b.Id_Usuario = l.Id_Usuario
LEFT JOIN Empleados e ON l.Id_Empleado = e.Id_Empleado  -- Cambio aquí para obtener el Id_Empleado desde Login
ORDER BY b.Fecha_Accion DESC;
";
            }



            public void RegistrarEnBitacora(int idOrden, int idUsuarioLogueado, string accion, string descripcion)
            {
                // Obtener el Id_Usuario que creó la orden
                int idUsuarioQueCreoOrden = ObtenerIdUsuarioPorOrden(idOrden);

                // Obtener el Id_Empleado a partir del Id_Usuario que creó la orden
                int idEmpleadoQueCreoOrden = ObtenerIdEmpleadoPorUsuario(idUsuarioQueCreoOrden);

                string query = @"
    INSERT INTO Bitacora (Id_Orden, Id_Usuario, Id_Empleado, Accion, Fecha_Accion, Descripcion)
    VALUES (@Id_Orden, @Id_Usuario, @Id_Empleado, @Accion, @Fecha_Accion, @Descripcion);
    ";

                SqlParameter[] parameters = new SqlParameter[]
                {
        new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden },
        new SqlParameter("@Id_Usuario", SqlDbType.Int) { Value = idUsuarioLogueado },
        new SqlParameter("@Id_Empleado", SqlDbType.Int) { Value = idEmpleadoQueCreoOrden },
        new SqlParameter("@Accion", SqlDbType.VarChar, 255) { Value = accion },
        new SqlParameter("@Fecha_Accion", SqlDbType.DateTime) { Value = DateTime.Now },
        new SqlParameter("@Descripcion", SqlDbType.Text) { Value = descripcion }
                };

                conexionBD.ExecuteNonQuery(query, parameters);
            }





            // Método para obtener el Id_Empleado a partir del Id_Orden (quien hizo la orden)
            private int ObtenerIdEmpleadoPorOrden(int idOrden)
        {
            string query = "SELECT Id_Usuario FROM OrdenServicio WHERE Id_Orden = @Id_Orden";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden }
            };

            // Obtener el Id_Usuario desde la tabla OrdenServicio
            DataTable result = conexionBD.EjecutarConsultaConParametros(query, parameters);

            if (result != null && result.Rows.Count > 0)
            {
                // Ahora obtenemos el Id_Empleado relacionado con el Id_Usuario
                return ObtenerIdEmpleadoPorUsuario(Convert.ToInt32(result.Rows[0]["Id_Usuario"]));
            }

            return 0; // Si no se encuentra la orden, devolvemos 0 (o podrías manejar un error)
        }




        // Método para obtener solo el Id_Usuario de una orden
        private int ObtenerIdUsuarioPorOrden(int idOrden)
        {
            string query = "SELECT Id_Usuario FROM OrdenServicio WHERE Id_Orden = @Id_Orden";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Id_Orden", SqlDbType.Int) { Value = idOrden }
            };

            object result = conexionBD.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        // Método para obtener solo el Id_Empleado de un usuario
        private int ObtenerIdEmpleadoPorUsuario(int idUsuario)
        {
            string query = "SELECT Id_Empleado FROM Login WHERE Id_Usuario = @Id_Usuario";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@Id_Usuario", SqlDbType.Int) { Value = idUsuario }
            };

            object result = conexionBD.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

    }
}
