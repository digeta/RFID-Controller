using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekhaneKontrol
{
    public static class GecisLogger
    {
        private static String _gecisBilgi = "";

        public static event EventHandler<GecisLoggerArgs> OnGecisOldu;

        public static String GecisBilgisi
        {
            get
            {
                return _gecisBilgi;
            }
            set
            {
                _gecisBilgi = value;
                OnGecisOldu(null, new GecisLoggerArgs(_gecisBilgi));
            }
        }
    }
}
