using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio:Persona
    {

        private int _identificador;


        public PersonaGimnasio()
        {

        }



        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }


        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }

        protected virtual string MostrarDatos()
        {
            
            StringBuilder sbPersonaGimnasio = new StringBuilder();

            sbPersonaGimnasio.AppendLine(base.ToString());

            sbPersonaGimnasio.AppendLine("ID: " + this._identificador);

            return sbPersonaGimnasio.ToString();
        }

        protected abstract string ParticiparEnClase();


        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador))
            { return true; }
            else
            { return false; }
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
