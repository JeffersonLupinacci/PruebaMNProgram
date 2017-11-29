using PruebaNMProgramLibrary.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaNMProgramLibrary.Utils
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class Configuracion : Attribute
    {        
        public string Nombre { get; set; }

        public Type Servicio { get; set; }

    }

}
