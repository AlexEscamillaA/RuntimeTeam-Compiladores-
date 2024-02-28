using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    public enum TipoOperador { Unario, Binario, Ninguno }

    public static class Operador
    {
        //se definen los operadores
        public static readonly char[] OperadoresUnarios = { '+', '*', '?' };
        public static readonly char[] OperadoresBinarios = { '&', '|' };
        public static readonly char Epsilon = 'ε';

        public static Automata AplicaOperadorBinario(char operador, Automata a, Automata b)
        {
            Automata resultado = new Automata();
            switch (operador)
            {
                case '&':
                    resultado = Concatenacion(a, b);
                    break;
                case '|':
                    resultado = SeleccionAlternativas(a, b);
                    break;
            }
            return resultado;
        }

        public static Automata AplicaOperadorUnario(char operador, Automata operando)
        {
            Automata resultado = new Automata();
            switch (operador)
            {
                case '+':
                    resultado = CerraduraPositiva(operando);
                    break;
                case '*':
                    resultado = CerraduraKleen(operando);
                    break;
                case '?':
                    resultado = CeroInstancia(operando);
                    break;
            }
            return resultado;
        }
        //regresa si es unario, binario o ninguno
        public static TipoOperador ObtenTipo(char operador)
        {
            if (OperadoresUnarios.Contains(operador))
                return TipoOperador.Unario;
            else if (OperadoresBinarios.Contains(operador))
                return TipoOperador.Binario;
            else return TipoOperador.Ninguno;
        }
        //EvaluateException si un caracter es operador o no
        public static bool EsOperador(char caracter)
        {
            return OperadoresUnarios.Contains(caracter) || OperadoresBinarios.Contains(caracter);
        }

        private static Automata Concatenacion(Automata a, Automata b)
        {
            // Crea un nuevo automata
            Automata resultado = new Automata();

            // Establece el estado inicial con el estado inicial de a
            resultado.EstadoInicial = a.EstadoInicial;
            // Establece el estado final con el estado final de b
            resultado.EstadoFinal = b.EstadoFinal;

            // Cambia el tipo del estado final de A y estado incial de B a normal
            a.EstadoFinal.Tipo = b.EstadoInicial.Tipo = TipoEstado.Normal;
            // Agrega las transiciones del estado inicial de B al estado final de A
            a.EstadoFinal.AgregaTransiciones(b.EstadoInicial.Transiciones);

            // Apunta los estados inicial y final del resultado a los creados
            resultado.EstadoInicial = a.EstadoInicial;
            resultado.EstadoFinal = b.EstadoFinal;

            return resultado;
        }

        private static Automata SeleccionAlternativas(Automata a, Automata b)
        {
            // Crea un nuevo automata
            Automata resultado = new Automata();

            // Crea un nuevo estado inicial para el automata nuevo
            Estado nuevoEstadoInicial = new Estado("", TipoEstado.Inicio);
            // Cambia el tipo de los estados iniciales de A y B
            a.EstadoInicial.Tipo = b.EstadoInicial.Tipo = TipoEstado.Normal;
            // Agrega las transiciones del nuevo inicio hacia el inicio de A y B
            nuevoEstadoInicial.AgregaTransicion(Epsilon, a.EstadoInicial);
            nuevoEstadoInicial.AgregaTransicion(Epsilon, b.EstadoInicial);

            // Crea un nuevo estado final para el automata nuevo
            Estado nuevoEstadoFinal = new Estado("", TipoEstado.Fin);
            // Cambia el tipo de los estados finales de A y B
            a.EstadoFinal.Tipo = b.EstadoFinal.Tipo = TipoEstado.Normal;
            // Agrega las transiciones de los estados finales de A y B hacia el nuevo estado final
            a.EstadoFinal.AgregaTransicion(Epsilon, nuevoEstadoFinal);
            b.EstadoFinal.AgregaTransicion(Epsilon, nuevoEstadoFinal);

            // Apunta los estados inicial y final del resultado a los creados
            resultado.EstadoInicial = nuevoEstadoInicial;
            resultado.EstadoFinal = nuevoEstadoFinal;

            return resultado;
        }

        private static Automata CeroInstancia(Automata a)
        {
            // Crea un nuevo automata
            Automata resultado = new Automata();

            // Crea un nuevo estado inicial y final para el automata nuevo
            Estado nuevoEstadoInicial = new Estado("", TipoEstado.Inicio);
            Estado nuevoEstadoFinal = new Estado("", TipoEstado.Fin);

            // Cambia el tipo de los estados inicial y final de A
            a.EstadoInicial.Tipo = a.EstadoFinal.Tipo = TipoEstado.Normal;

            // Agrega la transicion del nuevo inicio hacia el inicio de A
            nuevoEstadoInicial.AgregaTransicion(Epsilon, a.EstadoInicial);

            // Agrega la transicion del estado final de A hacia el nuevo estado final
            a.EstadoFinal.AgregaTransicion(Epsilon, nuevoEstadoFinal);

            // Agrega la transicion del nuevo estado inicial hacia el nuevo estado final
            nuevoEstadoInicial.AgregaTransicion(Epsilon, nuevoEstadoFinal);

            // Apunta los estados inicial y final del resultado a los creados
            resultado.EstadoInicial = nuevoEstadoInicial;
            resultado.EstadoFinal = nuevoEstadoFinal;

            return resultado;
        }

        private static Automata CerraduraKleen(Automata a)
        {
            // Crea un nuevo automata
            Automata resultado = new Automata();
            resultado = CerraduraPositiva(a);
            // Agrega la transición del estado inicial al final
            resultado.EstadoInicial.AgregaTransicion(Epsilon, resultado.EstadoFinal);

            return resultado;
        }
        private static Automata CerraduraPositiva(Automata a)
        {
            // Crea un nuevo automata
            Automata resultado = new Automata();

            // Crea un nuevo estado inicial y final para el automata nuevo
            Estado nuevoEstadoInicial = new Estado("", TipoEstado.Inicio);
            Estado nuevoEstadoFinal = new Estado("", TipoEstado.Fin);

            // Cambia el tipo de los estados inicial y final de A
            a.EstadoInicial.Tipo = a.EstadoFinal.Tipo = TipoEstado.Normal;

            // Agrega la transicion del nuevo inicio hacia el inicio de A
            nuevoEstadoInicial.AgregaTransicion(Epsilon, a.EstadoInicial);

            // Agrega la transicion del estado final de A hacia el nuevo estado final
            a.EstadoFinal.AgregaTransicion(Epsilon, nuevoEstadoFinal);
            // Agrega la transicion del estado final de A hacia el estado inicial de A
            a.EstadoFinal.AgregaTransicion(Epsilon, a.EstadoInicial);

            // Apunta los estados inicial y final del resultado a los creados
            resultado.EstadoInicial = nuevoEstadoInicial;
            resultado.EstadoFinal = nuevoEstadoFinal;

            return resultado;
        }
    }
}
