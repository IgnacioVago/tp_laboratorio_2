using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(PersonaGimnasio))]
    [XmlInclude(typeof(Persona))]
    [Serializable]
    
    public class Gimnasio
    {

        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;



        public List<Alumno> Alumnos
        {
            get 
            { 
                return this._alumnos; 
            }
        }
        public List<Jornada> Jornada
        {
            get 
            { 
                return this._jornada; 
            }
        }

        public List<Instructor> Instructores
        {
            get 
            { 
                return this._instructores; 
            }
        }

        public Jornada this[int i]
        {
            get 
            { 
                return this._jornada[i];
            }
        }



        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }



        public static bool Guardar(Gimnasio gimnasio)
        {
            string pathXml = "gimnasio.xml";

            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();

            xmlFile.guardar(pathXml, gimnasio);

            return true;
        }


        public static Gimnasio Leer()
        {
            Gimnasio auxGim = null;
            string archivo = "gimnasio.xml";

            Xml<Gimnasio> deserializador = new Xml<Gimnasio>();
            deserializador.leer(archivo, out auxGim);

            return auxGim;
        }


        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sbGimnasio = new StringBuilder();

            for (int i = 0; i < gim._jornada.Count; i++)
            {
                sbGimnasio.AppendLine(gim._jornada[i].ToString());
            }

            return sbGimnasio.ToString();
        }



        public override string ToString()
        {
            return MostrarDatos(this);
        }


        


        public List<Jornada> Jornadas
        {
            get 
            { 
                return this._jornada; 
            }
        }



        public static bool operator ==(Gimnasio gim, Alumno a)
        {
            foreach (Alumno item in gim._alumnos)
            {
                if (gim._alumnos.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }


        public static bool operator !=(Gimnasio gim, Alumno p)
        {
            return !(gim == p);
        }


        public static Instructor operator ==(Gimnasio gim, EClases clase)
        {
            foreach (Instructor item in gim._instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinInstructorException();
        }


        public static Instructor operator !=(Gimnasio gim, EClases clase)
        {
            try
            {
                foreach (Instructor item in gim._instructores)
                {
                    if (item != clase)
                    {
                        return item;
                    }

                }
                throw new Exception("Todos los instructores estan en esa clase");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }



        }


        public static bool operator ==(Gimnasio gim, Instructor ins)
        {
            int i;
            for (i = 0; i < gim._instructores.Count; i++)
            {
                if (gim._instructores[i] == ins)
                {
                    return true;
                }
            }
            return false;
        }


        public static bool operator !=(Gimnasio gim, Instructor i)
        {
            return !(gim == i);
        }


        public static Gimnasio operator +(Gimnasio gim, Alumno alu)
        {
            int i;
            for (i = 0; i < gim._alumnos.Count; i++)
            {
                if (gim._alumnos[i] == alu)
                {
                    throw new AlumnoRepetidoException();
                }
            }
            if (i == gim._alumnos.Count)
            {
                gim._alumnos.Add(alu);
            }

            return gim;
        }


        public static Gimnasio operator +(Gimnasio gim, EClases clase)
        {
            Jornada jor = new Jornada(clase, (gim == clase));
            foreach (Alumno item in gim._alumnos)
            {
                if (item == clase)
                {
                    jor += item;
                }
            }
            gim._jornada.Add(jor);
            return gim;


        }


        public static Gimnasio operator +(Gimnasio gim, Instructor i)
        {
            try
            {
                if (gim != i)
                {
                    gim._instructores.Add(i);

                }
                else
                {
                    throw new Exception("Instructor repetido");
                }


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }
            return gim;
        }


        public enum EClases
        {
            CrossFit,
            Natacion,
            Pilates,
            Yoga
        }


    }
}
