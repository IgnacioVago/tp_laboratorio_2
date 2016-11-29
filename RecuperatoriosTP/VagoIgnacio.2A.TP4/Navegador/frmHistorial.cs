using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archivos;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Texto archivos = new Texto(frmHistorial.ARCHIVO_HISTORIAL);

            List<string> historial;
            if (archivos.leer(out historial))
            {
                foreach (string item in historial)
                {
                    this.lstHistorial.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No se guardo el historial.");
            }

            
        }

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
