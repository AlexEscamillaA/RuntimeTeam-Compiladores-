using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    public class Automata
    {
        public string Etiqueta { get; set; }
        public Estado EstadoInicial { get; set; }
        public Estado EstadoFinal { get; set; }
        public List<Transicion> Transiciones { get; set; }
        public List<Estado> Estados { get; set; }
        public int TotalEstados { get; set; }
        public int TransicionesEpsilon { get; set; }

        /**
         * Crea un automata base con estado inicial y final relaconados con una
         * transicion entre ellos
         */
        public Automata(string etiqueta, Estado inicial, Estado final, char transicionID)
        {
            Etiqueta = etiqueta;
            EstadoInicial = inicial;
            EstadoFinal = final;
            EstadoInicial.AgregaTransicion(transicionID, EstadoFinal);
        }
        //constructor vacio para poder crear automatas vacios
        public Automata() { }
        //regresa la transicion final
        public Transicion? ObtenTransicionFinal(Estado estado)
        {
            Transicion? busqueda = estado.Transiciones.Find(t => t.Siguiente.Tipo == TipoEstado.Fin);
            if (busqueda != null)
                return busqueda;
            foreach (Transicion transicion in estado.Transiciones)
                busqueda = ObtenTransicionFinal(transicion.Siguiente);
            return busqueda;
        }
        //metodo que recorre el automata en anchura, para generar la lista de edos, de transiciones y la cuenta de edos y transiciones epsilon
        public void GeneraInfo()
        {
            HashSet<Estado> visitados = new HashSet<Estado>();//guarda edos ya visitados
            List<Estado> estadosVecinos = new List<Estado>();//lista para guardar siguientes edos vecinos de cada estado
            Transiciones = new List<Transicion>();//inicializa lista de transiciones y de edos
            Estados = new List<Estado>();
            Queue<Estado> cola = new Queue<Estado>();//inicializa la cola
            cola.Enqueue(EstadoInicial);//agregar a la cola el edo inicial
            int idActual = 0;//empieza la enumeracion de edos en 0
            while (cola.Count > 0)//mientras la cola tenga algo
            {
                Estado estadoActual = cola.Dequeue();//jala de la cola el edo de enfrente
                if (visitados.Contains(estadoActual))//si ya esta visitados que pase al siguiente edo
                    continue;
                else
                {
                    estadoActual.ID = idActual.ToString();//si no esta en visitados, le pone la numeracion
                    visitados.Add(estadoActual);//agrega el edo a la lista de visitados
                    idActual++;//incrementa numeracion para que el siguiente edo se enumere 
                }
                estadoActual.Transiciones.ForEach(t => estadosVecinos.Add(t.Siguiente));//carga las transiciones del edo actual a la lista e edos vecinos
                if (estadoActual == null)//si el edo actual es nulo sigue al siguiete
                    continue;
                foreach (Estado vecino in estadosVecinos)//recorre edos vecinos del edo actual
                    cola.Enqueue(vecino);
            }

            foreach (Estado estado in visitados)//se agregan transiciones epsilon
            {
                Estados.Add(estado);
                foreach (Transicion transicion in estado.Transiciones)
                {
                    if (transicion.ID == Operador.Epsilon) TransicionesEpsilon++;
                    if (!Transiciones.Contains(transicion)) Transiciones.Add(transicion);
                }
            }

            TotalEstados = visitados.Count;
        }
    }
}
