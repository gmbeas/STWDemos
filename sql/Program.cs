using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;


namespace sql
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceController service = new ServiceController("MSSQLSERVER");//Check 
            ServiceController service2 = new ServiceController("SQLSERVERAGENT");

            var tt = service.Status;
            var xx = service2.Status;


            if(service.Status == ServiceControllerStatus.Running)
            {
                service.Stop();
                service.Refresh();
                Thread.Sleep(3000);
                if(service.Status == ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        var au = DbGeneral.ReduceFastFast();
                    }
                    catch (Exception e)
                    {
                        
                       Console.WriteLine(e.ToString());
                    }
                    
                }

            }


            Thread.Sleep(5000);
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                service.Start();
                service.Refresh();
            }

            if(service2.Status == ServiceControllerStatus.Stopped)
            {
                service2.Start();
                service2.Refresh();
            }

        }
    }
}
