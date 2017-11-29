using Ejercicio.Modelo.DAO;
using Ejercicio.Modelo.Entidades;
using PruebaNMProgramLibrary.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ejercicio.Modelo.Servicios
{
	public class ServicioRevistas : IServicio<Revista>
	{

        public int crear(Revista revista)
		{
			return GenericDAO<Revista>.crear(revista);
		}

		public Revista buscar(int id)
		{
			return GenericDAO<Revista>.buscar(id);
		}

		public void actualizar(Revista revista)
		{
			GenericDAO<Revista>.Actualizar(revista);
		}

		public void eliminar(int id)
		{
			GenericDAO<Revista>.eliminar(id);
		}

        public List<Revista> listar()
        {
            return new List<Revista>();
        }

        public List<Revista> buscarPorTitulo(string titulo)
        {
            return GenericDAO<Revista>.buscarPorTitulo(titulo);
        }

        public void eliminarTodo()
        {
            GenericDAO<Revista>.eliminarTodo();
        }
    }
}
