using Ejercicio.Modelo.Entidades;
using PruebaNMProgramLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNMProgramLibrary.Servicios
{
    public static class ServicioEntidades
    {

        private static Type[] GetTypes(Assembly assembly, string nameSpace)
        {
            return assembly
                    .GetTypes()
                    .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                    .ToArray();
        }

        public static List<EntidadeDisponible> recuperaEntidades()
        {
            List<EntidadeDisponible> resultado = new List<EntidadeDisponible>();
            var classeBase = typeof(Libro);
            Type[] listaClases = GetTypes(Assembly.GetExecutingAssembly(), classeBase.Namespace);
            for (int i = 0; i < listaClases.Length; i++)
            {
                var cfg = listaClases[i].GetCustomAttribute(typeof(Configuracion), true) as Configuracion;
                if (null != cfg)
                {
                    EntidadeDisponible e = new EntidadeDisponible(cfg.Nombre, listaClases[i].AssemblyQualifiedName, cfg.Servicio);
                    foreach (var prop in listaClases[i].GetProperties())
                    {
                        object[] objects = prop.GetCustomAttributes(false);
                        foreach (object obj in objects)
                            if (obj is Columna)
                                e.Columnas.Add(new KeyValuePair<string, string>(prop.Name, ((Columna)obj).Nombre));
                    }
                    resultado.Add(e);
                }
            }
            return resultado;
        }
    }
}
