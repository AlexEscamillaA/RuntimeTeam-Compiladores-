using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    public class Transicion
    {
        // Nombre de la transición
        public char ID { get; }
        public Estado Siguiente { get; set; }
        public Estado Actual { get; set; }

        public Transicion(char id, Estado actual, Estado siguiente)
        {
            Actual = actual;
            Siguiente = siguiente;
            ID = id;
        }
    }
}
