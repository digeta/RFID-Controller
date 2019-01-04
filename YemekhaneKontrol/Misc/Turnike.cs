using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YemekhaneKontrol.Perio;

namespace YemekhaneKontrol.Misc
{
    public class Turnike
    {
        PerioTCPRdrComp _perioClass;

        private System.Net.Sockets.Socket socket;
        private Kisi _sonGecenKisi;

        private String _ip = "";
        private Int32 _port = 0;
        private Int32 _turnikeNum = 0;
        private Int64 _okunanKartId = 0;
        private Int64 _sonOkunanKartId = 0;
        private Boolean _aktif = false;
        private Boolean _baglaniyor = false;
        private Boolean _gecisBekliyor = false;
        private Boolean _oncekiGecisBasarili = false;
        private Int32 _timeout = 0;
        private Boolean _turnikesiz = false;
        private Boolean _yazicisiz = false;
        private Boolean _gosterge = false;

        public PerioTCPRdrComp PerioClass
        {
            get
            {
                return _perioClass;
            }
            set
            {
                _perioClass = value;
            }
        }

        public System.Net.Sockets.Socket TurnikeSocket
        {
            get
            {
                return socket;
            }
            set
            {
                socket = value;
            }
        }

        public Kisi SonGecenKisi
        {
            get
            {
                return _sonGecenKisi;
            }
            set
            {
                _sonGecenKisi = value;
            }
        }

        public String IP
        {
            get
            {
                return _ip;
            }
            set
            {
                _ip = value;
            }
        }

        public Int32 TurnikeNo
        {
            get
            {
                return _turnikeNum;
            }
            set
            {
                _turnikeNum = value;
            }
        }

        public Int64 OkunanKartID
        {
            get
            {
                return _okunanKartId;
            }
            set
            {
                _okunanKartId = value;
            }
        }

        public Int64 SonOkunanKartID
        {
            get
            {
                return _sonOkunanKartId;
            }
            set
            {
                _sonOkunanKartId = value;
            }
        }

        public Int32 Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public Boolean Aktif
        {
            get
            {
                return _aktif;
            }
            set
            {
                _aktif = value;
            }
        }

        public Boolean Baglaniyor
        {
            get
            {
                return _baglaniyor;
            }
            set
            {
                _baglaniyor = value;
            }
        }

        public Boolean GecisBekliyor
        {
            get
            {
                return _gecisBekliyor;
            }
            set
            {
                _gecisBekliyor = value;
            }
        }

        public Boolean OncekiGecisBasarili
        {
            get
            {
                return _oncekiGecisBasarili;
            }
            set
            {
                _oncekiGecisBasarili = value;
            }
        }

        public Int32 TimeOut
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
            }
        }

        public Boolean Turnikesiz
        {
            get
            {
                return _turnikesiz;
            }
            set
            {
                _turnikesiz = value;
            }
        }

        public Boolean Yazicisiz
        {
            get
            {
                return _yazicisiz;
            }
            set
            {
                _yazicisiz = value;
            }
        }

        public Boolean Gosterge
        {
            get
            {
                return _gosterge;
            }
            set
            {
                _gosterge = value;
            }
        }
    }
}
