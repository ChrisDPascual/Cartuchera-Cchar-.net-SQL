using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace EntidadesCartuchera
{

    public sealed class Cartuchera<T> where T : Utiles
    {
        public delegate void NotificadorPrecioSuperior(Cartuchera<T> cartuchera, InfoPrecioAcumuladoEventArgs infoAcumulado);
        public event NotificadorPrecioSuperior precioSuperior;

        private string duenio;
        private int capacidad;
        private double precioTotal;
        private List<T> listadoUtiles;
        private int iD;

        public Cartuchera()
        {
            this.listadoUtiles = new List<T>();
        }


        public Cartuchera(string duenio, int ID) : this()
        {
            this.duenio = duenio;
            this.iD = ID;

        }

        public Cartuchera(string duenio, int ID, double precioTotal, int capacidad) :this(duenio, ID)
        {
            this.precioTotal = precioTotal;
            this.capacidad = capacidad;
        }


        public List<T> ListadoUtiles
        {
            get { return this.listadoUtiles; }
            set { this.listadoUtiles = value; }
        }
        public string Duenio
        {
            get { return this.duenio; }
            set { this.duenio = value; }
        }

        public int ID 
        {
            get {return this.iD; }
            set {this.iD = value; }
        }
        public int Capacidad
        {
            get { return this.capacidad; }
            set { this.capacidad = value; }
        }

        public double PrecioTotal
        {
            get { return this.precioTotal; }
            set { this.precioTotal = value; }
        }

        public int GenerarNroRandom(List<Cartuchera<Utiles>> ListadoCartucheras)
        {
            int retorno = 0;
            int bandera = 1;
            Random rnd = new Random();

            if(ListadoCartucheras.Count>0) 
            {  
                do
                {
                    bandera = 1;
                    retorno = rnd.Next(1000, 9999);
                    foreach (var item in ListadoCartucheras) 
                    {

                        if (item.ID == retorno) 
                        {
                            bandera = 0;
                            break;
                        }
                    }
                    
                } while (bandera == 0);
                              
            }
            else 
            {
                retorno = rnd.Next(1000, 9999);              
            }

            return retorno;
        }

        public static bool operator ==(Cartuchera<T> c1, Cartuchera<T> c2)
        {
            bool retorno = false;

            if (c1.ID == c2.ID)
            {
                retorno = true;
            }

            return retorno;
        }
        public static bool operator !=(Cartuchera<T> c1, Cartuchera<T> c2)
        {
            return !(c1 == c2);
        }

        public Cartuchera<Utiles> BuscarCartucheraID(List<Cartuchera<Utiles>> ListadoCartucheras, int ID) 
        {
            Cartuchera<Utiles> cartuchera = new Cartuchera<Utiles>();

            if(ListadoCartucheras.Count>0 && ID > 0) 
            {
                foreach(var item in ListadoCartucheras) 
                {
                    if(item.ID == ID) 
                    {
                        cartuchera = item;
                        break;
                    }
                }
            }

            return cartuchera;
        }
        
        public bool ExisteLaCartuchera(List<Cartuchera<Utiles>> ListadoCartucheras, Cartuchera<Utiles> cartuchera) 
        {
            bool retorno = false;

            if(ListadoCartucheras is not null && cartuchera is not null) 
            {
                foreach(Cartuchera<Utiles> item in ListadoCartucheras) 
                {
                    if(item == cartuchera) 
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

       
        private bool SeEncuentraElUtilEnLaCartuchera(Cartuchera<T> cartuchera, T util) 
        {
            bool retorno = false;

            if (cartuchera is not null && util is not null) 
            {
                foreach(Utiles item in cartuchera.listadoUtiles) 
                {
                    if(item == util) 
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public int AnexarIDUtil(Cartuchera<T> cartuchera) 
        {
            int retorno = -1;

            if(cartuchera is not null) 
            {
                retorno = cartuchera.ID;
            }

            return retorno;
        }

        public static bool operator +(Cartuchera<T> cartuchera, T util) 
        {
           bool retorno = false;

            if (cartuchera is not null && util is not null) 
            {
                if (cartuchera.AgregarUtil(cartuchera, util))
                {
                      retorno = true;
                  
                }
            }
                return retorno;
        }

        public static explicit operator Cartuchera<Utiles>(Cartuchera<T> cartuchera)
        {
            Cartuchera<Utiles> retorno = new Cartuchera<Utiles>();

            if (cartuchera is not null)
            {
                retorno.Duenio = cartuchera.Duenio;
                retorno.ID = cartuchera.ID;
                retorno.capacidad = cartuchera.Capacidad;
                retorno.PrecioTotal = cartuchera.PrecioTotal;
                foreach(Utiles item in cartuchera.ListadoUtiles) 
                {
                    retorno.ListadoUtiles.Add(item);
                }
            }

            return retorno;
        }

        public double CalcularTotal(Cartuchera<T> cartuchera) 
        {
            double sumador = 0;
            double acumulador = 0;

            if(cartuchera is not null) 
            {
                foreach(Utiles item in cartuchera.ListadoUtiles)
                {
                    sumador = (item.Precio * item.Cantidad);
                    acumulador = acumulador + sumador;
                    sumador = 0;
                }
            }

            return acumulador;

        }

        public int CalucularMercaderiaAcumulada(Cartuchera<T> cartuchera)
        {
            int sumador = 0;
            int acumulador = 0;

            if (cartuchera is not null)
            {
                foreach (Utiles item in cartuchera.ListadoUtiles)
                {
                    sumador = item.Cantidad;
                    acumulador = acumulador + sumador;
                    sumador = 0;
                }
            }

            return acumulador;

        }

        public bool AgregarUtil(Cartuchera<T> cartuchera, T util)
        {

            bool retorno = false;
            int acumulacion = 0;


            if(cartuchera is not null && util is not null) 
            {
                if (cartuchera.SeEncuentraElUtilEnLaCartuchera(cartuchera,util)) 
                {
                    foreach(Utiles item in cartuchera.listadoUtiles) 
                    {
                        if(item == util) 
                        {
                            acumulacion = item.Cantidad;

                            if(acumulacion < 20 && acumulacion+util.Cantidad <=20) 
                            {
                                item.Cantidad = acumulacion+util.Cantidad;
                                item.Precio = item.Precio;
                                cartuchera.capacidad = cartuchera.CalucularMercaderiaAcumulada(cartuchera);
                                cartuchera.PrecioTotal = cartuchera.CalcularTotal(cartuchera);                                
                                SQLClass.ModificarUtil((Cartuchera<Utiles>)cartuchera, item);

                                retorno = true;
                                break;
                            }
                        }
                    }
                }
                else 
                {
                    acumulacion = cartuchera.CalucularMercaderiaAcumulada(cartuchera);

                    if (acumulacion<20 && acumulacion+util.Cantidad <= 20) 
                    {
                        cartuchera.listadoUtiles.Add(util);
                        cartuchera.capacidad = util.Cantidad;
                        cartuchera.capacidad = cartuchera.CalucularMercaderiaAcumulada(cartuchera);
                        cartuchera.PrecioTotal = cartuchera.CalcularTotal(cartuchera);
                        util.IDU = cartuchera.ID;
                        SQLClass.GuardarUtil((Cartuchera<Utiles>)cartuchera,util);
                        retorno = true;
                    }
                }
            }

            return retorno;
        }
        
        public void Ejecutar(Cartuchera<T> cartuchera)
        {
            double acumulador = 0;
            double sumador = 0;

            
            if(cartuchera is not null)
             {
  
               Thread.Sleep(100);

               foreach(Utiles util in cartuchera.ListadoUtiles) 
               {
                    acumulador = util.Precio * util.Cantidad;
                    sumador = acumulador + sumador;
                    acumulador = 0;
               }
                Thread.Sleep(100);

                if (sumador >= 500)
               {
                   InfoPrecioAcumuladoEventArgs infoAcumulado = new InfoPrecioAcumuladoEventArgs(sumador);
                   this.precioSuperior.Invoke( this, infoAcumulado);                 
               }
               this.precioTotal = sumador;

            }

        }

       

        public bool EstaEnLaLista(Cartuchera<T> cartuchera, List<Cartuchera<Utiles>> ListadoCartucheras)
        {
            bool retorno = false;

            if (cartuchera is not null) 
            {
                foreach(var item in ListadoCartucheras) 
                {
                    if(item.ID == cartuchera.ID) 
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }

        public bool ISerializaXML() 
        {
            bool retorno = false;
            Lapiz lapiz = new Lapiz();
            List<Lapiz> listaLapices = SQLClass.retornarLapices();

            if (listaLapices.Count > 0)
            {
                lapiz.SerializarXml(listaLapices);
                retorno = true;
            }
            return retorno;
        }

        public List<Lapiz> IDeserializacionXML() 
        { 
           StringBuilder retorno = new StringBuilder();
            Lapiz lapiz = new Lapiz();
            List<Lapiz> listaLapices = new List<Lapiz>();
     
            if ((listaLapices=lapiz.DeserializarXml()) is not null)
            {
                if (listaLapices.Count > 0) 
                {
                    return listaLapices;
                }
            }


            return null;
        }

        public bool ISerializaJSON()
        {
            bool retorno = false;
            Lapiz lapiz = new Lapiz();
            List<Lapiz> listaLapices = SQLClass.retornarLapices();

            if(listaLapices.Count>0) 
            {
                lapiz.SerializarJson(listaLapices);
                retorno = true;
            }
            return retorno;
        }

        public List<Lapiz> IDeserializaJSON()
        {

            StringBuilder retorno = new StringBuilder();
            Lapiz lapiz = new Lapiz();
            List<Lapiz> listaLapices = new List<Lapiz>();

            if ((listaLapices = lapiz.DeserializarJson()) is not null)
            {
                if (listaLapices.Count > 0)
                {
                    return listaLapices;
                }
            }


            return null;

        }

        public bool ExisteLaRutaJSON()
        {
            bool retorno = false;
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lapiz.json");

            if (File.Exists(ruta))
            {
                retorno = true;
            }

            return retorno;

        }

        public bool ExisteLaRutaXML() 
        {
            bool retorno = false;
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lapiz.xml");

            if (File.Exists(ruta))
            {
                retorno = true;
            }

            return retorno;
            
        }

        public bool HayLapices(List<Cartuchera<Utiles>> ListadoCartucheras) 
        {
            bool retorno = false;
            if (ListadoUtiles is not null)
            {
                foreach (Cartuchera<Utiles> cartu in ListadoCartucheras) 
                { 
                   foreach (Utiles item in cartu.ListadoUtiles)
                   {
                      if (item.Util == "lapiz")
                      {
                        retorno = true;
                        break;
                      }
                   } 
                }
            }
            return retorno;
        }

    }
}
