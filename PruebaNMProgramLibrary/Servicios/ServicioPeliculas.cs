using Ejercicio.Modelo.DAO;
using Ejercicio.Modelo.Entidades;
using PruebaNMProgramLibrary.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio.Modelo.Servicios
{
	public class ServicioPeliculas : IServicio<Pelicula>
	{    
        public int crear(Pelicula pelicula)
		{
			return GenericDAO<Pelicula>.crear(pelicula);
		}

		public Pelicula buscar(int id)
		{
			return GenericDAO<Pelicula>.buscar(id);
		}

		public void actualizar(Pelicula pelicula)
		{
			GenericDAO<Pelicula>.Actualizar(pelicula);
		}

		public void eliminar(int id)
		{
			GenericDAO<Pelicula>.eliminar(id);
		}

        public List<Pelicula> listar()
        {
            return new List<Pelicula>();
        }

        public List<Pelicula> buscarPorTitulo(string titulo)
        {
            return GenericDAO<Pelicula>.buscarPorTitulo(titulo);
        }

        public void eliminarTodo()
        {
            GenericDAO<Pelicula>.eliminarTodo();
        }
    }
}
