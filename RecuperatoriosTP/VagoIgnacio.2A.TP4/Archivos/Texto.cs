using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public string rutaArchivo;

        /// <summary>
        /// Constructor que asigna la ruta del archivo.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        public Texto(string archivo)
        {
            this.rutaArchivo = archivo;
        }

        /// <summary>
        /// Guarda los datos.
        /// </summary>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(this.rutaArchivo, true);
                escritor.WriteLine(datos);
                escritor.Close();

                return true;
            }
            catch (Exception)
            {
                
                throw new Exception("NO GUARDA.");
            }
        }

        /// <summary>
        /// Lee los datos.
        /// </summary>
        /// <param name="datos">Datos a leer.</param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader lector;
                lector = new StreamReader(this.rutaArchivo);

                datos = new List<string>();

                while (lector.EndOfStream == false)
                {
                    datos.Add(lector.ReadLine());
                }

                lector.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(List<string>);
                throw new Exception("NO LEE.");
            }

        }
    }
}
