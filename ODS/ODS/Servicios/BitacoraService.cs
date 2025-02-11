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
        }

        public void RegistrarAccionEnBitacora(int idOrden, int idUsuarioAdmin, string accion, string descripcion)
        {
            idUsuarioAdmin = UsuarioLogueado.IdUsuario;
            try
            {
                // Depuración: Verificar valores de entrada
              //  MessageBox.Show($"idOrden: {idOrden}, idUsuarioAdmin: {idUsuarioAdmin}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (idOrden <= 0 || idUsuarioAdmin <= 0)
                {
                    MessageBox.Show("Error: idOrden o idUsuarioAdmin inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int idEmpleado = result != null ? Convert.ToInt32(result) : 0;

                // Depuración: Verificar el idEmpleado obtenido
              //  MessageBox.Show($"idEmpleado obtenido: {idEmpleado}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (idEmpleado == 0)
                {
                    //MessageBox.Show("No se encontró el empleado que generó la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            new SqlParameter("@Id_Empleado", SqlDbType.Int) { Value = idEmpleado } // Empleado que generó la orden
                };

                conexionBD.ExecuteNonQuery(queryInsert, parameters);

               // MessageBox.Show("Acción registrada correctamente en la bitácora.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar en la bitácora: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public DataTable ObtenerDatosBitacora()
        {
            try
            {
                string query = @"
            SELECT 
                b.Id_Bitacora AS Id,
                b.Id_Orden,
                u.Usuario AS Administrador,
                b.Accion,
                CAST(b.Fecha_Accion AS DATE) AS Fecha,  -- Solo la fecha
                FORMAT(b.Fecha_Accion, 'hh:mm tt') AS Hora,  -- Hora en formato 12h con AM/PM
                b.Descripcion
            FROM Bitacora b
            INNER JOIN Login u ON b.Id_Usuario = u.Id_Usuario  -- Admin que realizó la acción
            INNER JOIN Login e ON b.Id_Empleado = e.Id_Usuario  -- Empleado que generó la orden
            ORDER BY b.Fecha_Accion DESC";

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

