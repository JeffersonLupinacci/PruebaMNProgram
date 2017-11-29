using Ejercicio.Modelo.DAO;
using Ejercicio.Modelo.Entidades;
using PruebaNMProgramLibrary.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio.Modelo.Servicios
{
	public class ServicioLibros : IServicio<Libro>
	{

        public int crear(Libro libro)
		{
			return GenericDAO<Libro>.crear(libro);
		}

		public Libro buscar(int id)
		{
			return GenericDAO<Libro>.buscar(id);
		}

		public void actualizar(Libro libro)
		{
			GenericDAO<Libro>.Actualizar(libro);
		}

		public void eliminar(int id)
		{
			GenericDAO<Libro>.eliminar(id);
		}

        public List<Libro> listar()
        {
            return GenericDAO<Libro>.listar();
        }

        public List<Libro> buscarPorTitulo(string titulo)
        {
            return GenericDAO<Libro>.buscarPorTitulo(titulo);
        }

        public void eliminarTodo()
        {
            GenericDAO<Libro>.eliminarTodo();            
        }
    }
}
