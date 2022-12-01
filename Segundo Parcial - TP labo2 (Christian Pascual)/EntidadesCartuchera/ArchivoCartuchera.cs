using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EntidadesCartuchera
{
    public class ArchivoCartuchera
    {

        public string LeerTicketEvento()
        {
            string texto = string.Empty;
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tickets.log");

            using (StreamReader lector = new StreamReader(ruta)) 
            {
                texto = lector.ReadToEnd();
                
            }
            
            if(string.IsNullOrWhiteSpace(texto))
            {
                texto = "no hay venta realizadas";
            }

            return texto;

        }

        public void EscribirTicketEvento(string evento, Cartuchera<Utiles> cartuchera)
        {

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "tickets.log");

            using (StreamWriter escribirArchivo = new StreamWriter(ruta,true))
            {
                if( evento is not null)
                {
                    escribirArchivo.WriteLine(evento + $" perteneciente a {cartuchera.Duenio}");
                    foreach(Utiles util in cartuchera.ListadoUtiles) 
                    {
                        escribirArchivo.WriteLine(util.ToString());
                    }

                }


            }
        }

        public void EscribirSinTIntaEvento(string evento)
        {

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "errors.log");

            using (StreamWriter escribirArchivo = new StreamWriter(ruta,true))
            {
                if (evento is not null)
                {
                    escribirArchivo.WriteLine(evento);

                }

            }
        }
    }
}
