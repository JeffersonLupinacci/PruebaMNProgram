using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaNMProgramLibrary.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class Columna : Attribute
    {        
        public string Nombre { get; set; }

    }

}
