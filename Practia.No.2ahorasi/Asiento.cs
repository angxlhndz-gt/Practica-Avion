using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practia.No._2ahorasi
{
    internal class Asiento
    {
        public bool Ocupado { get; set; }
        public string Nombre { get; set; }
        public string CUI { get; set; }
        public bool LlevaMaleta { get; set; }

        public Asiento()
        {
            Ocupado = false;
            Nombre = "";
            CUI = "";
            LlevaMaleta = false;
        }
        
        
    }
}
