using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajoPracticoCalculadora
{
    public class numero
    {
        private double _numero;
        /// <summary>
        /// inicializara los atributos en 0
        /// </summary>
        public numero()
        {
            this._numero = 0;
        }
        /// <summary>
        /// Sobrecarga de Numero,
        /// por medio de SetNumero se carga el atributo.
        /// </summary>
        /// <param name="numero">String que se carga en _numero</param>
        public numero(string numero)
        {
            setNumero(numero);
        }
        /// <summary>
        /// Se carga un double en el atributo _numero.
        /// </summary>
        /// <param name="numero">Double que se carga en _numero</param>
        public double getNumero()
        {
            return this._numero;
        }

        public numero(double numero)
        {
            this._numero = numero;
        }

        private void setNumero(string numero)
        {
            this._numero = validarNum(numero);
        }
        /// <summary>
        /// Valida el string pasado.
        /// </summary>
        /// <param name="numeroString">numero que se valida y se convierte</param>
        /// <returns>el string convertido o 0 si falla</returns>
        private double validarNum(string numString)
        {
            double num;
            bool result = double.TryParse(numString, out num);
          
            if (result)
                return this._numero = num;
            else
                return 0;
        }

        /// <summary>
        /// sobrecarga de Numero
        /// </summary>
        /// <param name="numero">double</param>
        /// <returns>nuevo objeto</returns>
        public static implicit operator numero(double numero)
        {
            return new numero(numero);
        }
        /// <summary>
        /// sobrecarga de double
        /// </summary>
        /// <param name="numero">Numero</param>
        /// <returns>double de la clase Numero</returns>
        public static implicit operator double(numero numero)
        {
            return numero._numero;
        }
        /// <summary>
        /// sobrecarga de + - / *
        /// </summary>
        /// <param name="numero1">numero 1</param>
        /// <param name="numero2">numero 2</param>
        /// <returns>resultado</returns>
        public static double operator +(numero num1, numero num2)
        {
            return num1._numero + num2._numero;
        }
        public static double operator -(numero num1, numero num2)
        {
            return num1._numero - num2._numero;
        }
        public static double operator /(numero num1, numero num2)
        {
            return num1._numero / num2._numero;
        }
        public static double operator *(numero num1, numero num2)
        {
            return num1._numero * num2._numero;
        }
    }
}
