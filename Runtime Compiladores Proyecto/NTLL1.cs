using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    internal class NTLL1
    {
        public string nombre;

        //crear el diccionario de reducciones
        // El primer string son los simbolos de entrada, la lista es la produccion que deriva de
        public Dictionary<string, List<string>> reducciones = new Dictionary<string, List<string>>();

        public NTLL1(string nombre, Dictionary<string, List<string>> reducciones)
        {
            this.nombre = nombre;
            this.reducciones = reducciones;
        }
    }
}
