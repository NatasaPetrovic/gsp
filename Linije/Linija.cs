using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linije
{
    public class Linija
    {
        #region Properties

        public int ID { get; set; }
        public string Naziv { get; set; }
        public string OpisLinije { get; set; }
        public string VrstaVozila { get; set; }
        public string VrstaLinije { get; set; }
        public bool Dnevna { get; set; }
        public bool Status { get; set; }
        public int VremePoluobrta { get; set; }

        #endregion
    }
}
