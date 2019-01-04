using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using YemekhaneKontrol.DB;

namespace YemekhaneKontrol.Misc
{    
    public class Fis
    {
        private PrintDocument _printDocument;
        private PrintPreviewDialog _printPreviewDialog;
        private PrinterSettings _printSettings;

        private String _anaBaslik = "BEUN";
        private String _altBaslik = "BAKİYE HARCAMA FİŞİ";

        private StringFormat _strOrtala;
        private StringFormat _strUzak;
        private StringFormat _strYakin;

        private Font _font_0 = new Font("Calibri", 10f, FontStyle.Italic);
        private Font _font_1 = new Font("Calibri", 16f, FontStyle.Bold);

        private Font _fontLogoCaption = new Font("Eurostile Bold", 10f, FontStyle.Italic);
        private Font _fontLogoText = new Font("Eurostile", 9f, FontStyle.Regular);

        public Boolean FisHazirla(Kisi kisi)
        {
            Boolean fisHazir = false;

            try
            {
                String kartId = string.Format("{0}", kisi.KartID);
                String kartSahibi = string.Format("{0}", kisi.Ad + " " + kisi.Soyad);
                String tutar = string.Format("{1}{0:c}", kisi.Ucret, (kisi.Ucret > 0 ? "" : ""));
                String bakiyeYeni = string.Format("{0:c}", kisi.KalanBakiye);

                _strOrtala = new StringFormat();
                _strOrtala.Alignment = StringAlignment.Center;

                _strUzak = new StringFormat();
                _strUzak.Alignment = StringAlignment.Far;

                _strYakin = new StringFormat();
                _strYakin.Alignment = StringAlignment.Near;

                if (_printDocument == null)
                {
                    _printDocument = new PrintDocument();
                    _printDocument.DefaultPageSettings.PaperSource.SourceName = "A8";
                    
                    _printDocument.PrintPage += new PrintPageEventHandler((object sender, PrintPageEventArgs e) =>
                    {   
                        Graphics graphics=e.Graphics;

                        float scaleX = 180f / graphics.DpiX;
                        float scaleY = 180f / graphics.DpiY;

                        graphics.ScaleTransform(scaleX,scaleY*0.7f);

                        graphics.DrawImage(Properties.Resources.Logo, 0, 30, 100, 130);

                        graphics.DrawString(_altBaslik, _font_1, Brushes.Black, 140f, 0f, _strOrtala);
                        graphics.DrawString("Tarih:", _font_0, Brushes.Black, 105f, 30f, _strYakin);
                        graphics.DrawString("Kart Sahibi :", _font_0, Brushes.Black, 105f, 50f, _strYakin);                        
                        graphics.DrawString("Harcanan:", _font_0, Brushes.Black, 105f, 90f, _strYakin);
                        graphics.DrawString("Kalan Bakiye:", _font_0, Brushes.Black, 105f, 110f, _strYakin);
                        graphics.DrawString("Afiyet Olsun", _font_0, Brushes.Black, 105f, 130f, _strYakin);
                        graphics.DrawString(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), _font_0, Brushes.Black, 270f, 30f, _strUzak);
                        graphics.DrawString(kartId, _font_0, Brushes.Black, 270f, 50f, _strUzak);
                        graphics.DrawString(kartSahibi, _font_0, Brushes.Black, 270f, 70f, _strUzak);
                        graphics.DrawString(tutar, _font_0, Brushes.Black, 270f, 90f, _strUzak);
                        graphics.DrawString(bakiyeYeni, _font_0, Brushes.Black, 270f, 110f, _strUzak);
                        graphics.DrawString("--- Mali değeri yoktur. ---", _font_0, Brushes.Black, 140f, 150f, _strOrtala);
                        graphics.DrawString("BEU", _fontLogoCaption, Brushes.Black, 154, 174f, _strYakin);
                        graphics.DrawString("tomasyon", _fontLogoText, Brushes.Black, 211, 174f, _strYakin);
                        graphics.DrawImage(Properties.Resources.beuto, 190, 166, 22, 27);
                    });
                }

                if (_printPreviewDialog == null)
                {
                    _printPreviewDialog = new PrintPreviewDialog()
                    {
                        Document = _printDocument
                    };
                }
                
                fisHazir = true;
            }
            catch(Exception ex)
            {
                fisHazir = false;
            }
            return fisHazir;
        }

        public void FisOnizleme()
        {
            if (_printPreviewDialog!= null)
            {
                //_printPreviewDialog.Show();
                PrinterSettings.PaperSourceCollection psc = _printSettings.PaperSources;
                
            }
        }

        public void FisVer()
        {
            if (_printDocument != null)
            {
                _printDocument.Print();
            }
        }
    }
}
