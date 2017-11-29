using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNMProgramLibrary.Utils
{
    public static class Log
    {
        public static void gravarLog(string mensaje)
        {
            using (StreamWriter outputFile = new StreamWriter(Directory.GetCurrentDirectory() + "\\log.txt", true))
                outputFile.WriteLine(mensaje);
        }
    }
}
