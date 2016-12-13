using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
       public const string ARCHIVO_HISTORIAL = "historico.dat";

        /// <summary>
        /// Inicializa el form del historial
        /// </summary>

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Le agrega al historial las paginas visitadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            List<string> historial;

            if (archivos.leer(out historial))
            {
                foreach (String item in historial)
                {
                    this.lstHistorial.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No se guardo el historial");
            }
        }


            
        

        private void lstHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
