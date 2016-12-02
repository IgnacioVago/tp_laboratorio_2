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
        private string _direccionDeArchivo;
        public Texto(string archivo)
        {
            this._direccionDeArchivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(this._direccionDeArchivo, true);
                escritor.WriteLine(datos);
                escritor.Close();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
 
        }

        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader lector;
                lector = new StreamReader(this._direccionDeArchivo);

                datos = new List<string>();

                while (!lector.EndOfStream)
                {
                    datos.Add(lector.ReadLine());
                }

                lector.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(List<string>);
                return false;
            }
 
        }
    }
}
