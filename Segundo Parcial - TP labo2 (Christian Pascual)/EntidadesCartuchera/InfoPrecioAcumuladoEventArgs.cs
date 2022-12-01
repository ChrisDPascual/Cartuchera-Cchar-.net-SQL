using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCartuchera
{
    public class InfoPrecioAcumuladoEventArgs : EventArgs
    {
        public double precioAcumulado;

        public InfoPrecioAcumuladoEventArgs(double total) 
        {
            this.precioAcumulado = total;
        }

    }

    public class InfoSinTintaEventArgs : EventArgs
    {
        public int tintaFaltante;

        public InfoSinTintaEventArgs(int cantidadDisponible, int cantidadAUsar)
        {
            this.tintaFaltante = cantidadAUsar - cantidadDisponible;   
        }

    }
}
