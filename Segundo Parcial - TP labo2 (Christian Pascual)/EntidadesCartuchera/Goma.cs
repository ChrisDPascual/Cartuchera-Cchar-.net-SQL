using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCartuchera
{
    public class Goma : Utiles
    {
        protected string paraLapiz;
        protected string paraTinta;

        public Goma(string marca, double precio, string tipo, int cantidad, bool paraLapiz, bool paraTinta, int iDU) : base(marca, precio, tipo, cantidad, iDU) 
        {
            this.util = "goma";
            this.paraLapiz = SiNO(paraLapiz);
            this.paraTinta = SiNO(paraTinta);
        }

        public string ParaLapiz 
        {
            get {return this.paraLapiz; }
            set {this.paraLapiz = value; }
        }

        public string ParaTinta
        {
            get {return this.paraTinta; }
            set {this.paraTinta = value; }
        }

        public bool BorraLoMismo(Goma g1, Goma g2) 
        {
            bool retorno = false;
            if(g1.ParaTinta == g2.ParaTinta && g1.ParaLapiz == g2.ParaLapiz) 
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
