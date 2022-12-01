using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesCartuchera;

namespace Pascual.Christian.SPLabII
{
    public partial class FRMAgregarUtiles : Form
    {
        private List<Cartuchera<Utiles>> lasCartucheras;
        public FRMAgregarUtiles(List<Cartuchera<Utiles>> cartuchera)
        {
            InitializeComponent();
            AgregarColores();
            AgregarMarcas();
            cambiarVisibilidad();
            this.TboxSecretID.Visible = false;
            this.lasCartucheras = cartuchera;

        }

        public void Reiniciar() 
        {
            
            this.TBPrecio.Text = string.Empty;
            this.NUpDownCantidad.Value = 1;
            this.NupCantidadAgujeros.Value = 1;
            this.RBEscolar.Checked = false;
            this.RBProfesional.Checked = false;
            this.RBGomaLapiz.Checked = false;
            this.RBGomaTinta.Checked = false;
            this.RBGomaAmbos.Checked = false;
            cambiarVisibilidad();
        }

        public void AgregarMarcas() 
        {
            this.CBMarca.Items.Add("Faber Castell");
            this.CBMarca.Items.Add("Giotto");
            this.CBMarca.Items.Add("Bic");
            this.CBMarca.Items.Add("Maped");
            this.CBMarca.Items.Add("Pizzini");
            this.CBMarca.Items.Add("Crayola");
            this.CBMarca.Items.Add("Pelikan");
            this.CBMarca.Items.Add("Sharpie");
            this.CBMarca.Items.Add("Generico");
        }


        public void AgregarColores() 
        {
            this.CBColor.Items.Add("rojo");
            this.CBColor.Items.Add("azul");
            this.CBColor.Items.Add("amarillo");
            this.CBColor.Items.Add("verde");
            this.CBColor.Items.Add("violeta");
            this.CBColor.Items.Add("naranja");
            this.CBColor.Items.Add("rosa");
            this.CBColor.Items.Add("marron");
            this.CBColor.Items.Add("celeste");
            this.CBColor.Items.Add("negro");
            this.CBColor.Items.Add("gris");
            this.CBColor.Items.Add("blanco");
        }

        public void MostrarExcesoPrecio(Cartuchera<Utiles> Cartuchera, InfoPrecioAcumuladoEventArgs info) 
        {
            string alerta = string.Empty;
            ArchivoCartuchera archivo = new ArchivoCartuchera();

            alerta = $"El total acumulado es de {info.precioAcumulado}";
            archivo.EscribirTicketEvento(alerta, Cartuchera);
            MessageBox.Show(alerta);


        }

        public void cambiarVisibilidad() 
        {
            this.LblCantAgujeros.Visible = false;
            this.LblColor.Visible = false;
            this.GBoxFuncionGoma.Visible = false;
            this.NupCantidadAgujeros.Visible = false;
            this.CBColor.Visible = false;
        }

        private void Lapices_Click(object sender, EventArgs e)
        {
            Reiniciar();
            this.CBColor.Visible = true;
            this.LblColor.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reiniciar();
            this.GBoxFuncionGoma.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reiniciar();
            this.LblCantAgujeros.Visible = true; ;
            this.NupCantidadAgujeros.Visible = true;
        }

        private string ValidarParametrosUtil() 
        {
            StringBuilder retorno = new StringBuilder();
            double precio = 0;
            string marca = this.CBMarca.Text;
            string estilo = string.Empty;

            if(double.TryParse(this.TBPrecio.Text, out precio)) 
            {
                if (precio <= 0) 
                {
                    retorno.AppendLine("El precio no puede ser menor a cero");
                }
            }
            else 
            {
                retorno.AppendLine("Ingrese un precio valido");
            }

            if (string.IsNullOrWhiteSpace(marca)) 
            {
                retorno.AppendLine("Seleccione una marca");
            }

            estilo = EstiloSeleccionado();

            if(string.IsNullOrWhiteSpace(estilo)) 
            {
                retorno.AppendLine("Seleccione el estilo");
            }

            return retorno.ToString();
        }

        private bool AgregarLapiz() 
        {
            bool retorno = false;
            string aviso = string.Empty;
            string color = this.CBColor.Text;

            aviso = ValidarParametrosUtil();

            if (string.IsNullOrWhiteSpace(aviso)) 
            {
                if (!(string.IsNullOrWhiteSpace(color))) 
                {
                    retorno = true;
                }
                else 
                {
                    MessageBox.Show("Seleccione un color");
                }

            }
            else 
            {
                if (!(string.IsNullOrWhiteSpace(color))) 
                {
                    MessageBox.Show(aviso);
                }
                else 
                {
                    MessageBox.Show(aviso + "\nSeleccione un color");
                }
            }
            

            return retorno;
        }

        private bool AgregarGoma()
        {
            bool retorno = false;
            string aviso = string.Empty;

            aviso = ValidarParametrosUtil();

            if (string.IsNullOrWhiteSpace(aviso))
            {
                if(this.RBGomaLapiz.Checked == true || this.RBGomaTinta.Checked == true || this.RBGomaAmbos.Checked == true) 
                {
                    
                    retorno = true;
                }
                else 
                {
                    MessageBox.Show("Seleccione el tipo de goma"); 
                }
            }
            else
            {
                if (this.RBGomaLapiz.Checked == true || this.RBGomaTinta.Checked == true || this.RBGomaAmbos.Checked == true) 
                {
                    MessageBox.Show(aviso);
                }
                else 
                {
                    MessageBox.Show(aviso+"\n"+ "Seleccione el tipo de goma");
                }
              
            }
            return retorno;
        }

        private bool AgregarSacapuntas()
        {
            bool retorno = false;
            string aviso = string.Empty;

            aviso = ValidarParametrosUtil();

            if (string.IsNullOrWhiteSpace(aviso))
            {
                retorno = true;
            }
            else
            {
                MessageBox.Show(aviso);
            }
            return retorno;
        }

        public string EstiloSeleccionado()
        {
            string retorno = string.Empty;

            if(this.RBProfesional.Checked == true) { retorno = "profesional"; }
            if(this.RBEscolar.Checked == true) { retorno = "escolar"; }

            return retorno;
        }

        public double PrecioIngresado() 
        {
            double valor= 0;

            _ = double.TryParse(this.TBPrecio.Text, out valor);

            return valor;
        }

        public bool AgregarElUtil(Cartuchera<Utiles> cartuchera,int opcion)
        { 

            bool retorno = false;
            int bandera = 1;

            try
            {

                string marca = this.CBMarca.Text;
                string estilo = EstiloSeleccionado();
                double precio = PrecioIngresado();
                Cartuchera<Utiles> unaCartuchera = cartuchera;
                unaCartuchera.precioSuperior += MostrarExcesoPrecio;


                switch (opcion)
                {
                    case 1:
                        if (AgregarLapiz())
                        {

                            Lapiz unLapiz = new Lapiz(marca, precio, estilo, (int)this.NUpDownCantidad.Value, this.CBColor.Text, unaCartuchera.ID);


                            if (unaCartuchera.EstaEnLaLista(unaCartuchera, this.lasCartucheras))
                            {
                                if (unaCartuchera.CalucularMercaderiaAcumulada(unaCartuchera) < 20)
                                {
                                    if (unaCartuchera + unLapiz)
                                    {
                                        this.TBoxPropietario.ReadOnly = true;
                                        SQLClass.ModificarCartuchera(unaCartuchera);
                                        unaCartuchera.Ejecutar(unaCartuchera);
                                        retorno = true;
                                        bandera = 0;
                                    }

                                }
                            }
                            else
                            {
                                if (unaCartuchera + unLapiz)
                                {
                                    this.TBoxPropietario.ReadOnly = true;
                                    this.lasCartucheras.Add(unaCartuchera);
                                    SQLClass.GuardarCartuchera(unaCartuchera);                                   
                                    unaCartuchera.Ejecutar(unaCartuchera);
                                    retorno = true;
                                    bandera = 0;
                                }
                            }
                        }
                        else 
                        {
                            bandera = 2;
                        }
                    
                        break;
                    case 2:

                        if (AgregarGoma())
                        {
                            Goma unaGoma = null;

                            if (this.RBGomaAmbos.Checked == true)
                            {
                                unaGoma = new Goma(marca, precio, estilo, (int)this.NUpDownCantidad.Value, true, true, unaCartuchera.ID);
                            }
                            else
                            {
                                unaGoma = new Goma(marca, precio, estilo, (int)this.NUpDownCantidad.Value, this.RBGomaLapiz.Checked, this.RBGomaTinta.Checked, unaCartuchera.ID);
                            }

                            if (unaCartuchera.EstaEnLaLista(unaCartuchera, this.lasCartucheras))
                            {
                                if (unaCartuchera.CalucularMercaderiaAcumulada(unaCartuchera) < 20)
                                {
                                    if (unaCartuchera + unaGoma)
                                    {
                                        SQLClass.ModificarCartuchera(unaCartuchera);                                       
                                        unaCartuchera.Ejecutar(unaCartuchera);
                                        retorno = true;
                                        bandera = 0;
                                    }
                                }
                            }
                            else
                            {
                                if (unaCartuchera + unaGoma)
                                {
                                    this.lasCartucheras.Add(unaCartuchera);
                                    SQLClass.GuardarCartuchera(unaCartuchera);
                                    unaCartuchera.Ejecutar(unaCartuchera);
                                    retorno = true;
                                    bandera = 0;
                                }

                            }
                        }
                        else 
                        {
                            bandera = 2;
                        }

                        break;
                    case 3:
                        if (AgregarSacapuntas())
                        {
                            Sacapuntas unSacapuntas = new Sacapuntas(marca, precio, estilo, (int)this.NUpDownCantidad.Value, (int)this.NupCantidadAgujeros.Value, unaCartuchera.ID);

                            if (unaCartuchera.EstaEnLaLista(unaCartuchera, this.lasCartucheras))
                            {
                                if (unaCartuchera.CalucularMercaderiaAcumulada(unaCartuchera) < 20)
                                {
                                    if (unaCartuchera + unSacapuntas)
                                    {
                                        SQLClass.ModificarCartuchera(unaCartuchera);
                                        unaCartuchera.Ejecutar(unaCartuchera);
                                        retorno = true;
                                        bandera = 0;
                                    }

                                }
                            }
                            else
                            {
                                if (unaCartuchera + unSacapuntas)
                                {
                                    this.lasCartucheras.Add(unaCartuchera);
                                    SQLClass.GuardarCartuchera(unaCartuchera);
                                    unaCartuchera.Ejecutar(unaCartuchera);
                                    retorno = true;
                                    bandera = 0;
                                }

                            }
                        }
                        else 
                        {
                            bandera = 2;
                        }
                        break;
                }

                if (bandera == 1)
                {
                    unaCartuchera.precioSuperior -= MostrarExcesoPrecio;
                    throw new ParametrosException("El tope de la cartuchera es de 20 utiles");
                }
                unaCartuchera.precioSuperior -= MostrarExcesoPrecio;
                

            }
            catch (ParametrosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                Reiniciar();

            }
            return retorno;

        }

        private void BTAgregarUtil_Click(object sender, EventArgs e)
        {
            int opcion = EstadoUtil();
      
            int id = 0;

                if (!(string.IsNullOrWhiteSpace(this.TboxSecretID.Text)))
                {
                    Cartuchera<Utiles> unaCartuchera = new Cartuchera<Utiles>();

                    _ = int.TryParse(this.TboxSecretID.Text, out id);
                    unaCartuchera = unaCartuchera.BuscarCartucheraID(this.lasCartucheras, id);

                    if (unaCartuchera.EstaEnLaLista(unaCartuchera, this.lasCartucheras))
                    {
                        if (AgregarElUtil(unaCartuchera, opcion))
                        {
                            MessageBox.Show("el util se agrego exitosamente");
                        }
                    }

                }
                else
                {

                    if (!(string.IsNullOrWhiteSpace(this.TBoxPropietario.Text)))
                    {
                        Cartuchera<Utiles> unaCartuchera = new Cartuchera<Utiles>();
                        this.TboxSecretID.Text = unaCartuchera.GenerarNroRandom(this.lasCartucheras).ToString();
                        unaCartuchera.Duenio = this.TBoxPropietario.Text;
                        unaCartuchera.ID = int.Parse(this.TboxSecretID.Text);

                        if (AgregarElUtil(unaCartuchera, opcion))
                        {
                            MessageBox.Show("el util se agrego exitosamente");
                        }
                    }


                } 

        }

        public int EstadoUtil() 
        {
            int retorno = 0;

            if(this.CBColor.Visible == true) 
            {
                retorno = 1;
            }

            if(this.GBoxFuncionGoma.Visible == true) 
            {
                retorno = 2;
            }

            if(this.LblCantAgujeros.Visible == true) 
            {
                retorno = 3;
            }

            return retorno;
        }

 

        public void EventoPrecio(Cartuchera<Utiles> cartuchera)
        {//aca se usa el invoke required



            if (InvokeRequired)
            {
                Action<Cartuchera<Utiles>> miDelegado = EventoPrecio;
                Object[] misCartucheras = new Object[] { cartuchera };

                Invoke(miDelegado, misCartucheras);
            }
            else
            {
                MessageBox.Show(cartuchera.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void BTNuevoPropietario_Click(object sender, EventArgs e)
        {          
                this.TBoxPropietario.ReadOnly = false;
                this.TboxSecretID.Text = string.Empty;
                this.TBoxPropietario.Text = string.Empty;
                Reiniciar();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Dispose();
        }
    }
}
