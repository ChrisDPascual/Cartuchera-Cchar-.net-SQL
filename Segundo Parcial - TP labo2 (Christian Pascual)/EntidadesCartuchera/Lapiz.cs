using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Threading;

namespace EntidadesCartuchera
{
    public class Lapiz : Utiles
    {
        private string color;

        public Lapiz() 
        {
        }
        
        public Lapiz(string marca, double precio, string tipo, int cantidad, string color, int iDU) : base(marca, precio, tipo, cantidad,iDU) 
        {
            this.util = "lapiz";
            this.color = color;
        } 

        public string Color 
        {
            get {return this.color; }
            set { this.color = value; }
        }

        public void SerializarXml(List<Lapiz> lapiz)
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lapiz.xml");

            if(Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            using (StreamWriter serializador = new StreamWriter(ruta))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lapiz>));
                xmlSerializer.Serialize(serializador, lapiz);
                
            }

        }

        public List<Lapiz> DeserializarXml()
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lapiz.xml");
            List<Lapiz> lapices = new List<Lapiz>();
            Lapiz lapiz = new Lapiz();

            try
            {
                if (Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                using (StreamReader deserializador = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lapiz>));

                    lapices = xmlSerializer.Deserialize(deserializador) as List<Lapiz>;

                }
            }
            catch (FileNotFoundException) 
            {
                lapices = null;
            }

             return lapices;
        }

        public void SerializarJson(List<Lapiz> lapices)
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lapiz.json");

            if (Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            JsonSerializerOptions opciones = new JsonSerializerOptions();
             opciones.WriteIndented = true;
             string objJson = JsonSerializer.Serialize(lapices, opciones);

            File.WriteAllText(ruta, objJson);
             
            
            

        }

        public List<Lapiz> DeserializarJson()    //lo puedo ahcer generico
        {
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lapiz.json");
            List<Lapiz> lapices = new List<Lapiz>();
            Lapiz lapiz = new Lapiz();

            try
            {
                if (Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }

                string objetoJson = File.ReadAllText(ruta);
                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;
                lapices = JsonSerializer.Deserialize<List<Lapiz>>(objetoJson, opciones);
            }
            catch (FileNotFoundException)
            {
                lapices = null;
            }

            return lapices;

            /*
               string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "lapiz.json");
               List<Lapiz> lapices = new List<Lapiz>();

               if (Directory.Exists(ruta))
               {
                   Directory.CreateDirectory(ruta);
               }

                   string objetoJson = File.ReadAllText(ruta);
                   JsonSerializerOptions opciones = new JsonSerializerOptions();
                   opciones.WriteIndented = true;
                   lapices = JsonSerializer.Deserialize<List<Lapiz>>(objetoJson, opciones);


               return lapices;*/


        }

        public override string ToString()
        {
            return $"{this.Util}\tcolor: {this.color}\tmarca: {this.Marca}\tprecio: {this.Precio}\testilo: {this.Estilo}\tcantidad: {this.Cantidad}";
        }

        
    }
}
