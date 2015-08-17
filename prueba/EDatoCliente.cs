using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba
{
    public class EDatoCliente
    {
        private string _rut;
        private string _nombre;
        private string _email;

        public EDatoCliente() { }

        public EDatoCliente(string rut, string nombre, string email)
        {
            _rut = rut;
            _nombre = nombre;
            _email = email;
        }

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public virtual string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public virtual string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }
    }
}
