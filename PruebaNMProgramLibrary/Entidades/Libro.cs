using Ejercicio.Modelo.Servicios;
using PruebaNMProgramLibrary.Utils;
using System;

namespace Ejercicio.Modelo.Entidades
{
    [Configuracion(Nombre = "Libro", Servicio = typeof(ServicioLibros))]
	public class Libro : IEntidad
	{
        [Columna(Nombre="Código")]
		public int id { get; set; }

        [Columna(Nombre = "Título")]
        public string titulo { get; set; }

		public Libro(String titulo)
		{
			this.titulo = titulo;
		}
	}
}
