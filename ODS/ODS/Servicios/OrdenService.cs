using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODS.Modelo
{
    public class OrdenService
    {
        public class Orden
        {
            public DateTime? FechaAtendida { get; set; }
            public DateTime? FechaCerrada { get; set; }
            public int? IdFallaHardware { get; set; }
            public int? IdFallaSoftware { get; set; }
            public string Descripcion { get; set; }
            public string Observaciones { get; set; }
            public string Estado { get; set; }
        }

    }
}
