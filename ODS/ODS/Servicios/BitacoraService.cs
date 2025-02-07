using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using ODS.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODS.Servicios
{
    public class BitacoraService
    {
        ConexionDB conexionBD;
        public BitacoraService() 
        {
            conexionBD = new ConexionDB();
        }


        public string DatosBitacora()
        {
            return @"
    SELECT 
        B.Id_Bitacora,
        B.Fecha_Accion,
        L.Usuario AS NombreUsuario,  -- Se muestra el usuario que realizó la acción
        B.Accion,
        B.Id_Orden,
        B.Estado_Anterior,
        B.Estado_Nuevo,
        B.Fecha_Atendida,
        B.Fecha_Cerrada,
        B.Descripcion,
        B.Observaciones
    FROM 
        Bitacora B
    INNER JOIN 
        Login L ON B.Id_Usuario = L.Id_Usuario;"; // Muestra todas las acciones
        }


    }
}
