using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    internal class Token
    {
        public string valor;
        public string tipo;

        public Token(string valor, string tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
        }
    }
}
