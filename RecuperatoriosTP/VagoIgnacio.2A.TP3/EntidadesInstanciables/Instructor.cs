using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor:PersonaGimnasio
    {

        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        public Gimnasio.EClases[] clases
        {
            get
            {
                return this._clasesDelDia.ToArray();
            }

        }


        public Instructor()
        {

        }


        static Instructor()
        {
            _random = new Random();
        }


        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClase();


        }


        private void _randomClase()
        {
            int randomUno;
            int randomDos;

            randomUno = _random.Next(0, 3);
            randomDos = _random.Next(0, 3);

            this._clasesDelDia.Enqueue((Gimnasio.EClases)randomUno);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)randomDos);
        }


        protected override string MostrarDatos()
        {
            
            StringBuilder sbInstructor = new StringBuilder();
            sbInstructor.AppendLine(base.MostrarDatos());
            sbInstructor.AppendLine(this.ParticiparEnClase());

            return sbInstructor.ToString();
        }


        protected override string ParticiparEnClase()
        {
            StringBuilder sbInstructor;
            sbInstructor = new StringBuilder();

            sbInstructor.AppendLine("--Clases del dia--");

            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sbInstructor.AppendLine(item.ToString());
            }

            return sbInstructor.ToString();
        }


        public override string ToString()
        {
            return this.MostrarDatos();
        }


        public static bool operator ==(Instructor instructor, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases item in instructor._clasesDelDia)
            {
                if (item == clase)
                {
                    return true;
                }
            }

            return false;
        }


        public static bool operator !=(Instructor instructor, Gimnasio.EClases clase)
        {
            return !(instructor == clase);
        }
    }
}
