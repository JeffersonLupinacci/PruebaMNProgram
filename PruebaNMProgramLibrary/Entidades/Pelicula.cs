using Ejercicio.Modelo.Servicios;
using PruebaNMProgramLibrary.Utils;
using System;

namespace Ejercicio.Modelo.Entidades
{
    [Configuracion(Nombre = "Película", Servicio = typeof(ServicioPeliculas))]
    public class Pelicula : IEntidad
	{
        [Columna(Nombre = "Código")]
        public int id { get; set; }

        [Columna(Nombre = "Título")]
        public string titulo { get; set; }

        [Columna(Nombre = "Año")]
        public int año { get; set; }

		public Pelicula(String titulo, int año)
		{
			this.titulo = titulo;
			this.año = año;
		}
	}
}
