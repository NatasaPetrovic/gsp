using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linije
{
    class LinijaStajaliste
    {
        #region Properties

        public int ID { get; set; }
        public int LinijaID { get; set; }
        public int StajalisteID { get; set; }
        public char Smer { get; set; }
        public int RedniBroj { get; set; }

        #endregion
    }
}
