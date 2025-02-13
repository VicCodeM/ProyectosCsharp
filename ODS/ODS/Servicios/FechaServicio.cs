using System;

namespace ODS
{
    public class FechaServicio
    {
        //metodos para obtener la fecha y hora del sistema
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
