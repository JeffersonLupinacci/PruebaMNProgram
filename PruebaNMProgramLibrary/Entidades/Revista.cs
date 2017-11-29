using Ejercicio.Modelo.Servicios;
using PruebaNMProgramLibrary.Utils;
using System;

namespace Ejercicio.Modelo.Entidades
{
    [Configuracion(Nombre = "Revista", Servicio = typeof(ServicioRevistas))]
    public class Revista: IEntidad
	{
        [Columna(Nombre = "Código")]
        public int id { get; set; }

        [Columna(Nombre = "Título")]
        public string titulo { get; set; }

		public Revista(String titulo)
		{
			this.titulo = titulo;
		}
	}
}
