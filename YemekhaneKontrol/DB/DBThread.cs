using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Reflection;

using YemekhaneKontrol.Error;
using YemekhaneKontrol.Misc;

namespace YemekhaneKontrol.DB
{
    public class DBThread
    {
        public event ErrorOccured OnError;
        
        private SqlConnection _sqlConn;

        private SqlConnection SqlBaglantisi
        {
            get
            {
                return _sqlConn;
            }
            set
            {
                _sqlConn = value;
            }
        }

        public DBThread()
        {
            this.SqlBaglantisi = new System.Data.SqlClient.SqlConnection(Settings.ConnectionStrLocal);
        }

        public Boolean InitDB()
        {
            Int32 result = 0;

            try
            {
                SqlCommand commAyar = new SqlCommand("SELECT * FROM AYARLAR WITH(NOLOCK)", _sqlConn);
                Settings.Ayarlar = VeriGetir(commAyar);

                if (Settings.Ayarlar.Rows.Count > 0)
                {
                    Settings.YemekhaneID = Convert.ToInt32(Settings.Ayarlar.Rows[0]["YEMEKHANE_ID"]);
                    result++;
                }

                SqlCommand commCihazlar = new SqlCommand("SELECT * FROM LISTE_TURNIKE WITH(NOLOCK) WHERE YEMEKHANE_ID = @YEMEKHANE_ID", _sqlConn);
                commCihazlar.Parameters.AddWithValue("YEMEKHANE_ID", Settings.YemekhaneID);
                Settings.Turnikeler = VeriGetir(commCihazlar);

                if (Settings.Turnikeler.Rows.Count > 0) result++;
            }
            catch (Exception ex)
            {
                result = 0;
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return result == 2 ? true:false;
        }

        private DataTable VeriGetir(SqlCommand comm)
        {
            DataTable dt = new DataTable();

            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open) _sqlConn.Open();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(comm);
                sqlAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            finally
            {
                if (_sqlConn.State != System.Data.ConnectionState.Closed) _sqlConn.Close();
            }
            return dt;
        }

        private Int32 VeriEkleDegistir(SqlCommand comm)
        {
            Int32 result = 0;

            try
            {
                SqlParameter resultParameter = new SqlParameter("SONUC", SqlDbType.Int);
                resultParameter.Direction = ParameterDirection.Output;
                comm.Parameters.Add(resultParameter);

                if (_sqlConn.State != System.Data.ConnectionState.Open) _sqlConn.Open();
                comm.ExecuteNonQuery();

                result = Convert.ToInt32(resultParameter.Value);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            finally
            {
                if (_sqlConn.State != System.Data.ConnectionState.Closed) _sqlConn.Close();
            }

            return result;
        }

        public Kisi KartKontrol(Int64 kartId)
        {
            Kisi kisi = new Kisi();
            kisi.TanimsizKart = true;

            //List<int> numbers = new List<int> { 11, 37, 52 };
            //List<int> oddNumbers = numbers.Where(n => n % 2 == 1).ToList();            

            DataTable dt = new DataTable();

            try
            {
                SqlCommand comm = new SqlCommand("stp_KART_KONTROL", _sqlConn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("KART_ID", kartId);

                dt = VeriGetir(comm);

                if (dt.Rows.Count > 0)
                {
                    kisi.KartID = Convert.ToInt64(dt.Rows[0]["KART_ID"]);
                    kisi.TCkimlik = Convert.ToInt64(dt.Rows[0]["TCKIMLIK"]);
                    kisi.Ad = Convert.ToString(dt.Rows[0]["AD"]);
                    kisi.Soyad = Convert.ToString(dt.Rows[0]["SOYAD"]);
                    kisi.TarifeId = Convert.ToInt32(dt.Rows[0]["TARIFE_ID"]);
                    kisi.Tarife = Convert.ToString(dt.Rows[0]["TARIFE"]);
                    //kisi.KartIptal = Convert.ToBoolean(dt.Rows[0]["KART_IPTAL"]);
                    //kisi.KartAktifEdildi = Convert.ToBoolean(dt.Rows[0]["AKTIF_EDILDI"]);
                    Decimal ucret = Decimal.Round(Convert.ToDecimal(dt.Rows[0]["UCRET"], Settings.Bolge), 2, MidpointRounding.AwayFromZero);
                    Decimal ucret2 = Decimal.Round(Convert.ToDecimal(dt.Rows[0]["UCRET2"], Settings.Bolge), 2, MidpointRounding.AwayFromZero);
                    kisi.TarifeUcret = ucret;
                    kisi.TarifeUcret2 = ucret2;
                    kisi.TanimsizKart = false;
                    kisi.AktifEdilmis = Convert.ToBoolean(dt.Rows[0]["AKTIF_EDILDI"]);
                    kisi.IptalEdilmis = Convert.ToBoolean(dt.Rows[0]["KART_IPTAL"]);
                }
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return kisi;
        }

        public Kisi BakiyeDurum(Kisi kisi)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand comm = new SqlCommand("stp_BAKIYE_DURUM", _sqlConn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("KART_ID", kisi.KartID);

                dt = VeriGetir(comm);

                if (dt.Rows.Count > 0)
                {
                    Decimal bakiye = Convert.ToDecimal(dt.Rows[0]["BAKIYE"]);
                    kisi.SonHarcama = bakiye;
                    kisi.SonHarcamaTarih = Convert.ToDateTime(dt.Rows[0]["SON_HARCAMA_TAR"]);
                    kisi.SonHarcamaKonum = Convert.ToString(dt.Rows[0]["SON_HARCAMA_KONUMU"]);
                    kisi.SonHarcamaKonumID = Convert.ToInt32(dt.Rows[0]["SON_HARCAMA_KONUM"]);
                }
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return kisi;
        }

        public Int32 HarcamaKaydet(Kisi kisi)
        {
            Int32 inserted = 0;

            try
            {
                SqlCommand comm = new SqlCommand("stp_BAKIYE_HARCAMA", _sqlConn);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("TCKIMLIK", kisi.TCkimlik);
                comm.Parameters.AddWithValue("KART_ID", kisi.KartID);
                comm.Parameters.AddWithValue("YEMEKHANE_ID", Settings.YemekhaneID);
                comm.Parameters.AddWithValue("TURNIKE_NO", kisi.TurnikeNo);
                comm.Parameters.AddWithValue("BAKIYE_ONCEKI", kisi.OncekiBakiye);
                comm.Parameters.AddWithValue("BAKIYE_HARCANAN", kisi.Ucret);
                comm.Parameters.AddWithValue("BAKIYE_KALAN", kisi.KalanBakiye);
                comm.Parameters.AddWithValue("FAZLA_YEMEK", kisi.FazlaYemek);
                comm.Parameters.AddWithValue("KUL_BAKIYE_ID", 0);
                comm.Parameters.AddWithValue("KUL_HARCAMA_ID", 0);

                inserted = VeriEkleDegistir(comm);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return inserted;
        }

        public Int32 GecisKaydet(Kisi kisi)
        {
            Int32 inserted = 0;

            try
            {
                SqlCommand comm = new SqlCommand("stp_GECIS_KAYDET", _sqlConn);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("TCKIMLIK", kisi.TCkimlik);
                comm.Parameters.AddWithValue("KART_ID", kisi.KartID);
                comm.Parameters.AddWithValue("YEMEKHANE_ID", Settings.YemekhaneID);
                comm.Parameters.AddWithValue("TURNIKE_NO", kisi.TurnikeNo);
                comm.Parameters.AddWithValue("BAKIYE_ONCEKI", kisi.OncekiBakiye);
                comm.Parameters.AddWithValue("BAKIYE_HARCANAN", kisi.Ucret);
                comm.Parameters.AddWithValue("BAKIYE_KALAN", kisi.KalanBakiye);
                comm.Parameters.AddWithValue("KUL_BAKIYE_ID", 0);
                comm.Parameters.AddWithValue("KUL_HARCAMA_ID", 0);

                inserted = VeriEkleDegistir(comm);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return inserted;
        }

        public DataTable GecislerGetir()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand comm = new SqlCommand("stp_GECISLER_GETIR", _sqlConn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("YEMEKHANE_ID", Settings.YemekhaneID);

                dt = VeriGetir(comm);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return dt;
        }

        public DataTable TurnikelerGetir()
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand comm = new SqlCommand("stp_TURNIKELER_GETIR", _sqlConn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("YEMEKHANE_ID", Settings.YemekhaneID);

                dt = VeriGetir(comm);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return dt;
        }

        public Int32 TurnikeDurumDegis(Int32 turnikeNo)
        {
            Int32 inserted = 0;

            try
            {
                SqlCommand comm = new SqlCommand("stp_TURNIKE_DURUM_DEGIS", _sqlConn);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("YEMEKHANE_ID", Settings.YemekhaneID);
                comm.Parameters.AddWithValue("TURNIKE_NO", turnikeNo);

                inserted = VeriEkleDegistir(comm);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return inserted;
        }
    }
}