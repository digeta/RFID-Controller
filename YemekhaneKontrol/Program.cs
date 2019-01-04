using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using YemekhaneKontrol.Misc;

namespace YemekhaneKontrol
{
    static class Program
    {
        private static string appGuid = "94eb47ff-adc0-4616-aecb-defefb15bb9d";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    return;
                }

                if (!ReadSettings()) return;
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
        }

        private static Boolean ReadSettings()
        {
            Boolean result = false;

            try
            {
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }
    }
}


