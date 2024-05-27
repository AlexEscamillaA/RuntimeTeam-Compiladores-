using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    internal class TablaM
    {

        public string simboloInicial;


        public List<NTLL1> derivaciones = new List<NTLL1>();
        List<string> terminales;
        public TablaM(List<string> terminales)
        {
            this.terminales = terminales;
        }

        public void agregarDerivacion(string name, Dictionary<string, List<string>> reducciones)
        {
            derivaciones.Add(new NTLL1(name, reducciones));
        }

        bool M(string X, string a)
        {

            for (int i = 0; i < derivaciones.Count; i++)
            {
                if (derivaciones[i].nombre == X)
                {
                    if (derivaciones[i].reducciones.ContainsKey(a))
                        return true;
                }
            }
            return false;
        }

        public TreeNode analisisSintactico(List<Token> tokens)
        {

            //Se establece w$ en este caso los tokens
            List<string> w = new List<string>();

            foreach (Token token in tokens)
            {
                w.Add(token.tipo);
            }
            w.Add("$");

            //se carga la pila con $ y luego con el simbolo inicial

            Stack<string> pila = new Stack<string>();

            pila.Push("$");
            pila.Push(simboloInicial);

            //crear variable de retorno

            TreeNode lamamadelamamadelamamadelamama = new TreeNode(simboloInicial);

            //crear una pila paralela para los nodos del árbol


            Stack<TreeNode> pilaNodos = new Stack<TreeNode>();
            pilaNodos.Push(lamamadelamamadelamamadelamama);

            TreeNode currentNode = lamamadelamamadelamamadelamama;

            int i = 0;
            string a = w[i];
            string X = pila.Peek();
            currentNode = pilaNodos.Peek();

            while (X != "$")
            {
                if (X == a)
                { //sacar de la pila y avanzar ip

                    pilaNodos.Pop();
                    pila.Pop();
                    i++;
                    a = w[i];
                }
                else
                if (terminales.Contains(X))
                {
                    return null;
                }
                else
                if (!M(X, a))
                {
                    if (X != "ε")
                        return null;
                    else
                    {
                        pila.Pop();
                        pilaNodos.Pop();
                    }
                }
                else
                if (M(X, a))
                {

                    Stack<string> aux = new Stack<string>();
                    pila.Pop();

                    Stack<TreeNode> auxStack = new Stack<TreeNode>();
                    TreeNode auxiliar = new TreeNode();
                    //currentNode = pilaNodos.Peek();

                    for (int j = 0; j < derivaciones.Count; j++)
                    {
                        if (derivaciones[j].nombre == X)
                        {
                            if (derivaciones[j].reducciones.ContainsKey(a))
                                foreach (string elemento in derivaciones[j].reducciones[a])
                                {
                                    //insertar en pila
                                    aux.Push(elemento);
                                    auxiliar = new TreeNode(elemento);
                                    auxStack.Push(auxiliar);
                                    //el problema es que se trabajan diferentes nuevos elementos, encontrar una forma de 
                                    //insertar los elementos y que sean dichos elementos los que se manipulen
                                    currentNode.Nodes.Add(auxiliar);//guarda los hijos de los nodos
                                }
                            pilaNodos.Pop();
                            while (aux.Count > 0)
                            {
                                pilaNodos.Push(auxStack.Pop());
                                pila.Push(aux.Pop());
                            }
                            currentNode = pilaNodos.Peek();
                        }
                    }

                }
                X = pila.Peek();
                if (X != "$")
                    currentNode = pilaNodos.Peek();
                //currentNode = pilaNodos.Peek();
                /*if(pilaNodos.Count > 0)
                    currentNode = pilaNodos.Peek();*/

            }




            return lamamadelamamadelamamadelamama;
        }

    }
}