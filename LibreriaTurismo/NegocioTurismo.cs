using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaTaller
{
    public class NegocioTurismo
    {
        private List<Ruta> rutas;
        private List<Cliente> clientes;

        public NegocioTurismo()
        {
            this.rutas = new List<Ruta>();
            this.clientes = new List<Cliente>();
        }



        /// <summary>
        /// Agrega una nueva ruta a las rutas disponibles, siempre y cuando no exista esta ruta 
        /// </summary>
        /// <param name="ruta">La nueva ruta a agregar</param>
        /// <returns>valor 1 si la pudo agregar</returns>
        public int AgregarRuta(Ruta ruta)
        {
            int res = 0;
            bool existe = false;

            foreach(Ruta r in rutas)
            {
                if(r.Codigo.Equals(ruta.Codigo))
                {
                    existe = true;
                    break;
                }
            }
            
            if(!existe)
            {
                rutas.Add(ruta);
                res = 10;
            }
            else
            {
                throw new ArgumentException("La ");
            }

            return res;
        }

        /// <summary>
        /// Recibe los datos del cliente, y las rutas que quiere realizar, valida que el tiempo
        /// de las rutas no exceda las 8 horas y que la hora de llegada no sobrepase las 20:00
        /// </summary>
        /// <param name="rutas">Las rutas que quiere recorrer el cliente</param>
        /// <param name="cliente">El cliente que recorre la ruta</param>
        /// <returns>true si se puede hacer la asignación de las rutas, falso si no</returns>
        public bool AtenderCliente(List<Ruta> rutas, Cliente cliente)
        {
            bool res = false;
            bool clienteExiste = false;
            //calcula el tiempo total de las rutas recorridas
            int tiempo = 0;
            tiempo = CalcularTiempo(rutas);

            //el tiempo está en minutos hay que calcularlo en horas
            if (tiempo > 480)
            {
                throw new Exception("La lista de rutas supera las 8 horas de visita");
            }
            else
                

            //busca si el cliente está registrado
            foreach(Cliente cli in clientes)
            {
                if(cli.Rut.Equals(cliente.Rut))
                {
                    clienteExiste = true;
                    break;
                }
            }

            if (clienteExiste && tiempo <= 480)
                res = true;

            return res;
        }

        /// <summary>
        /// Registra a un cliente siempre y cuando el cliente no se repita
        /// </summary>
        /// <returns>1 si lo pudo registrar</returns>
        public int RegistrarCliente(Cliente cliente)
        {
            int res = 0;

            //agrega el cliente en la lista y devuelve 1
            clientes.Add(cliente);
            res = 1;


            return res;
        }

        /// <summary>
        /// Calcula el costo de las rutas 
        /// </summary>
        /// <param name="rutas">Las rutas que va a visitar el cliente</param>
        /// <returns></returns>
        public int CalcularCosto(List<Ruta> rutas)
        {
            int res = 0;
            return res;
        }

        /// <summary>
        /// Calcula el tiempo que demorará en visitar el cliente según las rutas establecidas
        /// </summary>
        /// <param name="rutas">Las rutas seleccionadas para recorres</param>
        /// <returns>El tiempo en minutos</returns>
        public int CalcularTiempo(List<Ruta> rutas)
        {
            int res = 0;
            foreach (Ruta r in rutas)
            {
                foreach (Etapa e in r.Etapas)
                {
                    res += e.TiempoVisita;
                }
            }

            return res;
        }

        public List<Cliente> traerTodo()
        {
            return clientes;
        }
    }
}