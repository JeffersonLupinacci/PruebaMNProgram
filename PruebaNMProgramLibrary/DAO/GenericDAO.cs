using Ejercicio.Modelo.Entidades;
using PruebaNMProgramLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio.Modelo.DAO
{
    public class GenericDAO<T> where T : IEntidad
    {
        private static List<T> BaseDatosEnMemoria = new List<T>();
        private static int NextId = 1;

        public static int crear(T entidad)
        {
            entidad.id = NextId++;
            BaseDatosEnMemoria.Add(entidad);

            Log.gravarLog(typeof(T).Name + " id: " + entidad.id + " creado");

            return entidad.id;
        }

        public static T buscar(int id)
        {
            Log.gravarLog(typeof(T).Name + " buscado por id: " + id);
            return BaseDatosEnMemoria.FirstOrDefault(x => x.id == id);
        }

        public static void Actualizar(T entidad)
        {
            int indice = BaseDatosEnMemoria.FindIndex(x => x.id == entidad.id);
            if (indice != -1)
            {
                BaseDatosEnMemoria[indice] = entidad;
                Log.gravarLog(typeof(T).Name + " id: " + entidad.id + " actualizado");
            }
        }

        public static void eliminar(int id)
        {
            int indice = BaseDatosEnMemoria.FindIndex(x => x.id == id);
            if (indice != -1)
            {
                Log.gravarLog(typeof(T).Name + " id: " + id + " eliminado");
                BaseDatosEnMemoria.RemoveAt(indice);
            }
        }


        public static void eliminarTodo()
        {
            for (int i = BaseDatosEnMemoria.Count - 1; i >= 0; i--)
                eliminar(BaseDatosEnMemoria[i].id);
        }

        public static List<T> listar()
        {
            var dados = BaseDatosEnMemoria.Where(x => x.GetType().Equals(typeof(T))).ToList<T>();
            return dados;
        }

        public static List<T> buscarPorTitulo(string titulo)
        {
            var dados = BaseDatosEnMemoria
                .Where(x => x.GetType().Equals(typeof(T)) && x.titulo.ToLower().Contains(titulo.ToLower()))
                .ToList<T>();

            Log.gravarLog(typeof(T).Name + " buscado por: " + titulo + " total: " + dados.Count() );
            return dados;
        }
    }
}
