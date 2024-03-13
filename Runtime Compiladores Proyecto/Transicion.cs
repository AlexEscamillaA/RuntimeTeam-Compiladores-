using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    internal class Transicion
    {
        //nombre de la transicion
        public char ID { get; }
        public Estado Siguiente { get; set; }
        public Estado Actual { get; set; }

        public Transicion(char id, Estado actual, Estado siguiente)
        {
            Actual = actual;
            Siguiente = siguiente;
            ID = id;
        }
        public EDO destino;
        public string valor;

        public Transicion(EDO destino, string valor)
        {
            this.destino = destino;
            this.valor = valor;
        }
    }
}
