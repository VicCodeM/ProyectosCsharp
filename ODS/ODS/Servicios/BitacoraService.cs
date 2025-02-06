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


        // Propiedad que contiene la consulta SQL
        public string DatosBitacora()
        {
            return @"
            SELECT 
                Bitacora.Id_Bitacora,
                Bitacora.Fecha_Accion,
                Login.Usuario AS NombreUsuario, -- Nombre del usuario
                Bitacora.Accion,
                Bitacora.Id_Orden,
                Bitacora.Estado_Anterior,
                Bitacora.Estado_Nuevo,
                Bitacora.Fecha_Atendida,
                Bitacora.Fecha_Cerrada,
                Bitacora.Descripcion,
                Bitacora.Observaciones
            FROM 
                Bitacora
            INNER JOIN 
                Login ON Bitacora.Id_Usuario = Login.Id_Usuario;";
        }

  
    }
}
