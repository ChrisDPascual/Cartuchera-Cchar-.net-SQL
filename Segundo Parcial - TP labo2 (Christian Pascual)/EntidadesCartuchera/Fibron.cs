using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntidadesCartuchera
{
    public class Fibron : Lapiz
    {
        public delegate void NotificadorSinTinta(Fibron fibron, InfoSinTintaEventArgs infoSinTinta);
        public event NotificadorSinTinta noAlcanzaLaTinta;
        private int cantidadTinta;
        
        public Fibron(string marca, double precio, string tipo, int cantidad, string color, int iDU,int cantidadTinta) : base(marca, precio, tipo, cantidad, color,iDU) 
        {
            this.Util = "fibron";
            this.cantidadTinta = cantidadTinta;
        }

        public int CantidadTinta 
        {
            get { return this.cantidadTinta; }
            set { this.cantidadTinta = value; }
        }

        public bool Resaltar(int cantidad)
        {
            int acumulador;
            bool retorno = false;



                if (this.cantidadTinta < cantidad)
                {
                    InfoSinTintaEventArgs infoTinta = new InfoSinTintaEventArgs(this.cantidadTinta, cantidad);
                    this.noAlcanzaLaTinta.Invoke(this, infoTinta);
                    this.cantidadTinta = 0;
                }
                else
                {
                    retorno = true;
                    acumulador = this.cantidadTinta - cantidad;
                    this.cantidadTinta = acumulador;
                    
                }

            return retorno;

        }
    }
}
