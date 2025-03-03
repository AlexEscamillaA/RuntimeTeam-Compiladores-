﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime_Compiladores_Proyecto
{
    internal class AFD
    {
        public List<DEstado> DESTADOS = new List<DEstado>();
        public List<string> alfabeto = new List<string>();
        public int contador = 0;

        // Función para convertir el índice en una letra en mayúsculas
        public string ConvertirIndiceALetra(int indice)
        {
            return ((char)('A' + indice)).ToString();
        }

        // FUNCION PARA CREAR EL AFD
        public void construyeAFD(AFN afn)
        {
            contador = 0;
            DESTADOS.Clear();
            alfabeto = afn.alfabeto;
            int contAux = 0;
            DEstado U;
            List<EDO> listaux = new List<EDO>();
            listaux.Add(afn.estados[0]);
            DESTADOS.Add(cerraduraEpsilon(listaux));
            contador++;
            while (hayDestadosSinVisitar())
            {
                DESTADOS[contAux].visited = true;
                for (int s = 0; s < alfabeto.Count(); s++)
                {
                    U = cerraduraEpsilon(mover(DESTADOS[contAux], alfabeto[s]));
                    if (!estaEnDestados(U) && U.estados.Count() != 0)
                    {
                        DESTADOS[contAux].transiciones.Add(new TransicionDestado(U, alfabeto[s]));
                        DESTADOS.Add(U);
                        contador++;
                    }
                    else
                    {
                        if (estaEnDestados(U))
                        {
                            for (int i = 0; i < DESTADOS.Count(); i++)
                            {
                                if (compararDestados(DESTADOS[i], U))
                                {
                                    DESTADOS[contAux].transiciones.Add((new TransicionDestado(DESTADOS[i], alfabeto[s])));
                                }
                            }
                        }
                    }
                }
                contAux++;
            }
            foreach (DEstado d in DESTADOS)
            {
                foreach (EDO e in d.estados)
                {
                    if (e == afn.estados[afn.estados.Count() - 1])
                    {
                        d.setEDOaceptacion(true);
                    }
                }
            }
        }

        public bool estaEnDestados(DEstado U)
        {
            bool res = false;
            for (int i = 0; i < DESTADOS.Count() && res == false; i++)
            {
                if (DESTADOS[i].estados.Count() == U.estados.Count())
                {
                    bool band = true;
                    for (int j = 0; j < U.estados.Count() && band; j++)
                    {
                        if (!DESTADOS[i].estados.Contains(U.estados[j]))
                        {
                            band = false;
                        }
                    }
                    if (band)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }

        // FUNCION DE CERRADURA DE EPSILON
        public DEstado cerraduraEpsilon(List<EDO> e)
        {
            List<EDO> resultado = new List<EDO>();
            List<EDO> estados = new List<EDO>();
            foreach (EDO edo in e)
            {
                // BUSCA ESTADOS EPSILON CON ALGORITMO EN PROFUNDIDAD
                estados = dfsEpsilon(edo);
                foreach (EDO eaux in estados)
                {
                    if (!resultado.Contains(eaux))
                    {
                        resultado.Add(eaux);
                    }
                }
            }
            DEstado d = new DEstado(resultado, ConvertirIndiceALetra(contador));
            return d;
        }

        // BUSCA ESTADOS EPSILON CON ALGORITMO EN PROFUNDIDAD
        public List<EDO> dfsEpsilon(EDO e)
        {
            List<EDO> res = new List<EDO>();
            res.Add(e);
            List<EDO> aux = new List<EDO>();
            for (int i = 0; i < e.transiciones.Count(); i++)
            {
                if (e.transiciones[i].valor == "")
                {
                    aux = dfsEpsilon(e.transiciones[i].destino);
                    foreach (EDO d in aux)
                    {
                        res.Add(d);
                    }
                }
            }
            return res;
        }

        // ACCION MOVER
        public List<EDO> mover(DEstado A, string a)
        {
            List<EDO> res = new List<EDO>();
            foreach (EDO d in A.estados)
                foreach (Transicion t in d.transiciones)
                    if (t.valor == a)
                        res.Add(t.destino);
            return res;
        }

        public bool compararDestados(DEstado d1, DEstado d2)
        {
            bool res = false;
            if (d1.estados.Count() == d2.estados.Count())
            {
                bool band = true;
                for (int j = 0; j < d1.estados.Count() && band; j++)
                {
                    if (!d1.estados.Contains(d2.estados[j]))
                    {
                        band = false;
                    }
                }
                if (band)
                {
                    res = true;
                }
            }
            return (res);
        }

        public bool hayDestadosSinVisitar()
        {
            bool res = false;
            foreach (DEstado des in DESTADOS)
                if (des.visited == false)
                    res = true;
            return res;
        }
        //RECIBE LA CADENA LEXEMA DEL TEXTBOX QUE SE AGREGO, Y EL ESTADO INICIAL
        public bool lexemaValido(string lexema, DEstado destado)
        {
            bool resultado = false; //COMIENZA COMO FALSE A MENOS QUE SE CUMPLA
            //ESTE ES EL CASO BASE DE LA FUNCION RECURSIVA, SI LLEGA AL ESTADO DE ACEPTACION Y EL LEXEMA ESTA VACIO,
            //REGRESA VERDADERO, ENVIA UN TRUE A FORM1.CS PARA QUE MUESTRE
            //SI PERTENECE O NO PERTENECE
            if (destado.estadoAceptacion && lexema == "")
            {

                return true;
            }
            //Si el estado actual no es de aceptación o el lexema no está vacío, se procede a realizar el análisis recursivo.
            else
            {
                //SE ELIMINA EL 1ER CARACTER DEL LEXEMA Y LO GUARDA EN lexemaSubstr
                string lexemaSubstr = "";
                //SE VALIDA QUE EL LEXEMA NO ESTE VACIO
                if (lexema.Count() > 1)
                    lexemaSubstr = lexema.Substring(1);
                foreach (TransicionDestado t in destado.transiciones) //RECORRE TODAS LAS TRANSICIONES DEL AFD SEGUN LOS SIMBOLOS DEL LEXEMA
                {
                    try //INTENTA COMPARAR EL PRIMER CARACTER DEL LEXEMA CON LA TRANSICION DEL ESTADO
                    {
                        if (lexema[0].ToString() == t.valor) //COMPARA EL PRIMER CARACTER DEL LEXEMA CON EL VALOR DE LA TRANSICION T.VALOR
                            if (lexemaValido(lexemaSubstr, t.destino)) //SE HACE UNA LLAMADA RECURSIVA A LA FUNCION LEXEMAVALIDO, 
                                //CON EL PRIMER CARACTER ELIMINADO DEL LEXEMA Y EL ESTADO DESTINO DELA TRANSICION ACTUAL
                                return true; //SI DEVUELVE TRUE SIGNIFICA QUE EL RESTO DEL LEXEMA ES VALIDO HASTA ESTE PUNTO
                    }
                    //EN CASO DE INTENTAR ACCEDER A UN ESPACIO SIN MEMORIA, ARROJA UN ERROR
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
            return resultado;
        }
    }
}
