using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNMProgramLibrary.Servicios
{
    public interface IServicio<IEntidad>
    {

        int crear(IEntidad entidad);

        IEntidad buscar(int id);

        void actualizar(IEntidad entidad);

        void eliminar(int id);

        List<IEntidad> listar();

        List<IEntidad> buscarPorTitulo(string titulo);

        void eliminarTodo();
        
    }
}
