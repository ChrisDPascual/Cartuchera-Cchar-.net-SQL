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
    public partial class FRMListadoTickets : Form
    {
        private ArchivoCartuchera archivo;
        public FRMListadoTickets()
        {
            this.archivo = new ArchivoCartuchera();
            InitializeComponent();
            this.RTBoxTickets.Text = archivo.LeerTicketEvento();
        }
    }
}
