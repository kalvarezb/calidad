using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LibreriaTaller
{
    public class Cliente
    {
        private String rut;
        private String nombre;
        private String telefono;
        private String email;

        public Cliente(string rut, string nombre, string telefono, string email)
        {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
        }

        public string Rut
        {
            get
            {
                return rut;
            }
            set
            {
                if (validarRut(value))
                    this.rut = value;
                else
                    throw new ArgumentException("El rut no es válido");
            }
        }
        public string Nombre { get => nombre;
            set
            {
                if(value.Trim().Length>=3)
                {
                    this.nombre = value;
                }
                else
                {
                    throw new ArgumentException("El nombre debe tener al menos tres caracteres");
                }
            }
        }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email
        {
            get => email;
            set
            {
                if (validarEmail(value))
                    this.email = value;
                else
                    throw new ArgumentException("El email no es válido");
            }
        }

        /// <summary>
        /// Método que valida el rut, se puede pasar con los puntos y el guión o sólo 
        /// </summary>
        /// <param name="rut">El rut a validar</param>
        /// <returns>true si es válido</returns>
        private bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return validacion;
        }

        public bool validarEmail(String email)
        {
            bool res = false;
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            res = regex.IsMatch(email);

            return res;
        }

    }
}