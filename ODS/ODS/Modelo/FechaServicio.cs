using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODS
{
    public class FechaServicio
    {
        public string ObtenerFecha()
        {
            return DateTime.Now.ToString("dd/MM/yyyy"); // Formato Año-Mes-Día
        }

        public string ObtenerHora()
        {
            // Retorna la hora actual del sistema como cadena
            return DateTime.Now.ToString("hh:mm:ss"); // Formato Hora:Minuto:Segundo
        }
    }
}
