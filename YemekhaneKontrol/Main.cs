using System;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using YemekhaneKontrol.DB;
using YemekhaneKontrol.Error;
using YemekhaneKontrol.Misc;
using YemekhaneKontrol.Perio;

namespace YemekhaneKontrol
{
    public partial class Main : Form
    {
        private event ErrorOccured OnError;

        private delegate void deleg(String data);
        private delegate void delegDataSource(DataTable dataTable, DataGridView dataGrid);
        private delegate void delegTurnike(Boolean stat);

        DataTable _table;

        private System.Timers.Timer _uptimer;
        private Int32 _elapsed = 0;

        private static System.Diagnostics.StackTrace currentStack;

        public Main()
        {
            Settings.Bolge = new CultureInfo("tr-TR");
            InitializeComponent();
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                currentStack = new System.Diagnostics.StackTrace();
                MessageBox.Show(currentStack.GetFrame(0).GetMethod().Name);
                MessageBox.Show(e.Exception.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.OnError += Main_OnError;

            DataTable dt = new DataTable();
            DBThread dba = new DBThread();
            
            dba.OnError += new ErrorOccured(Main_OnError);
            
            this.FormClosing += new FormClosingEventHandler(OnClose);
            txtLogger.KeyDown += new KeyEventHandler(txtLogger_KeyDown);
            //Logger.OnMessageChanged += new EventHandler<LogArgs>(OnMessageChanged);
            
            GecisLogger.OnGecisOldu += new EventHandler<GecisLoggerArgs>(OnGecisOldu);

            if (!System.Diagnostics.Debugger.IsAttached)
            {
                AddLog("*** Sistem Aktif ***");
            }
            else
            {
                AddLog("*** DEBUG modu aktif ***");
            }
                        
            _uptimer = new System.Timers.Timer();
            _uptimer.Elapsed += new System.Timers.ElapsedEventHandler(UptimerElapsed);
            _uptimer.Interval = 1000;
            _uptimer.Start();


            try
            {     
                if (dba.InitDB())
                {
                    _table = new DataTable();
                    _table.Columns.Add("TableId", typeof(Int32));
                    _table.Columns.Add("PerioClass", typeof(PerioTCPRdrComp));
                    _table.Columns.Add("TurnikeNo", typeof(Int32));
                    _table.Columns.Add("TurnikeIP", typeof(String));
                    _table.Columns.Add("TurnikeClass", typeof(Turnike));
                    
                    DataRow[] turnikeler = Settings.Turnikeler.Select("LEN(IP) > 0 AND PORT > 0");
                    PerioTCPRdrComp[] perioReader = new PerioTCPRdrComp[turnikeler.Length];


                    for (Int32 i = 0; i < turnikeler.Length; i++)
                    {
                        Turnike turnike = new Turnike();

                        turnike.TurnikeNo = Convert.ToInt32(turnikeler[i]["TURNIKE_NO"]);
                        turnike.IP = Convert.ToString(turnikeler[i]["IP"]);
                        turnike.Port = Convert.ToInt32(turnikeler[i]["PORT"]);
                        turnike.Turnikesiz = Convert.ToBoolean(turnikeler[i]["TURNIKESIZ"]);
                        turnike.Yazicisiz = Convert.ToBoolean(turnikeler[i]["YAZICISIZ"]);
                        turnike.Aktif = Convert.ToBoolean(turnikeler[i]["AKTIF"]);
                        turnike.Gosterge = Convert.ToBoolean(turnikeler[i]["GOSTERGE"]);

                        perioReader[i] = new PerioTCPRdrComp();
                        perioReader[i].IP = turnike.IP;
                        perioReader[i].DeviceLoginKey = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
                        perioReader[i].AutoRxEnabled = true;
                        perioReader[i].AutoConnect = false;
                        perioReader[i].OnlineReConnectTimeOut = 10000;
                        perioReader[i].TimeOut = 3000;

                        perioReader[i].OnError += new ErrorOccured(Main_OnError);
                        perioReader[i].OnRxCardID += new RxCardID(KartOkundu);
                        perioReader[i].OnRxTurnstileTurn += new RxTurnstileTurn(TurnikeGecis);

                        perioReader[i].ThreadAktif = turnike.Aktif;

                        turnike.PerioClass = perioReader[i];
                        _table.Rows.Add(i, perioReader[i], turnike.TurnikeNo, turnike.IP, turnike);
                    }

                    FirstRun();
                }
                else
                {
                    this.BeginInvoke(new deleg(AddLog), "Veritabanı bağlantısında sorun var ! ");
                }
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                    OnError(this, new ErrorOccuredArgs(method, ex.Message));
                }
            }
        }

        private void FirstRun()
        {
            try
            {
                for (Int32 i = 0; i < _table.Rows.Count; i++)
                {
                    Turnike turnike = (Turnike)_table.Rows[i]["TurnikeClass"];                    

                    if (turnike.PerioClass.ThreadAktif)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(OkuyucuHaberles));
                        thread.Name = "FR_ThreadTurnike_" + Convert.ToString(turnike.TurnikeNo);

                        thread.Start(turnike.PerioClass);
                    }
                }

                Thread listeleThread = new Thread(new ThreadStart(Listele));
                listeleThread.Name = "Listele_FirstRun";
                listeleThread.Start();

                Thread turnikeThread = new Thread(new ThreadStart(TurnikeListele));
                turnikeThread.Name = "TurnikeListele_FirstRun";
                turnikeThread.Start();
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
        }

        private void Check()
        {
            try
            {
                for (Int32 i = 0; i < _table.Rows.Count; i++)
                {
                    PerioTCPRdrComp perioReader = (PerioTCPRdrComp)_table.Rows[i]["PerioClass"];
                    DataRow tableRow = _table.Select("TurnikeIP = '" + perioReader.IP + "'")[0];
                    Turnike turnike = (Turnike)tableRow["TurnikeClass"];
                    perioReader.ThreadAktif = turnike.Aktif;
   
                    if (perioReader.ThreadAktif)
                    {
                        if (!perioReader.Connected)
                        {
                            try
                            {
                                perioReader.Connect();
                            }
                            catch (Exception ex)
                            {
                                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                                OnError(this, new ErrorOccuredArgs(method, ex.Message));
                            }

                            Thread.Sleep(10);

                            perioReader.ThreadAktif = true;
                                                        
                            Thread thread = new Thread(new ParameterizedThreadStart(OkuyucuHaberles));
                            thread.Name = "CH_Turnike_" + Convert.ToString(_table.Rows[i]["TurnikeNo"]);
                            thread.Start(perioReader);
                        }
                    }
                    else
                    {
                        if (perioReader.Connected) // tablerow aktif kontrollü?
                        {
                            perioReader.DisConnect();                            
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            finally
            {
                _uptimer.Start();
            }
        }

        #region "Kart Okuma, Geçiş"""""""""""""""""""""""""""""""""""
        private void OkuyucuHaberles(object okuyucuObj)
        {
            PerioTCPRdrComp okuyucu = (PerioTCPRdrComp)okuyucuObj;
            okuyucu.Connect();

            Boolean noConn = false;

            while (okuyucu.ThreadAktif)
            {
                    try
                    {
                        if(okuyucu.ReaderFailure)
                        {
                            Thread.Sleep(30000);
                        }

                        okuyucu.CheckOnlineData(out noConn);
                        Thread.Sleep(10);
                    }
                    catch (Exception ex)
                    {
                        String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                        OnError(this, new ErrorOccuredArgs(method, ex.Message));
                    }


                    if (noConn)
                    {
                        try
                        {
                            okuyucu.DeaktifTime++;

                            Thread.Sleep(8000);

                            if(okuyucu.DeaktifTime > 15)
                            {
                                okuyucu.ReaderFailure = true;
                            }

                            if(okuyucu.DeaktifTime > 30)
                            {
                                Thread.Sleep(8000);
                            }
                            else
                            {
                                okuyucu.Connect();
                            }                            
                        }
                        catch (Exception ex)
                        {
                            String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                            OnError(this, new ErrorOccuredArgs(method, ex.Message));
                        }
                    }
                    else
                    {
                        okuyucu.DeaktifTime = 0;
                        okuyucu.ReaderFailure = false;
                    }
            }
        }

        private void KartOkundu(object source, RxCardIDArgs e)
        {
            try
            {
                PerioTCPRdrComp pr = (PerioTCPRdrComp)source;

                DataRow tableRow = _table.Select("TurnikeIP = '" + pr.IP + "'")[0];
                Turnike turnike = (Turnike)tableRow["TurnikeClass"];

                turnike.OkunanKartID = KartIdCevir(e.CardID);
                turnike.PerioClass = (PerioTCPRdrComp)source;

                Thread okunduThread = new Thread(new ParameterizedThreadStart(KartIslem));
                okunduThread.Name = "KartIslem";
                okunduThread.Start(turnike);

            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
        }

        private void TurnikeGecis(object source, RxTurnstileTurnArgs e)
        {
            if (e.Success)
            {
                GecisLogger.GecisBilgisi = " Turnike Dönüş Başarılı"; //Kart No: [" + e.CardID + "].";

                PerioTCPRdrComp pr = (PerioTCPRdrComp)source;

                DataRow tableRow = _table.Select("TurnikeIP = '" + pr.IP + "'")[0];
                Turnike turnike = (Turnike)tableRow["TurnikeClass"];

                turnike.GecisBekliyor = false;

                Thread harcaThread = new Thread(new ParameterizedThreadStart(BakiyeDusur));
                harcaThread.Name = "BakiyeDusur";
                harcaThread.Start(turnike);
            }
            else
            {
                GecisLogger.GecisBilgisi = "Turnike Dönüş Başarısız"; //Kart ID [" + e.CardID + "].";
            }
        }

        private Int64 KartIdCevir(String str)
        {
            Int64 kartNo = 0;
            try
            {
                kartNo = Convert.ToInt64(str.Substring(0, 8), 16);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            return kartNo;
        }

        private void KartIslem(Object turnikeObj)
        {
            Turnike turnike = (Turnike)turnikeObj;
            Kisi kisi = new Kisi();

            String gecisDurum = "";
  
            Boolean fazlaYemek = false;
            DateTime bugun = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            Int32 gecisKayitDurum = 0;

            try
            {
                DBThread db = new DBThread();

                if (turnike.OkunanKartID > 0)
                {
                    if (turnike.Gosterge == false)
                    {
                        if (turnike.SonOkunanKartID == turnike.OkunanKartID)
                        {
                            if (turnike.OncekiGecisBasarili)
                            {
                                kisi = turnike.SonGecenKisi;
                                if (!kisi.YetersizBakiye)
                                {
                                    kisi.TekrarGecis = true;
                                }
                            }
                        }
                    }

                    if (!kisi.TekrarGecis)
                    {
                        kisi = db.KartKontrol(turnike.OkunanKartID);
                        kisi.TurnikeNo = turnike.TurnikeNo;

                        if (!kisi.TanimsizKart && !kisi.IptalEdilmis && kisi.AktifEdilmis)
                        {
                            kisi = db.BakiyeDurum(kisi);
                            kisi.OncekiBakiye = kisi.SonHarcama;

                            Int32 sonHarcamaBugunMu = bugun.Date.CompareTo(kisi.SonHarcamaTarih.Date);

                            if (sonHarcamaBugunMu == 0)
                            {
                                fazlaYemek = true;
                            }

                            // Aynı gün yenilen diğer yemekler
                            if (!fazlaYemek)
                            {
                                kisi.Ucret = kisi.TarifeUcret;
                                kisi.FazlaYemek = false;
                            }
                            else
                            {
                                kisi.FazlaYemek = true;
                                kisi.Ucret = kisi.TarifeUcret2;
                            }

                            // Bakiye burda düşülür ------------------------------>
                            if (kisi.OncekiBakiye >= kisi.Ucret)
                            {
                                kisi.KalanBakiye = kisi.OncekiBakiye - kisi.Ucret;
                                kisi.GecisOnay = true;

                                turnike.SonGecenKisi = kisi;
                                turnike.SonOkunanKartID = kisi.KartID;

                                turnike.OncekiGecisBasarili = true;

                                //CİHAZ GÖSTERGE DEĞİL İSE KAYIT İŞLEMLERİNİ YAP
                                if (turnike.Gosterge == false)
                                {
                                    gecisKayitDurum = db.GecisKaydet(kisi); // GEÇİŞ (KART OKUTMA) KAYDET

                                    if (gecisKayitDurum == 100)
                                    {
                                        // Turnikesiz geçişler için

                                        if (turnike.Turnikesiz)
                                        {
                                            Thread thread = new Thread(new ParameterizedThreadStart(BakiyeDusur));
                                            thread.Start(turnike);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                kisi.YetersizBakiye = true;
                            }
                        }
                    }


                    //----------------------- Cihaza yazı ve uyarı gönder ---------------------------------------------------->
                    TLcdScreen LcdScreenMsg = new TLcdScreen();
                    
                    if (kisi.TanimsizKart)
                    {
                        gecisDurum = "Tanımsız Kart ! ";
                        
                        LcdScreenMsg.Line[1].Text = "  Tanimsiz  Kart";
                        LcdScreenMsg.Line[2].Text = "Lütfen Kartinizi";
                        LcdScreenMsg.Line[3].Text = "   Tanimlatiniz";
                        LcdScreenMsg.BZR_time = 700;
                    }
                    else
                    {
                        if(kisi.IptalEdilmis)
                        {
                            gecisDurum = "İptal Edilmiş Kart ! ";

                            LcdScreenMsg.Line[1].Text = "    Kartiniz   ";
                            LcdScreenMsg.Line[2].Text = " Iptal Edilmis";
                            LcdScreenMsg.BZR_time = 700;
                        }
                        else
                        {
                            if(!kisi.AktifEdilmis)
                            {
                                gecisDurum = "Aktivasyon Gerekli ! ";

                                LcdScreenMsg.Line[1].Text = "Kart Aktivasyonu";
                                LcdScreenMsg.Line[2].Text = "   Gerekli";
                                LcdScreenMsg.BZR_time = 700;
                            }
                            else
                            {
                                if (turnike.Gosterge == false)
                                {
                                    if (kisi.TekrarGecis)
                                    {
                                        gecisDurum = "Mükerrer Geçiş ! ";

                                        LcdScreenMsg.Line[1].Text = " Ödemeniz yapilmis  ";
                                        LcdScreenMsg.Line[2].Text = "Gecis yapabilirsiniz";
                                        LcdScreenMsg.BZR_time = 500;
                                        LcdScreenMsg.RL_Time1 = 100;
                                        LcdScreenMsg.IsBlink = true;
                                    }
                                    else
                                    {
                                        if (kisi.YetersizBakiye)
                                        {
                                            gecisDurum = "Yetersiz Bakiye ! ";

                                            LcdScreenMsg.Line[1].Text = "Yetersiz Bakiye !";
                                            LcdScreenMsg.Line[2].Text = "Mevcut : " + kisi.OncekiBakiye.ToString("0.00");
                                            LcdScreenMsg.Line[3].Text = "Gereken : " + kisi.Ucret.ToString("0.00");
                                            LcdScreenMsg.BZR_time = 600;
                                        }
                                        else
                                        {
                                            if (fazlaYemek)
                                            {
                                                gecisDurum = "Başarılı, Geçiş Bekleniyor... " +
                                                    "\r\n Fazla Yemek Ücreti Düşülecek ! ";
                                            }
                                            else
                                            {
                                                gecisDurum = "Başarılı, Geçiş Bekleniyor... ";
                                            }

                                            LcdScreenMsg.Line[1].Text = "Kalan : " + kisi.KalanBakiye.ToString("0.00");
                                            LcdScreenMsg.Line[2].Text = "Düsülen : " + kisi.Ucret.ToString("0.00");
                                            LcdScreenMsg.Line[3].Text = "Önceki : " + kisi.OncekiBakiye.ToString("0.00");
                                            LcdScreenMsg.Line[4].Text = "**Afiyet Olsun**";
                                            LcdScreenMsg.BZR_time = 600;
                                            LcdScreenMsg.RL_Time1 = 100;
                                            LcdScreenMsg.IsBlink = true;

                                            turnike.GecisBekliyor = true;
                                        }
                                    }
                                }
                                else
                                {
                                    LcdScreenMsg.Line[1].Text = kisi.Ad + " " + kisi.Soyad;
                                    LcdScreenMsg.Line[2].Text = "Mevcut : " + kisi.OncekiBakiye.ToString("0.00");
                                    LcdScreenMsg.Line[3].Text = "Gereken : " + kisi.Ucret.ToString("0.00");
                                    //LcdScreenMsg.Line[4].Text = "**Afiyet Olsun**";
                                    LcdScreenMsg.BZR_time = 300;
                                }
                            }
                        }
                    }

                    Thread.Sleep(20);

                    turnike.PerioClass.tcpSetBeepRelayAndSecreenMessage(LcdScreenMsg);

                    if (turnike.Gosterge == false)
                    {
                        GecisLogger.GecisBilgisi = " ******************************************" +
                            "\r\n Durum : " + gecisDurum +
                            "\r\n" +
                            "\r\n Turnike No: " + Convert.ToString(turnike.TurnikeNo) +
                            "\r\n Kart No: " + Convert.ToString(turnike.OkunanKartID) +
                            "\r\n Kart Okutan Kişi : " + kisi.Ad + " " + kisi.Soyad +
                            "\r\n" + " Önceki Bakiye : " + Convert.ToString(kisi.OncekiBakiye) +
                            "\r\n" + " Yemek Ücreti : " + Convert.ToString(kisi.Ucret) + (fazlaYemek ? "<---" : "") +
                            "\r\n" + " Kalan Bakiye: " + Convert.ToString(kisi.KalanBakiye);
                    }
                }

                 Int32 tableId = (Int32)_table.Select("TurnikeIP = '" + turnike.IP + "'")[0]["TableId"];
                _table.Rows.RemoveAt(_table.Rows.IndexOf(_table.Select("TurnikeIP = '" + turnike.IP + "'")[0]));
                _table.Rows.Add(tableId, turnike.PerioClass, turnike.TurnikeNo, turnike.IP, turnike);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
        }

        private void BakiyeDusur(object turnikeObj)
        {
            Turnike turnike = (Turnike)turnikeObj;
            Kisi kisi = new Kisi();

            try
            {
                DBThread db = new DBThread();

                kisi = turnike.SonGecenKisi;

                kisi.TekrarGecis = false;
                kisi.GecisKaydet = true;
                kisi.Geciyor = true;

                turnike.SonOkunanKartID = 0;

                if (kisi.GecisKaydet && !kisi.TanimsizKart && !kisi.YetersizBakiye && !kisi.TekrarGecis)
                {
                    GecisLogger.GecisBilgisi = " Geçiş Yapan : " + kisi.Ad + " " + kisi.Soyad +
                        "\r\n ******************************************";
                    //this.BeginInvoke(new deleg(Log), Logger.Message);

                    /*
                    turnike.PerioClass.SetBeepRelayAndSecreenMessage(0, 0, "", "Geçiş ", "Başarılı", "", "", "", "",
                        5, 15, 0, 5, 35, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 2, 2, 5, 0, 0, 1000, true);                 
                    */

                    this.BeginInvoke(new deleg(AddSysLog), Convert.ToString(turnike.Yazicisiz) + "\r\n");

                    if (!turnike.Yazicisiz)
                    {
                        this.BeginInvoke(new deleg(AddSysLog), "1\r\n");
                        
                        Fis fis = new Fis();
                        if (fis.FisHazirla(kisi))
                        {
                            //Fis.FisOnizleme();
                            this.BeginInvoke(new deleg(AddSysLog), "2\r\n");
                            fis.FisVer();
                        }
                    }
                    this.BeginInvoke(new deleg(AddSysLog), "3\r\n");
                    this.BeginInvoke(new deleg(AddSysLog), "\r\n");

                    if (db.HarcamaKaydet(kisi) == 100)
                    {
                        turnike.GecisBekliyor = false;
                    }
                }

                turnike.OncekiGecisBasarili = false;

                Int32 tableId = (Int32)_table.Select("TurnikeIP = '" + turnike.IP + "'")[0]["TableId"];
                _table.Rows.RemoveAt(_table.Rows.IndexOf(_table.Select("TurnikeIP = '" + turnike.IP + "'")[0]));
                _table.Rows.Add(tableId, turnike.PerioClass, turnike.TurnikeNo, turnike.IP, turnike);
            }
            catch (Exception ex)
            {
                String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            finally
            {
                Thread listeleThread2 = new Thread(new ThreadStart(Listele));
                listeleThread2.Name = "Listele_BakiyeDusur";
                listeleThread2.Start();

                Thread turnikeThread2 = new Thread(new ThreadStart(TurnikeListele));
                turnikeThread2.Name = "TurnikeListele_BakiyeDusur";
                turnikeThread2.Start();
            }
        }

        private void Listele()
        {
            DBThread db = new DBThread();
            DataTable dtGecisler = db.GecislerGetir();
            
            this.BeginInvoke(new delegDataSource(DataSource), dtGecisler, gridGecisler);
        }

        private void TurnikeListele()
        {
            DBThread db = new DBThread();
            DataTable dtTurnikeler = db.TurnikelerGetir();

            this.BeginInvoke(new delegDataSource(DataSource), dtTurnikeler, gridTurnikeler);
        }
        #endregion

        #region "Events / Timer / Messages"
        private void UptimerElapsed(Object sender, EventArgs e)
        {            
            _elapsed++;
            
            if (_elapsed > 30)
            {
                _uptimer.Stop();
                _elapsed = 0;
				
                Thread turnikeThread3 = new Thread(new ThreadStart(TurnikeListele));
                turnikeThread3.Name = "TurnikeListele_Uptimer";
                turnikeThread3.Start();
				
                Thread checkThread = new Thread(new ThreadStart(Check));
                checkThread.Name = "CheckThread";
                checkThread.Start();
            }
        }

        private void OnClose(object sender, EventArgs e)
        {
            try
            {
                _uptimer.Stop();

                if (_table != null)
                {
                    /*
                    for (Int32 i = 0; i < _table.Rows.Count; i++)
                    {
                        PerioTCPRdrComp perioReader = (PerioTCPRdrComp)_table.Rows[i]["PerioClass"];
                        DataRow tableRow = _table.Select("TurnikeIP = '" + perioReader.IP + "'")[0];
                        Turnike turnike = (Turnike)tableRow["TurnikeClass"];

                        perioReader.ThreadAktif = false;
                        perioReader.DisConnect();                        
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                //String method = this.GetType().Name + ", " + MethodBase.GetCurrentMethod().Name;
                //OnError(this, new ErrorOccuredArgs(method, ex.Message));
            }
            finally
            {
                //this.Close();
                //Application.Exit();
                Environment.Exit(0);
            }
        }

        private void AddLog(String logData)
        {
            txtLogger.AppendText(logData + " -- [" + DateTime.Now.ToLongTimeString() + "]");
            txtLogger.AppendText("\r\n");
            txtLogger.AppendText("-------------------------------------------------------------------------------------\r\n");
            txtLogger.ScrollToCaret();
        }

        private void AddSysLog(String logData)
        {
            sysLog.AppendText(logData + " -- [" + DateTime.Now.ToLongTimeString() + "]");
            sysLog.AppendText("\r\n");
            sysLog.AppendText("-------------------------------------------------------------------------------------\r\n");
            sysLog.ScrollToCaret();
        }

        private void ClearLog()
        {
            txtLogger.Text = "";
        }

        private void GecisLog(String gecisData)
        {
            txtGecisler.AppendText(gecisData + "\r\n");
            txtGecisler.AppendText("Tarih : " + DateTime.Now.ToLongTimeString() + "\r\n");            
            txtGecisler.AppendText("-----------------------------------------------\r\n");
            txtGecisler.ScrollToCaret();
        }

        private void Stats(String stats)
        {
            lblStats.Text = stats;
        }

        private void TurnikeDurum(Boolean durum)
        {

        }

        private void DataSource(DataTable dt, DataGridView grid)
        {
            grid.DataSource = dt;            
        }

        private void OnGecisOldu(Object obj, GecisLoggerArgs gecisLoggerArgs)
        {
            this.BeginInvoke(new deleg(GecisLog), GecisLogger.GecisBilgisi);            
        }

        private void Main_OnError(object sender, ErrorOccuredArgs e)
        {
            this.BeginInvoke(new deleg(AddLog), e.Message);
        }

        private void txtLogger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ClearLog();

                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    AddLog("*** Sistem Aktif ***");
                }
                else
                {
                    AddLog("*** DEBUG modu aktif ***");
                }
            }
        }
        #endregion


        private void TurnikeDurumDegis(object objTurnike)
        {
            DBThread db = new DBThread();
            Turnike turnike = (Turnike)objTurnike;

            if (db.TurnikeDurumDegis(turnike.TurnikeNo) == 100)
            {
                turnike.Aktif = (turnike.Aktif == true) ? false : true;

                Thread checkThread2 = new Thread(new ThreadStart(Check));
                checkThread2.Name = "CheckThread_TurnikeDurum";
                checkThread2.Start();

                Thread listeleThread3 = new Thread(new ThreadStart(Listele));
                listeleThread3.Name = "Listele_TurnikeDurum";
                listeleThread3.Start();

                Thread turnikeThread4 = new Thread(new ThreadStart(TurnikeListele));
                turnikeThread4.Name = "TurnikeListele_TurnikeDurum";
                turnikeThread4.Start();
            }
        }

        private void gridTurnikeler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String IP = "";
            IP = Convert.ToString(gridTurnikeler.Rows[e.RowIndex].Cells["colip"].Value);

            DataRow tableRow = _table.Select("TurnikeIP = '" + IP + "'")[0];
            Turnike turnike = (Turnike)tableRow["TurnikeClass"];

            if (gridTurnikeler.Columns[e.ColumnIndex].DataPropertyName == "AKTIF")
            {
                Thread durumThread = new Thread(new ParameterizedThreadStart(TurnikeDurumDegis));
                durumThread.Name = "TurnikeDurumDegis";
                durumThread.Start(turnike);
            }
        }
    }
}
