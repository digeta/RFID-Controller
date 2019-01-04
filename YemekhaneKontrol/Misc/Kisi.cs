using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YemekhaneKontrol.Misc
{
    public class Kisi
    {
        private Int64 _kartId = 0;
        private Int64 _tckimlik = 0;

        private String _ad = "";
        private String _soyad = "";

        private Int32 _tarifeId = 0;
        private String _tarife = "";

        private Int32 _turnikeNo = 0;

        private Boolean _tanimsizKart = false;
        private Boolean _aktifEdilmis = false;
        private Boolean _iptalEdilmis = false;

        private Boolean _tekrarGecis = false;
        private Boolean _yetersizBakiye = false;
        private Boolean _gecisOnay = false;
        private Boolean _gecisKaydet = false;
        private Boolean _geciyor = false;
        private Boolean _fazlaYemek = false;

        private Decimal _kalanBakiye = 0;
        private Decimal _oncekiBakiye = 0;
        //private DateTime _oncekiBakiyeTarih;
        
        private Decimal _sonHarcama = 0;
        private Int32 _sonHarcamaKonumId = 0;
        private String _sonHarcamaKonum = "";
        //private Decimal _sonYuklenen = 0;

        private Decimal _trfUcret = 0;
        private Decimal _trfUcret2 = 0;
        private Decimal _ucret = 0;

        //private DateTime _sonYuklemeTarih;
        private DateTime _sonHarcamaTarih;

        private Byte _buzzerTime_1;
        private Byte _buzzerTime_2;
        private Byte _screenTime_1;
        private Byte _screenTime_2;

        private Byte[] _byteData;

        private Byte _komut = 0;



        [StringValue("KART_ID")]public Int64 KartID
        {
            get
            {
                return _kartId;
            }
            set
            {
                _kartId = value;
            }
        }


        [StringValue("TCKIMLIK")]public Int64 TCkimlik
        {
            get
            {
                return _tckimlik;
            }
            set
            {
                _tckimlik = value;
            }
        }

        [StringValue("AD")]public String Ad
        {
            get
            {
                return _ad;
            }
            set
            {
                _ad = value;
            }
        }

        [StringValue("SOYAD")]public String Soyad
        {
            get
            {
                return _soyad;
            }
            set
            {
                _soyad = value;
            }
        }

        [StringValue("TARIFE_ID")]public Int32 TarifeId
        {
            get
            {
                return _tarifeId;
            }
            set
            {
                _tarifeId = value;
            }
        }

        [StringValue("TARIFE")]public String Tarife
        {
            get
            {
                return _tarife;
            }
            set
            {
                _tarife = value;
            }
        }

        [StringValue("TURNIKE_ID")]public Int32 TurnikeNo
        {
            get
            {
                return _turnikeNo;
            }
            set
            {
                _turnikeNo = value;
            }
        }

        [StringValue("BAKIYE_KALAN")]public Decimal KalanBakiye
        {
            get
            {
                return _kalanBakiye;
            }
            set
            {
                _kalanBakiye = value;
            }
        }

        [StringValue("BAKIYE_ONCEKI")]public Decimal OncekiBakiye
        {
            get
            {
                return _oncekiBakiye;
            }
            set
            {
                _oncekiBakiye = value;
            }
        }

        [StringValue("BAKIYE_HARCANAN")]public Decimal Ucret
        {
            get
            {
                return _ucret;
            }
            set
            {
                _ucret = value;
            }
        }

        [StringValue("BAKIYE")]public Decimal SonHarcama
        {
            get
            {
                return _sonHarcama;
            }
            set
            {
                _sonHarcama = value;
            }
        }

        [StringValue("SON_HARCAMA_KONUM")]public Int32 SonHarcamaKonumID
        {
            get
            {
                return _sonHarcamaKonumId;
            }
            set
            {
                _sonHarcamaKonumId = value;
            }
        }

        [StringValue("SON_HARCAMA_KONUMU")]public String SonHarcamaKonum
        {
            get
            {
                return _sonHarcamaKonum;
            }
            set
            {
                _sonHarcamaKonum = value;
            }
        }

        [StringValue("UCRET")]public Decimal TarifeUcret
        {
            get
            {
                return _trfUcret;
            }
            set
            {
                _trfUcret = value;
            }
        }

        [StringValue("UCRET2")]public Decimal TarifeUcret2
        {
            get
            {
                return _trfUcret2;
            }
            set
            {
                _trfUcret2 = value;
            }
        }

        [StringValue("")]public Boolean TanimsizKart
        {
            get
            {
                return _tanimsizKart;
            }
            set
            {
                _tanimsizKart = value;
            }
        }

        [StringValue("AKTIF_EDILDI")]public Boolean AktifEdilmis
        {
            get
            {
                return _aktifEdilmis;
            }
            set
            {
                _aktifEdilmis = value;
            }
        }

        [StringValue("KART_IPTAL")]public Boolean IptalEdilmis
        {
            get
            {
                return _iptalEdilmis;
            }
            set
            {
                _iptalEdilmis = value;
            }
        }

        [StringValue("")]public Boolean TekrarGecis
        {
            get
            {
                return _tekrarGecis;
            }
            set
            {
                _tekrarGecis = value;
            }
        }

        [StringValue("")]public Boolean YetersizBakiye
        {
            get
            {
                return _yetersizBakiye;
            }
            set
            {
                _yetersizBakiye = value;
            }
        }

        [StringValue("")]public Boolean GecisOnay
        {
            get
            {
                return _gecisOnay;
            }
            set
            {
                _gecisOnay = value;
            }
        }

        [StringValue("")]public Boolean GecisKaydet
        {
            get
            {
                return _gecisKaydet;
            }
            set
            {
                _gecisKaydet = value;
            }
        }

        [StringValue("")]public Boolean Geciyor
        {
            get
            {
                return _geciyor;
            }
            set
            {
                _geciyor = value;
            }
        }

        [StringValue("")]public Boolean FazlaYemek
        {
            get
            {
                return _fazlaYemek;
            }
            set
            {
                _fazlaYemek = value;
            }
        }
        /*
        public DateTime SonYuklemeTarih
        {
            get
            {
                return _sonYuklemeTarih;
            }
            set
            {
                _sonYuklemeTarih = value;
            }
        }
        */
        [StringValue("SON_HARCAMA_TAR")]public DateTime SonHarcamaTarih
        {
            get
            {
                return _sonHarcamaTarih;
            }
            set
            {
                _sonHarcamaTarih = value;
            }
        }

        [StringValue("")]public Byte[] ByteData
        {
            get
            {
                return _byteData;
            }
            set
            {
                _byteData = value;
            }
        }

        [StringValue("")]public Byte BuzzerTime_1
        {
            get
            {
                return _buzzerTime_1;
            }
            set
            {
                _buzzerTime_1 = value;
            }
        }

        [StringValue("")]public Byte BuzzerTime_2
        {
            get
            {
                return _buzzerTime_2;
            }
            set
            {
                _buzzerTime_2 = value;
            }
        }

        [StringValue("")]public Byte ScreenTime_1
        {
            get
            {
                return _screenTime_1;
            }
            set
            {
                _screenTime_1 = value;
            }
        }

        [StringValue("")]public Byte ScreenTime_2
        {
            get
            {
                return _screenTime_2;
            }
            set
            {
                _screenTime_2 = value;
            }
        }

        [StringValue("")]public Byte Komut
        {
            get
            {
                return _komut;
            }
            set
            {
                _komut = value;
            }
        }
    }

    public class StringValueAttribute : System.Attribute
    {

        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}