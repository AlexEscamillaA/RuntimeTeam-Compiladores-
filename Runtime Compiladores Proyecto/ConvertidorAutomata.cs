using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    public class ConvertidorAutomata
    {
        public enum TipoCaracter { Operando, Operador, Ninguno };

        // Puede regresar null si hay algun error (?)
        public static Automata? AlgoritmoEvaluacion(string expresionPosFija)
        {
            // Crea una pila de automatas (etiquetas)
            Stack<Automata> pilaAutomatas = new Stack<Automata>();
            // Numero de etiqueta
            int etiquetaActual = 1;
            // Variables auxiliares para aplicar operadores
            Automata resultado = new Automata(), operando1 = new Automata(), operando2 = new Automata();

            //ALGORITMO DE EVALUACION
            // Recorre cada caracter de la expresion posfija
            foreach (char caracter in expresionPosFija)
            {
                switch (EvaluaCaracter(caracter))
                {
                    // TipoCaracter es una enumeracion de la clase Operador
                    case TipoCaracter.Operando:
                        // Agrega un nuevo automata a la pila con transicion 'caracter'
                        pilaAutomatas.Push(new Automata(
                            "R" + etiquetaActual++,
                            new Estado("", TipoEstado.Inicio),
                            new Estado("", TipoEstado.Fin),
                            caracter
                        ));
                        break;
                    case TipoCaracter.Operador:
                        switch (Operador.ObtenTipo(caracter))
                        {
                            case TipoOperador.Unario:
                                // Extraer el tope de la pila
                                operando1 = pilaAutomatas.Pop();
                                // Aplicar operador
                                resultado = Operador.AplicaOperadorUnario(caracter, operando1);
                                // Cambia la etiqueta
                                resultado.Etiqueta = "R" + etiquetaActual++;
                                // Inserta el resultado en el tope de la pila
                                pilaAutomatas.Push(resultado);
                                break;
                            case TipoOperador.Binario:
                                // Extrae 2 valores del tope de la pila
                                operando2 = pilaAutomatas.Pop();
                                operando1 = pilaAutomatas.Pop();
                                // Aplicar el operador
                                resultado = Operador.AplicaOperadorBinario(caracter, operando1, operando2);
                                // Cambia la etiqueta de operando1
                                resultado.Etiqueta = "R" + etiquetaActual++;
                                pilaAutomatas.Push(resultado);
                                break;
                        }
                        break;
                    default: return null;
                }
            }
            return pilaAutomatas.Peek();
        }
        //FUNCION PARA SABER SI ES OPERANDO U OPERADOR
        public static TipoCaracter EvaluaCaracter(char caracter)
        {
            if (Char.IsLetterOrDigit(caracter))
                return TipoCaracter.Operando;
            else if (Operador.EsOperador(caracter))
                return TipoCaracter.Operador;
            else return TipoCaracter.Ninguno;
        }
    }
}
