using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    public enum TipoEstado { Inicio, Fin, Normal }
    public class Estado
    {
        //se puede obtener o se puede establecer (cambiar su valor)
        public TipoEstado Tipo { get; set; }
        //nombre del estado, sirve para enumerar despues
        public string ID { get; set; }
        //trancisiones que tiene el estado
        internal List<Transicion> Transiciones { get; }

        /**
         * Constructor Estado sin transiciones
         */
        public Estado(string id, TipoEstado tipo)
        {
            ID = id;
            Transiciones = new List<Transicion>();
            Tipo = tipo;
        }

        /**
         * Estado con 1 transicion con base en el siguiente estado
         */
        public Estado(string estadoID, TipoEstado tipo, char transicionId, Estado siguiente)
        {
            ID = estadoID;
            Tipo = tipo;
            Transiciones = new List<Transicion> { new Transicion(transicionId, this, siguiente) };
        }

        public void AgregaTransicion(char transicionId, Estado siguienteEstado)
        {
            Transiciones.Add(new Transicion(transicionId, this, siguienteEstado));
        }

        internal void AgregaTransiciones(List<Transicion> transiciones)
        {
            Transiciones.AddRange(transiciones);
        }

        public void CambiaTransicion(char transicionId, Estado siguiente)
        {
            Transicion? busqueda = Transiciones.Find(
                t => t.ID.Equals(transicionId) && t.Siguiente.Equals(siguiente)
            );

            if (busqueda != null)
                busqueda.Siguiente = siguiente;
        }

        public void EliminaTransicion(char transicionId, Estado siguiente)
        {
            Transicion? busqueda = Transiciones.Find(
                t => t.ID.Equals(transicionId) && t.Siguiente.Equals(siguiente)
            );

            if (busqueda != null)
                Transiciones.Remove(busqueda);
        }
    }
}
