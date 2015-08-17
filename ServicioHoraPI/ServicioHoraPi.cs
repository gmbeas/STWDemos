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
using ServicioHoraPI.Clases;

namespace ServicioHoraPI
{
    public partial class ServicioHoraPi : ServiceBase
    {
        private Timer _ciclo = null;
        public ServicioHoraPi()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _ciclo = new Timer();
          
            this._ciclo.Interval = (2 * 60000); //every 5min
            this._ciclo.Elapsed += this._ciclo_Tick;
            _ciclo.Enabled = true;
            Log.WriteErrorLog("Servicio correccion hora servidor Pi iniciado! cada " + 2 + " minutos.");
        }

        private void _ciclo_Tick(object sender, ElapsedEventArgs e)
        {
            //Write code here to do some job depends on your requirement
            //Log.WriteErrorLog("Timer ticked and some job has been done successfully");
            try
            {
                var cambioHora = new SNTPClient("ntp.shoa.cl"); // INICIALIZA
                cambioHora.Connect(true); //ENVIA CAMBIO HORA
                Log.WriteErrorLog("SE CAMBIO HORA");
            }
            catch (Exception ex)
            {
                Log.WriteErrorLog("ERROR: " + ex.ToString());
            }
            
        }

        protected override void OnStop()
        {
            _ciclo.Enabled = false;
            Log.WriteErrorLog("Servicio correccion hora servidor Pi DETENIDO!");
        }
    }
}
