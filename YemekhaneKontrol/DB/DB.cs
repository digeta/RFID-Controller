using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace YemekhaneKontrol.DB
{
    public static class DB
    {
        public static Boolean InitDB()
        {
            Boolean sonuc = false;

            try
            {
                if(AyarlarOku() && CihazListesi())
                sonuc = true;
            }
            catch (Exception ex)
            {
                sonuc = false;
            }
            return sonuc;
        }

        public static Boolean AyarlarOku()
        {
            Boolean result = false;
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn.ConnectionString = Settings.ConnectionStrLocal;

                String sqlStr = "SELECT * FROM AYARLAR";
                SqlCommand sqlComm = new SqlCommand(sqlStr, sqlConn);

                if (sqlConn.State != System.Data.ConnectionState.Open) sqlConn.Open();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable();
                sqlAdapter.Fill(dt);

                Settings.Ayarlar = dt;

                if (dt.Rows.Count > 0)
                {
                    Settings.YemekhaneID = Convert.ToInt32(Settings.Ayarlar.Rows[0]["YEMEKHANE_ID"]);
                    result = true;
                }               
            }
            catch (Exception ex)
            {
                Logger.DBnoLog = true;
                Logger.isError = true;
                Logger.Method = "DB, AyarlarOku";
                Logger.Message = ex.Message;
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed) sqlConn.Close();
            }
            return result;
        }

        public static Boolean CihazListesi()
        {
            Boolean result = false;
            SqlConnection sqlConn = new SqlConnection();

            DataTable ayarlar = Settings.Ayarlar;

            try
            {
                sqlConn.ConnectionString = Settings.ConnectionStrLocal;

                String sqlStr = "SELECT * FROM TURNIKELER WHERE YEMEKHANE_ID = @YEMEKHANE_ID";
                SqlCommand sqlComm = new SqlCommand(sqlStr, sqlConn);
                sqlComm.Parameters.AddWithValue("YEMEKHANE_ID", Settings.YemekhaneID);

                if (sqlConn.State != System.Data.ConnectionState.Open) sqlConn.Open();

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlComm);
                DataTable dt = new DataTable();
                sqlAdapter.Fill(dt);

                Settings.Turnikeler = dt;

                if (dt.Rows.Count > 0) result = true;
            }
            catch (Exception ex)
            {
                Logger.DBnoLog = true;
                Logger.isError = true;
                Logger.Method = "DB, CihazListesi";
                Logger.Message = ex.Message;
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed) sqlConn.Close();
            }
            return result;
        }

        public static void LogKaydiYap()
        {
            Thread logThread = new Thread(new ThreadStart(Logla));
            logThread.Start();
        }

        private static void Logla()
        {
            SqlConnection sqlConn = new SqlConnection();

            try
            {
                sqlConn.ConnectionString = Settings.ConnectionStrLocal;

                String sqlStr = "INSERT INTO YEMEK_LOG (ACIKLAMA, KAYIT_ID, METHOD, HATA, TARIH) VALUES(@ACIKLAMA, @KAYIT_ID, @METHOD, @HATA, GETDATE())";
                SqlCommand sqlComm = new SqlCommand(sqlStr, sqlConn);
                
                sqlComm.Parameters.AddWithValue("ACIKLAMA", Logger.Message);
                sqlComm.Parameters.AddWithValue("KAYIT_ID", Logger.KayıtID);
                sqlComm.Parameters.AddWithValue("METHOD", Logger.Method);
                sqlComm.Parameters.AddWithValue("HATA", Logger.isError);
                
                if (sqlConn.State != System.Data.ConnectionState.Open) sqlConn.Open();

                Int32 inserted = sqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.DBnoLog = true;
                Logger.isError = true;
                Logger.Method = "DB, Logla";
                Logger.Message = ex.Message;
            }
            finally
            {
                if (sqlConn.State != System.Data.ConnectionState.Closed) sqlConn.Close();
            }
            
        }
    }
}
