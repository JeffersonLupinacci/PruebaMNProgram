using Ejercicio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNMProgramLibrary.Utils
{
    public class EntidadeDisponible
    {
        public string Nombre { get; set; }

        public string Entidad { get; set; }

        public Type Servicio { get; set; }

        public List<KeyValuePair<string, string>> Columnas { get; set; }

        public EntidadeDisponible(string nombre, string entidad, Type servicio)
        {
            Columnas = new List<KeyValuePair<string, string>>();
            this.Nombre = nombre;
            this.Entidad = entidad;
            this.Servicio = servicio;
        }
    }
}
