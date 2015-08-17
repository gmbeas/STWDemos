using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using GpsServer.Clases;

namespace GpsServer
{
    public partial class GpsServer : ServiceBase
    {

        private Timer timer1 = null;
        public GpsServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var server = new TcpServer(5001);

            timer1 = new Timer();
            this.timer1.Interval = 30000; //every 30 secs
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.Enabled = true;
            Log.WriteErrorLog("Test window service started");
        }

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            //Write code here to do some job depends on your requirement
            Log.WriteErrorLog("Timer ticked and some job has been done successfully");
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            Log.WriteErrorLog("Test window service stopped");
        }
    }
}
