using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCartuchera
{
    public abstract class Utiles
    {
        protected string util;
        protected string marca;
        protected double precioUnitario;
        protected string estilo;//infantil o profesional
        private int cantidad;
        private int iDU;

        public Utiles()
        {

        }
        public Utiles(string marca,double precio, string estilo, int cantidad, int iDU) 
        {
            this.marca = marca;
            this.precioUnitario = precio;
            this.estilo = estilo;
            this.cantidad = cantidad;
            this.iDU = iDU;
        }

        public string Util
        {
            get { return this.util; }
            set { this.util = value; }
        }
        public string Marca 
        {
            get {return this.marca; }
            set {this.marca = value; }
        }

        public double Precio
        {
            get { return this.precioUnitario; }
            set { this.precioUnitario = value; }
        }

        public string Estilo
        {
            get { return this.estilo; }
            set { this.estilo = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }
        public int IDU 
        {
            get {return this.iDU; }
            set {this.iDU = value; }
        }
        protected string SiNO(bool valor)
        {
            string retorno = string.Empty;

            if (valor is true) { retorno = "si"; }
            else { retorno = "no"; }

            return retorno;
        }

        public static bool operator ==(Utiles t1, Utiles t2)
        {
            bool retorno = false;

            if(t1 is not null && t2 is not null) 
            {
                if(t1.Marca == t2.Marca && t1.Estilo == t2.Estilo && t1.Util == t2.Util) 
                {
                    if(((Lapiz)t1).Color == ((Lapiz)t2).Color || ((Sacapuntas)t1).CantidadAgujeros == ((Sacapuntas)t2).CantidadAgujeros || ((Goma)t1).BorraLoMismo(((Goma)t1), ((Goma)t2))) 
                    {
                        retorno = true;
                    }
                    
                }
            }

            return retorno;
        }

        public static bool operator !=(Utiles t1, Utiles t2)
        {
            return !(t1 == t2);
        }

        public override string ToString()
        {
            return $"{this.Util}  marca: {this.Marca} precio: {this.Precio} estilo: {this.Estilo} cantidad: {this.Cantidad}";
        }

       
    }
}
