using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesCartuchera;
using System.Threading.Tasks;
using System.Threading;

namespace Pascual.Christian.SPLabII
{ 
    public partial class FRMCartuchera : Form
    {
        private List<Cartuchera<Utiles>> listadoCartucheras;
        private Cartuchera<Utiles> laCartuchera;
        private Cartuchera<Utiles> cartucheraFibrones;

        public FRMCartuchera()
        {
            InitializeComponent();
            this.laCartuchera = new Cartuchera<Utiles>();
            this.listadoCartucheras = new List<Cartuchera<Utiles>>();
            this.cartucheraFibrones = new Cartuchera<Utiles>();
            Fibron f1 = new Fibron("Pizzini", 50,"escolar", 1, "rojo", 12, 4);
            Fibron f2 = new Fibron("Maped", 25, "escolar", 1, "amarillo", 12, 7);
            Fibron f3 = new Fibron("Sharpie", 150, "profesional", 1, "verde", 12, 10);
            this.cartucheraFibrones.ListadoUtiles.Add(f1);
            this.cartucheraFibrones.ListadoUtiles.Add(f2);
            this.cartucheraFibrones.ListadoUtiles.Add(f3);


        }

        private void BTAgregarUtil_Click(object sender, EventArgs e)
        {
            
            FRMAgregarUtiles agregarUtiles = new FRMAgregarUtiles(this.listadoCartucheras);
            agregarUtiles.ShowDialog();
          
        }

        private void BTVerTickets_Click(object sender, EventArgs e)
        {
            FRMListadoTickets listadoTickets = new FRMListadoTickets();

            listadoTickets.ShowDialog();
        }

        private void BTSerializarJson_Click(object sender, EventArgs e)
        {
            if (this.laCartuchera.ISerializaJSON()) 
            {
                MessageBox.Show("Fue serializado con exito");
            }
            else
            {
                MessageBox.Show("No hay lapices en la cartuchera");
            }

        }

        private void BTDeserializarJson_Click(object sender, EventArgs e)
        {
 
            List<Lapiz> listadoLapices = this.laCartuchera.IDeserializaJSON();

            if (listadoLapices is not null)
            {

                FRMdeserializar mostrar = new FRMdeserializar(listadoLapices);
                mostrar.ShowDialog();

            }
            else
            {
                MessageBox.Show("No hay lapices para Deserializar");
            }

        }

        private void BTSerializarXML_Click(object sender, EventArgs e)
        {
            if (this.laCartuchera.ISerializaXML())
            {
                MessageBox.Show("Fue serializado con exito");
            }
            else
            {
                MessageBox.Show("No hay lapices en la cartuchera");
            }
 
        }

        private void BTDeserializarXML_Click(object sender, EventArgs e)
        {
            StringBuilder texto = new StringBuilder();
            List<Lapiz> listadoLapices = this.laCartuchera.IDeserializacionXML();

            if (listadoLapices is not null)
            {

                FRMdeserializar mostrar = new FRMdeserializar(listadoLapices);
                mostrar.ShowDialog();

            }
            else 
            {
                MessageBox.Show("No hay lapices para Deserializar");
            }
        }
        public string listado() 
        {
            StringBuilder texto = new StringBuilder();
            foreach(var cartu in this.listadoCartucheras) 
            {
                foreach(var item in cartu.ListadoUtiles) 
                {
                    texto.AppendLine(item.ToString());
                } 
            }
            return texto.ToString();
        }

        private void Refrescar() 
        {
            List<Cartuchera<Utiles>> listado = new List<Cartuchera<Utiles>>();

            listado = SQLClass.LeerCartucheras();

            if(listado is not null)
            { 
            this.DVGCartucheras.DataSource = listado;
            Thread.Sleep(100);
            this.DVGCartucheras.ClearSelection();
            this.DVGCartucheras.Update();
            this.DVGCartucheras.Refresh();
            }
            else 
            {
                MessageBox.Show("ocurrio un error inesperado");
            }
        }


        private void DVGCartucheras_MouseClick(object sender, MouseEventArgs e)
        {

            try
            {

                if (this.DVGCartucheras.SelectedRows.Count > 0)
                {
                    Cartuchera<Utiles> cartuchera = (Cartuchera<Utiles>)this.DVGCartucheras.CurrentRow.DataBoundItem;
                    List<Utiles> listaUtiles = new List<Utiles>();
                    listaUtiles = SQLClass.LeerUtiles(cartuchera);

                    this.DVGCartucheras.ClearSelection();
                    this.DGVUtiles.DataSource = listaUtiles;
                    this.DGVUtiles.Update();
                    this.DGVUtiles.Refresh();
                    Refrescar();
                }
                else 
                {                
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                Refrescar();
                MessageBox.Show("Seleccione una fila valida");

            }
      

        }


        private void BORRARTODO_Click(object sender, EventArgs e)
        {
            SQLClass.EliminarTodo();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {   
             Timer.Start();
             this.DVGCartucheras.DataSource = await ActualizarData.TraerRegristros();        
        }

        private void button7_Click(object sender, EventArgs e)
        {

            DialogResult respuesta = MessageBox.Show("Desea cerrar el program", "Cartuchera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == respuesta) 
            {
                Dispose();
            }

        }

        public void MostrarCantidadTintaFaltante(Fibron fibra, InfoSinTintaEventArgs tinta)
        {
            string alerta = string.Empty;
            ArchivoCartuchera archivo = new ArchivoCartuchera();

            alerta = $"El fibron {fibra.Marca} tiene {fibra.CantidadTinta}, necesitaba usar {tinta.tintaFaltante+fibra.CantidadTinta} y la cantidad de tinta faltante es de {tinta.tintaFaltante}";
            archivo.EscribirSinTIntaEvento(alerta);
            MessageBox.Show(alerta);


        }
        private void BTFibron_Click(object sender, EventArgs e)
        {
            Random elejir = new Random();
            int tintaAGastar = elejir.Next(1, 10);
            Fibron fibron = (Fibron)this.cartucheraFibrones.ListadoUtiles.ElementAt(elejir.Next(0, 3));
            fibron.noAlcanzaLaTinta += MostrarCantidadTintaFaltante;

            try
            {
                if (fibron.Resaltar(tintaAGastar))
                {
                    MessageBox.Show($"el fibron {fibron.Marca} gasto {tintaAGastar} y todavia tiene {fibron.CantidadTinta} de tinta restante");
                }
                else 
                {
                    throw new SinTintaException("El fibron ya no tiene tinta");
                }
            }
            catch(SinTintaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                fibron.noAlcanzaLaTinta -= MostrarCantidadTintaFaltante;
            }
        }
    }
}
