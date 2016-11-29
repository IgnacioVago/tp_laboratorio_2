using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {

        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;




        public List<Alumno> alumnos
        {
            get
            {
                return this._alumnos;
            }
        }



        public Instructor instructor
        {
            get
            {
                return this._instructor;
            }
        }



        public Gimnasio.EClases clases
        {
            get
            {
                return this._clase;
            }
        }


        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }


        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }


        public static bool Guardar(Jornada jornada)
        {


            Texto texto = new Texto();
            return texto.guardar("jornada.txt", jornada.ToString());


        }


        public static string leer()
        {
            string pathTexto = "jornada.txt";
            string aux;

            Texto text = new Texto();
            text.leer(pathTexto, out aux);

            return aux;
        }


        public override string ToString()
        {
            
            StringBuilder sbJornada = new StringBuilder();

            sbJornada.AppendLine("--JORNADA--");
            sbJornada.AppendLine("Instructor: " + this._instructor.ToString());
            sbJornada.AppendLine("Da la clase de: " + this._clase.ToString());
            sbJornada.AppendLine("Alumnos");
            foreach (Alumno item in this._alumnos)
            {
                sbJornada.AppendLine(item.ToString());
            }


            return sbJornada.ToString();
        }


        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (j._alumnos.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            int i;
            for (i = 0; i < j._alumnos.Count; i++)
            {
                if (j._alumnos[i] == a)
                {
                    return j;
                }

            }
            if (i == j._alumnos.Count)
            {
                j._alumnos.Add(a);
            }
            return j;
        }
    }
}
