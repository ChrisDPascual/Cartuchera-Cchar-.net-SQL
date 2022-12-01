using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCartuchera
{
    public class Sacapuntas : Utiles
    {

        protected int cantidadAgujeros;

        public Sacapuntas(string marca, double precio, string tipo,  int cantidad, int cantAgujeros, int iDU) : base(marca, precio, tipo, cantidad, iDU)
        {
            this.util = "sacapuntas";
            this.cantidadAgujeros = cantAgujeros;
        }



        public int CantidadAgujeros 
        {
            get {return this.cantidadAgujeros; }
            set {this.cantidadAgujeros = value; }
        }
    }
}
