using System;

using YemekhaneKontrol.Perio;

namespace YemekhaneKontrol.Misc
{
    public class Timez : System.Timers.Timer
    {
        private PerioTCPRdrComp _okuyucu;
        private Int32 _elapsed = 0;

        public PerioTCPRdrComp Okuyucu
        {
            get
            {
                return _okuyucu;
            }
            set
            {
                _okuyucu = value;
            }
        }

        public Int32 ElapsedTime
        {
            get
            {
                return _elapsed;
            }
            set
            {
                _elapsed = value;
            }
        }

        public Timez()
        {
            this.Elapsed += new System.Timers.ElapsedEventHandler(TimeElapsed);
        }

        public void TimeElapsed(Object sender, EventArgs e)
        {
            _elapsed++;
        }
    }
}
