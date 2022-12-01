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

namespace Pascual.Christian.SPLabII
{
    public partial class FRMdeserializar : Form
    {
        private List<Lapiz> listadoLapices;
        public FRMdeserializar(List<Lapiz> lista)
        {
            InitializeComponent();
            this.listadoLapices = lista;
            this.DGVDeserializar.DataSource = this.listadoLapices;
        }
    }
}
