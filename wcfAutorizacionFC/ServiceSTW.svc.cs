using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using wcfAutorizacionFC.Content;

namespace wcfAutorizacionFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceSTW : IServiceSTW
    {
        public ValidacionModel Autenficacion(string accion, string usuario, string passwd)
        {
            var dato = DBGeneral.WPL_ValidaUsuarioAutoriza(accion, usuario, passwd);
            var info = new ValidacionModel {Retorno = dato};
            return info;
        }

        public List<ListadoInfoModel> ListadoInfo(string accion, string tipo)
        {
            var ds = DBGeneral.WPA_ActualizaEstadoContrato(accion, tipo, "", "");
            var lst = ds.Tables[0].ToList<ListadoInfoModel>();
            return lst;
        }

        public FinalModel ProcesoFinal(string accion, string tipo, string folio, string usuario)
        {
            var ds = DBGeneral.WPA_ActualizaEstadoContrato(accion, tipo, folio, usuario);
            var dr = ds.Tables[0].Rows[0];
            var info = new FinalModel { Mensaje = dr["Mensaje"].ToString() };
            return info;
        }
    }
}
