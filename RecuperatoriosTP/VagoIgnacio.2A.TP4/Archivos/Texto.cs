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
        public string direccionDeArchivo;
        public Texto(string archivo)
        {
            this.direccionDeArchivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(this.direccionDeArchivo, true);
                escritor.WriteLine(datos);
                escritor.Close();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("NO GUARDA.");
            }
 
        }

        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader lector;
                lector = new StreamReader(this.direccionDeArchivo);

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
