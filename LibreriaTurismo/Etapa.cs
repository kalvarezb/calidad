using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibreriaTaller
{
    public class Etapa
    {
        private int codigo;
        private string nombre;
        private string descripcion;
        private int tiempoVisita;

        public Etapa(int codigo, string nombre, string descripcion, int tiempoVisita)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TiempoVisita = tiempoVisita;
        }

        public int Codigo { get => codigo; set => codigo = value; }

        public string Nombre { get => nombre;
            set
            {
                if(value.Trim().Length>=2)
                {
                    this.nombre = value;
                }
                else
                {
                    throw new ArgumentException("El nombre debe tener al menos dos caracteres");
                }
            }
        }

        public string Descripcion { get => descripcion;
            set
            {
                if(value.Length>0)
                {
                    this.descripcion = value;
                }
                else
                {
                    throw new ArgumentException("La descripción no puede estar en blanco");
                }
            }
        }
        public int TiempoVisita { get => tiempoVisita;
            set
            {
                if(value>0)
                {
                    this.tiempoVisita = value;
                }
                else
                {
                    throw new ArgumentException("EL tiempo de visita debe superar el minuto");
                }
            }
        }
    }
}