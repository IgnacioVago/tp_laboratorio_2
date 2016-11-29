using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;



        public int DNI
        {
            get 
            { 
                return this._dni; 
            }
            set 
            { 
                this._dni = this.ValidarDNI(this._nacionalidad, value); 
            }
        }



        public string Apellido
        {
            get 
            { 
                return this._apellido; 
            }
            set 
            { 
                this._apellido = value; 
            }
        }



        public ENacionalidad Nacionalidad
        {
            get 
            { 
                return this._nacionalidad; 
            }
            set 
            { 
                this._nacionalidad = value; 
            }
        }



        public string Nombre
        {
            get 
            { 
                return this._nombre; 
            }
            set 
            { 
                this._nombre = value; 
            }
        }



        public string StringToDNI
        {
            set 
            { 
                this._dni = this.ValidarDNI(this._nacionalidad, value); 
            }
        }



        public Persona()
        {

        }



        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }



        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }



        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }




        public override string ToString()
        {
            StringBuilder sbPersona = new StringBuilder();

            sbPersona.AppendLine("Nombre: " + this.Nombre);

            sbPersona.AppendLine("Apellido: " + this.Apellido);

            sbPersona.AppendLine("DNI: " + this.DNI);

            sbPersona.AppendLine("Nacionalidad: " + this.Nacionalidad);

            return sbPersona.ToString();
        }



        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                {
                    return dato;
                }
                else
                {
                    throw new DniInvalidoException("Nacionalidad no se condice con el numero de DNI");
                }
            }
            else
            {
                if (dato > 90000000 && nacionalidad == ENacionalidad.Extranjero)
                {
                    return dato;
                }

                throw new NacionalidadInvalidaException("Nacionalidad Invalida");

            }
        }

        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDNI(nacionalidad, int.Parse(dato));
        }


        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsDigit(dato[i]))
                {
                    throw new Exception("Nombre Invalido");
                }
            }

            return dato;
        }


        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

    }
}
