using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneKontrol
{
    public class GecisLoggerArgs :  EventArgs
    {
        private String _gecisBilgi;

        public GecisLoggerArgs(String gecisBilgi)
        {
            this._gecisBilgi = gecisBilgi;
        }

        public string GecisBilgisi
        {
            get
            {
                return _gecisBilgi;
            }
        }
    }
}
