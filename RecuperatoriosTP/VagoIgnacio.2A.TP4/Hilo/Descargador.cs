using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; 
using System.ComponentModel;

namespace Hilo
{
    
    public class Descargador
    {
        private string _html;
        private Uri _direccion;

        public delegate void EventProgress(int status);
        public event EventProgress evento_Progreso;
        public delegate void EventCompleted(string web);
        public event EventCompleted evento_Terminado;

        public Descargador(Uri direccion)
        {
            this._html = "";
            this._direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this._direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.evento_Progreso(e.ProgressPercentage);
        }

        
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this._html = e.Result;
            }
            catch (Exception exception)
            {
                this._html = exception.Message;
            }
            finally
            {
                this.evento_Terminado(this._html);
            }
        }
    }
}
