using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public delegate void EventoDescargaFinalizada(string html);
    public delegate void EventoPorcentajeDeDescarga(int porcentaje);

    public class Descargador
    {
        private string html;
        private Uri direccion;

        /// <summary>
        /// Constructor que asigna la direccion.
        /// </summary>
        /// <param name="direccion"></param>
        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        /// <summary>
        /// Se descarga la web pasada anteriormente.
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();

                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public event EventoPorcentajeDeDescarga PorcentajeDescarga;
        /// <summary>
        /// Metodo que lanza un evento que actualiza el porcentaje de la descarga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.PorcentajeDescarga(e.ProgressPercentage);
        }


        public event EventoDescargaFinalizada DescargaTerminada;
        /// <summary>
        /// Metodo que lanza un evento que posee el codigo descargado. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.html = e.Result;
            this.DescargaTerminada(this.html);
        }
    }
}
