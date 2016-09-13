using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajoPracticoCalculadora
{
    public class calculadora
    {
        /// <summary>
        /// Segun el operador, realiza la operacion correspondiente.
        /// </summary>
        /// <param name="Numero1">numero 1</param>
        /// <param name="Numero2">numero 2</param>
        /// <param name="operador">operador</param>
        /// <returns>resultado de la operacion</returns>
        public double operar(numero numUno, numero numDos, string operador)
        {
            double result;

            switch (operador)
            {
                case "+":
                    result = numUno + numDos;
                    break;
                case "-":
                    result = numUno - numDos;
                    break;
                case "*":
                    result = numUno * numDos;
                    break;
                case "/":
                    if (numDos == 0)
                        result = 0;
                    else
                        result = numUno / numDos;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }
        /// <summary>
        /// valida que el operador sea valido
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>el operador validado, o + si el operador no es valido</returns>
        public string validaOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                return operador;
            else
                return "+";

        }
    }
}
