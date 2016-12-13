using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;
using Archivos;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        /// <summary>
        /// Inicializa el form del WebBrowser
        /// </summary>

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Le da formato al textBox para ingresar la URL e inicializa el archivo del historial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        /// <summary>
        /// Evento que actualiza el progreso de la descarga
        /// </summary>
        /// <param name="progreso"></param>

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }

        /// <summary>
        /// Evento que finaliza la descarga del html y lo muestra por el richTextBox
        /// </summary>
        /// <param name="html"></param>

        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtHtmlCode_TextChanged(object sender, EventArgs e)
        {

        }

     
        /// <summary>
        /// Descarga la web ingresada en formato html y guarda su URL en el archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnIr_Click_1(object sender, EventArgs e)
        {
            if (!this.txtUrl.Text.Contains("http://"))
            {
                this.txtUrl.Text = this.txtUrl.Text.Insert(0, "http://");
            }

            try
            {
                Thread hilo;
                Uri web;
                Descargador descargador;
                web = new Uri(this.txtUrl.Text);
                descargador = new Descargador(web);

                descargador.PorcentajeDescarga += this.ProgresoDescarga;
                descargador.DescargaTerminada += this.FinDescarga;

                hilo = new Thread(new ThreadStart(descargador.IniciarDescarga));
                hilo.Start();
            }
            catch (Exception)
            {

            }
            finally
            {
                this.archivos.guardar(this.txtUrl.Text);
            }
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, EventArgs e)
        { }

        /// <summary>
        /// Muestra el historial de webs visitadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmHistorial historial;
            historial = new frmHistorial();
            historial.Show();
        }
    }
}
