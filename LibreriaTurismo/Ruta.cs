using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaTaller
{
    public class Ruta
    {
        private int codigo;
        private string nombre;
        private List<Etapa> etapas;
        private int costoGuia;
        private int costoChofer;
        private int arriendoFurgon;

        public Ruta(int codigo, string nombre, int costoGuia, int costoChofer, int arriendoFurgon)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.CostoGuia = costoGuia;
            this.CostoChofer = costoChofer;
            this.ArriendoFurgon = arriendoFurgon;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<Etapa> Etapas { get => etapas; }
        public int CostoGuia { get => costoGuia; set => costoGuia = value; }
        public int CostoChofer { get => costoChofer; set => costoChofer = value; }
        public int ArriendoFurgon { get => arriendoFurgon; set => arriendoFurgon = value; }

        /// <summary>
        /// Agrega una nueva etapa siempre que el código no exista
        /// </summary>
        /// <param name="nuevo">La nueva etapa que se va a agregar</param>
        public void AgregarEtapa(Etapa nuevo)
        {
            bool existe = false;
            foreach(Etapa et in etapas)
            {
                if(et.Codigo==nuevo.Codigo)
                {
                    existe = true;
                    break;
                }
            }

            if(!existe)
            {
                etapas.Add(nuevo);
            }
            else
            {
                throw new ArgumentException("Ya existe una etapa con este código");
            }
            
        }

        /// <summary>
        /// Calcula el costo sumando el costo del chofer el arriendo del firgo y el costo del guía
        /// </summary>
        /// <returns>El costo de la ruta</returns>
        public int CalcularCostoRuta()
        {
            int costo = 0;

            costo += this.costoChofer + this.arriendoFurgon;


            return costo;
        }
    }
}