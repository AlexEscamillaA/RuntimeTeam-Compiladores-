using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Runtime_Compiladores_Proyecto
{
    public partial class Form1 : Form
    {
        List<Token> tokens = new List<Token>();
        AFN afn = new AFN();
        AFD afd = new AFD();
        static List<string> Palabras = new List<string>() { "if", "then", "else", "end", "repeat", "until", "read", "write" };
        static List<string> Simbolos = new List<string>() { "+", "-", "*", "/", "=", "<", ">", "(", ")", ";", ":=" };
        public Form1()
        {
            InitializeComponent();
        }

        private void expresionRegular_TextChanged(object sender, EventArgs e)
        {

        }

        private void boton_calcular_posfija_Click(object sender, EventArgs e)
        {

        }

        private void Compilador_Load(object sender, EventArgs e)
        {

        }

        // PRIMERA REVISIÓN, INFIJA A POSFIJA

        private void conversionButton_Click(object sender, EventArgs e)
        {
            string expresionRegular = expresionRegularResponse.Text;
            string expresionExplicita = convierteExplicita(expresionRegular);
            string expresionPostfija = ConvertirAPosfija(expresionExplicita);
            expresionPostfijaResponse.Text = expresionPostfija;
        }

        public static string ConvertirAPosfija(string expresionRegular)
        {
            string expresionPosfija = "";
            Stack<char> pilaOperadores = new Stack<char>(); // Inicializa la pila

            foreach (char caracter in expresionRegular)
            {
                switch (caracter)
                {
                    case '(': // Si es un inicio de paréntesis
                        pilaOperadores.Push(caracter); // Lo mete a la pila
                        break;
                    case ')': // Si es el final del paréntesis
                        while (pilaOperadores.Count > 0 && pilaOperadores.Peek() != '(') // Extrae todo lo que había en el paréntesis
                            expresionPosfija += pilaOperadores.Pop(); // Lo extraído lo mete a la expresión resultado (posfija)
                        pilaOperadores.Pop();
                        break;
                    default: // Si es un número, letra u operador
                        if (Char.IsLetterOrDigit(caracter)) // Si es un numero o una letra
                            expresionPosfija += caracter; // Lo mete a la expresión resultado
                        else if (Jerarquia(caracter) != 0)
                        {
                            bool band = true;
                            while (band)
                            {
                                // Diferentes condiciones de operadores donde:
                                // 1. No hay nada en la pila 2. El operador es el inicio de un paréntesis 3. Si la jerarquía del caracter iterado es mayor a la jerarquía del pico de la pila
                                if (pilaOperadores.Count == 0 || pilaOperadores.Peek() == '(' || Jerarquia(caracter) > Jerarquia(pilaOperadores.Peek()))
                                {
                                    pilaOperadores.Push(caracter); // Mete el caracter a la pila y cambia la banda
                                    band = false;
                                }
                                else
                                    expresionPosfija += pilaOperadores.Pop(); // Sino, solamente mete el operador pico de la pila a la expresión resultado
                            }
                        }
                        break;
                }
            }

            while (pilaOperadores.Count > 0) // Si quedan operadores en la pila
            {
                expresionPosfija += pilaOperadores.Pop(); // Los operadores que quedan se meten a la expresión posfija
            }

            return expresionPosfija.ToString(); // Se retorna la expresión hecha
        }

        public static string ExpansionAlternativas(string alternativas)
        {
            string resultado = "";
            int caracterInicial = (int)alternativas[0];
            int caracterFinal = (int)alternativas[2]; // a - z <--- Casteamos a Int para obtener el valor en ASCII

            // Agregamos las variables de un cierto rango [XX-XX] ya sean números o letras
            for (int caracter = caracterInicial; caracter <= caracterFinal; caracter++)
            {
                resultado += (char)caracter; // Se devuelve el entero a carácter y se añade
                if (caracter != caracterFinal) // Se pone la alternativa solo sino es el final
                    resultado += '|';
            }
            return '(' + resultado + ')'; // Se ponen las alternativas en un string con paréntesis
        }

        public static string SeleccionAlternativas(string cadena)
        {
            string resultado = "";

            if (cadena[0] == '[') // Si tiene corchete
            {
                resultado = cadena.Split('[', ']')[1]; // Deja las letras quitando los corchetes
                resultado = string.Join('|', resultado.ToList()); // Agrega la selección de alternativas en medio de las letras
            }
            else if (cadena[0] == '(') // Si tiene paréntesis
            {
                resultado = cadena.Split('(', ')')[1]; // Deja las letras quitando los paréntesis
                resultado = string.Join('&', resultado.ToList()); // Agrega la selección 
            }

            return '(' + resultado + ')'; // Agrega los paréntesis de inicio y fin
        }

        public static string convierteExplicita(string expresionRegular)
        {
            string expresionExplicita = "";

            for (int posicion = 0; posicion < expresionRegular.Length; posicion++)
            {
                if (expresionRegular[posicion] == '[') // Si encuentra un corchete inicial
                {
                    // Subcadena que toma lo que hay dentro de los corchetes
                    string cadenaSeleccionAlt = expresionRegular.Substring(posicion + 1, expresionRegular.Substring(posicion).IndexOf(']') - 1);

                    if (expresionExplicita != "" && expresionExplicita.Last() == ')') // Si la cadena no está vacía y hay un paréntesis al final
                        expresionExplicita += '&'; // Se le agrega un paréntesis
                    if (cadenaSeleccionAlt.Contains('-')) // Si contiene un - 
                        expresionExplicita += ExpansionAlternativas(cadenaSeleccionAlt); // Se agregan todas las alternativas
                    else
                        expresionExplicita += SeleccionAlternativas('[' + cadenaSeleccionAlt + ']'); // Se agregan las concatenaciones
                    posicion += cadenaSeleccionAlt.Length + 1;

                }
                else if (expresionRegular[posicion] == '(') // Si encuentra un corchete inicial
                {
                    // Subcadena que toma lo que hay dentro de los paréntesis
                    string cadenaSeleccionAlt = expresionRegular.Substring(posicion + 1, expresionRegular.Substring(posicion).IndexOf(')') - 1);

                    if (expresionExplicita != "" && expresionExplicita.Last() == ')') // Si la cadena no está vacía y hay un paréntesis al final
                        expresionExplicita += '&';
                    // En caso de contener operandos, corchete o paréntesis
                    if (cadenaSeleccionAlt.Contains('|') ||
                       cadenaSeleccionAlt.Contains('[') ||
                       cadenaSeleccionAlt.Contains('*') ||
                       cadenaSeleccionAlt.Contains('+') ||
                       cadenaSeleccionAlt.Contains('?') ||
                       cadenaSeleccionAlt.Contains('('))
                    {
                        // Se toma la subcadena para convertirla en explícita mediante una llamada recursiva
                        expresionExplicita += '(' + convierteExplicita(cadenaSeleccionAlt) + ')';
                    }
                    else
                    {
                        expresionExplicita += SeleccionAlternativas('(' + cadenaSeleccionAlt + ')'); // Solo se agregan las concatenaciones
                    }
                    posicion += cadenaSeleccionAlt.Length + 1; // Le suma el 1 al iterador que es después del final del paréntesis
                }
                // Condiciones para concatenación
                else if (posicion != expresionRegular.Length - 1) // Sino ha llegado al final de la expresión
                {
                    // Si hay un operador y el siguiente no es una alternativa
                    if ((expresionRegular[posicion] == '?' && expresionRegular[posicion + 1] != '|') ||
                        (expresionRegular[posicion] == '+' && expresionRegular[posicion + 1] != '|') ||
                        (expresionRegular[posicion] == '*' && expresionRegular[posicion + 1] != '|') ||
                        Char.IsLetter(expresionRegular[posicion]) &&
                        (Char.IsLetter(expresionRegular[posicion + 1]) ||
                        expresionRegular[posicion + 1] == '(' ||
                        expresionRegular[posicion + 1] == '['))
                    {
                        expresionExplicita += expresionRegular[posicion];
                        expresionExplicita += '&';
                    }
                    // Sino solo agrega la concatenación
                    else
                        expresionExplicita += expresionRegular[posicion];
                }
                else
                    expresionExplicita += expresionRegular[posicion];
            }
            return expresionExplicita;
        }

        // Jerarquia de Operaciones
        public static int Jerarquia(char operador)
        {
            if (operador == '?' || operador == '*' || operador == '+')
                return 3;
            else if (operador == '&')
                return 2;
            else if (operador == '|')
                return 1;
            else return 0;
        }

        private void afnButton_Click_1(object sender, EventArgs e)
        {
            // LIMPIA LAS COLUMNAS Y FILAS DE LA TABLA
            tablaAFN.Columns.Clear();
            tablaAFN.Rows.Clear();

            int contadorE = 0;
            int contadorEstados = 0;

            // INVOCA EL METODO PRINCIPAL PARA CONVERTIR DE POSFIJA EN AFN
            afn.conviertePosfijaEnAFN(expresionPostfijaResponse.Text);
            tablaAFN.Columns.Clear();

            // CREA LA COLUMNA DE ESTADOS
            DataGridViewColumn estados = new DataGridViewColumn();
            estados.Name = "Estado";
            estados.HeaderText = "Estado";
            DataGridViewCell dgvcell1 = new DataGridViewTextBoxCell();
            estados.CellTemplate = dgvcell1;
            tablaAFN.Columns.Add(estados);

            // RECORRE EL ALFABETO Y CREA LAS COLUMNAS 
            afn.alfabeto.ForEach(token =>
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.Name = token;
                column.HeaderText = token;
                DataGridViewCell dgvcell = new DataGridViewTextBoxCell();
                column.CellTemplate = dgvcell;
                tablaAFN.Columns.Add(column);
            });

            // CREA LA COLUMNA DE EPSILON
            DataGridViewColumn columnaEpsilon = new DataGridViewColumn();
            columnaEpsilon.Name = "e";
            columnaEpsilon.HeaderText = "e";
            DataGridViewCell dgvcellEpsilon = new DataGridViewTextBoxCell();
            columnaEpsilon.CellTemplate = dgvcellEpsilon;
            tablaAFN.Columns.Add(columnaEpsilon);

            // RECORRE LOS ESTADOS Y LLENA LA TABLA
            for (int i = 0; i < afn.estados.Count; i++)
            {
                contadorEstados++;
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(tablaAFN);
                r.Cells[0].Value = afn.estados[i].nombre;
                for (int j = 0; j <= afn.alfabeto.Count; j++)
                {
                    List<string> destinos = new List<string>();
                    if (j == afn.alfabeto.Count)
                    {
                        foreach (Transicion t in afn.estados[i].transiciones)
                        {
                            if (t.valor == "")
                            {
                                contadorE++;
                                destinos.Add($"{{{t.destino.nombre}}}");
                            }
                        }
                    }
                    else
                    {
                        foreach (Transicion t in afn.estados[i].transiciones)
                        {
                            if (t.valor == afn.alfabeto[j])
                            {
                                destinos.Add($"{{{t.destino.nombre}}}");
                            }
                        }
                    }
                    r.Cells[j + 1].Value = string.Join(", ", destinos);
                }
                tablaAFN.Rows.Add(r);
            }
            nEstados.Text = contadorEstados.ToString();
            nEpsilon.Text = contadorE.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        // REVISIÓN: AFD

        private void afdButton_Click_1(object sender, EventArgs e)
        {
            // CREA EL AFD
            afd.construyeAFD(afn);
            tablaAFD.Columns.Clear();

            // CREA LA COLUMNA DE ESTADOS
            DataGridViewColumn columnEDO = new DataGridViewColumn();
            columnEDO.Name = "Estado";
            columnEDO.HeaderText = "Estado";
            DataGridViewCell dgvcell1 = new DataGridViewTextBoxCell();
            columnEDO.CellTemplate = dgvcell1;
            tablaAFD.Columns.Add(columnEDO);

            // RECORRE EL ALFABETO Y AGREGA LAS COLUMNAS DE TRANSICIONES
            afn.alfabeto.ForEach(token =>
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.Name = token;
                column.HeaderText = token;
                DataGridViewCell dgvcell = new DataGridViewTextBoxCell();
                column.CellTemplate = dgvcell;
                tablaAFD.Columns.Add(column);
            });


            // RECORRE LOS ESTADOS Y LLENA LA TABLA
            int contadorDestados = 0;
            for (int i = 0; i < afd.DESTADOS.Count; i++)
            {

                contadorDestados++;
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(tablaAFD);
                r.Cells[0].Value = afd.DESTADOS[i].name;
                for (int j = 0; j < afd.alfabeto.Count; j++)
                    foreach (TransicionDestado t in afd.DESTADOS[i].transiciones)
                        if (t.valor == afn.alfabeto[j])
                            r.Cells[j + 1].Value = r.Cells[j + 1].Value + " " + t.destino.name.ToString();
                tablaAFD.Rows.Add(r);
            }
            nEstadosAFD.Text = contadorDestados.ToString();
        }

        //Boton para validar que el lexema compla o no con el lenguaje de la expresion regular
        private void button2_Click_1(object sender, EventArgs e)
        {
            //INTENTA VALIDAR EL LEXEMA CON ValidaLema CON EL AFD YA CONSTRUIDO
            try
            {
                if (afd.lexemaValido(tbLexema.Text, afd.DESTADOS[0]))
                    lexemares.Text = "Si pertenece";
                else
                    lexemares.Text = "No pertenece";
            }
            //CUANDO SE SALE DEL AUTOMATA ARROJA UNA EXCEPCION
            catch
            {
                lexemares.Text = "No Pertenece";
            }
        }

        private void clasificarBoton_Click(object sender, EventArgs e)
        {
            //limpiamos la lista de tokens
            lexicoSintacticoBox.Text = "";
            tokens.Clear();
            try
            {
                if (identificadorBox.Text != "" && numeroBox.Text != "" && programaBox.Text != "")
                {
                    tablaTokens.Rows.Clear(); //Reiniciar contenido de tabla

                    //Iniciar proceso de AFN/AFD del identificador y numero
                    //Posfijas
                    string posID = ConvertirAPosfija(convierteExplicita(identificadorBox.Text));
                    string posNum = ConvertirAPosfija(convierteExplicita(numeroBox.Text));
                    //AFNs
                    AFN AFN_ID = new AFN();
                    AFN_ID.conviertePosfijaEnAFN(posID);
                    AFN AFN_Num = new AFN();
                    AFN_Num.conviertePosfijaEnAFN(posNum);
                    //AFDs
                    AFD AFD_ID = new AFD();
                    AFD_ID.construyeAFD(AFN_ID);
                    AFD AFD_Num = new AFD();
                    AFD_Num.construyeAFD(AFN_Num);

                    List<String[]> Code = new List<String[]>(); //Cachitos de codigo en cada linea
                    int Line = 0; //Linea actual al imprimir en grid

                    for (int i = 0; i < programaBox.Lines.Length; i++)
                    {
                        // Leer linea por linea textbox y separar codigo
                        string Trim = programaBox.Lines[i].Trim();
                        String[] lineArr = Trim.Split(' ');
                        Code.Add(lineArr);
                        foreach (string s in lineArr)
                        {
                            // Leer cada renglon e identificar el codigo 

                            // Identificar renglon vacio
                            if (s == null || s == "") { Line--; }//Hacer nada, contrarestar recorrimiento de linea en tabla
                            // Prueba palabra reservada
                            else if (Palabras.Contains(s))
                            {
                                tablaTokens.Rows.Add(s, s);
                                tokens.Add(new Token(s, s));
                            }
                            // Prueba Simbolo especial
                            else if (Simbolos.Contains(s))
                            {
                                tablaTokens.Rows.Add(s, s);
                                tokens.Add(new Token(s, s));
                            }
                            // Pprueba AFD Numero
                            else if (AFD_Num.lexemaValido(s, AFD_Num.DESTADOS[0]))
                            {
                                tablaTokens.Rows.Add("número", s);
                                tokens.Add(new Token(s, "número"));
                            }
                            // Prueba AFD Identificador
                            else if (AFD_ID.lexemaValido(s, AFD_ID.DESTADOS[0]))
                            {
                                tablaTokens.Rows.Add("identificador", s);
                                tokens.Add(new Token(s, "identificador"));
                            }
                            // Error lexico
                            else if (s != "")
                            {
                                tablaTokens.Rows.Add("error", s);
                                tokens.Add(new Token(s, "error"));
                                tablaTokens.Rows[Line].Cells[0].Style.ForeColor = Color.Red;
                                tablaTokens.Rows[Line].Cells[1].Style.ForeColor = Color.Red;
                                lexicoSintacticoBox.Text += "Linea " + (i + 1) + ". " + s + " No se reconoce";

                            }
                            Line++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Faltan campos a rellenar");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("Error: " + E.Message);
            }
        }

        private void conversionButton_Click_1(object sender, EventArgs e)
        {
            string expresionRegular = expresionRegularResponse.Text;
            string expresionExplicita = convierteExplicita(expresionRegular);
            string expresionPostfija = ConvertirAPosfija(expresionExplicita);
            expresionPostfijaResponse.Text = expresionPostfija;
        }

        private void construirTablaM_Click(object sender, EventArgs e)
        {
            produccionLenguaje();
        }

        private void produccionLenguaje()
        {

            // Carga directamente la información

            List<(string, List<List<string>>)> producciones = new List<(string, List<List<string>>)>()
            {
        // programa -> secuencia-sent
        ("programa", new List<List<string>>
        {
            new List<string> { "secuencia-sent" }
        }),

        // secuencia-sent -> sentencia secuencia-sent'
        ("secuencia-sent", new List<List<string>>
        {
            new List<string> { "sentencia", "secuencia-sent'" }
        }),

        // sentencia -> sent-if | sent-repeat | sent-assign | sent-read | sent-write
        ("sentencia", new List<List<string>>
        {
            new List<string> { "sent-if" },
            new List<string> { "sent-repeat" },
            new List<string> { "sent-assign" },
            new List<string> { "sent-read" },
            new List<string> { "sent-write" }
        }),

        // sent-if -> if exp then secuencia-sent sent-if'
        ("sent-if", new List<List<string>>
        {
            new List<string> { "if", "exp", "then", "secuencia-sent", "sent-if'" }
        }),

        // sent-repeat -> repeat secuencia-sent until exp
        ("sent-repeat", new List<List<string>>
        {
            new List<string> { "repeat", "secuencia-sent", "until", "exp" }
        }),

        // sent-assign -> identificador := exp
        ("sent-assign", new List<List<string>>
        {
            new List<string> { "identificador", ":=", "exp" }
        }),

        // sent-read -> read identificador
        ("sent-read", new List<List<string>>
        {
            new List<string> { "read", "identificador" }
        }),

        // sent-write -> write exp
        ("sent-write", new List<List<string>>
        {
            new List<string> { "write", "exp" }
        }),

        // exp -> exp-simple exp'
        ("exp", new List<List<string>>
        {
            new List<string> { "exp-simple", "exp'" }
        }),

        // op-comp -> < | > | =
        ("op-comp", new List<List<string>>
        {
            new List<string> { "<" },
            new List<string> { ">" },
            new List<string> { "=" }
        }),

        // exp-simple -> term exp-simple'
        ("exp-simple", new List<List<string>>
        {
            new List<string> { "term", "exp-simple'" }
        }),

        // opsuma -> + | -
        ("opsuma", new List<List<string>>
        {
            new List<string> { "+" },
            new List<string> { "-" }
        }),

        // term -> factor term'
        ("term", new List<List<string>>
        {
            new List<string> { "factor", "term'" }
        }),

        // opmult -> * | /
        ("opmult", new List<List<string>>
        {
            new List<string> { "*" },
            new List<string> { "/" }
        }),

        // factor -> ( exp ) | numero | identificador
        ("factor", new List<List<string>>
        {
            new List<string> { "(", "exp", ")" },
            new List<string> { "numero" },
            new List<string> { "identificador" }
        }),

        // secuencia-sent' -> ; sentencia secuencia-sent' | ε
        ("secuencia-sent'", new List<List<string>>
        {
            new List<string> { ";", "sentencia", "secuencia-sent'" },
            new List<string> { "ε" }
        }),

        // exp-simple' -> opsuma term exp-simple' | ε
        ("exp-simple'", new List<List<string>>
        {
            new List<string> { "opsuma", "term", "exp-simple'" },
            new List<string> { "ε" }
        }),

        // term' -> opmult factor term' | ε
        ("term'", new List<List<string>>
        {
            new List<string> { "opmult", "factor", "term'" },
            new List<string> { "ε" }
        }),

        // sent-if' -> end | else secuencia-sent end
        ("sent-if'", new List<List<string>>
        {
            new List<string> { "end" },
            new List<string> { "else", "secuencia-sent", "end" }
        }),

        // exp' -> op-comp exp-simple | ε
        ("exp'", new List<List<string>>
        {
            new List<string> { "op-comp", "exp-simple" },
            new List<string> { "ε" }
        })
    };


            // Crea Primeros


            List<(string, List<string>)> primeros = new List<(string, List<string>)>()
        {
            ("programa", new List<string> { "if", "repeat", "identificador", "read", "write" }),
            ("secuencia-sent", new List<string> { "if", "repeat", "identificador", "read", "write" }),
            ("sentencia", new List<string> { "if", "repeat", "identificador", "read", "write" }),
            ("sent-if", new List<string> { "if" }),
            ("sent-repeat", new List<string> { "repeat" }),
            ("sent-assign", new List<string> { "identificador" }),
            ("sent-read", new List<string> { "read" }),
            ("sent-write", new List<string> { "write" }),
            ("exp", new List<string> { "(", "numero", "identificador" }),
            ("op-comp", new List<string> { "<", ">", "=" }),
            ("exp-simple", new List<string> { "(", "numero", "identificador" }),
            ("opsuma", new List<string> { "+", "-" }),
            ("term", new List<string> { "(", "numero", "identificador" }),
            ("opmult", new List<string> { "*", "/" }),
            ("factor", new List<string> { "(", "numero", "identificador" }),
            ("secuencia-sent'", new List<string> { ";", "ε" }),
            ("exp-simple'", new List<string> { "+", "-", "ε" }),
            ("term'", new List<string> { "*", "/", "ε" }),
            ("sent-if'", new List<string> { "end", "else" }),
            ("exp'", new List<string> { "<", ">", "=", "ε" }),
            ("if", new List<string> { "if" }),
            ("repeat", new List<string> { "repeat" }),
            ("identificador", new List<string> { "identificador" }),
            ("read", new List<string> { "read" }),
            ("write", new List<string> { "write" }),
            ("(", new List<string> { "(" }),
            ("numero", new List<string> { "numero" }),
            ("then", new List<string> { "then" }),
            ("until", new List<string> { "until" }),
            (":=", new List<string> { ":=" }),
            ("else", new List<string> { "else" }),
            ("end", new List<string> { "end" }),
            (";", new List<string> { ";" }),
            ("+", new List<string> { "+" }),
            ("-", new List<string> { "-" }),
            ("*", new List<string> { "*" }),
            ("/", new List<string> { "/" }),
            ("<", new List<string> { "<" }),
            (">", new List<string> { ">" }),
            ("=", new List<string> { "=" })
        };

            // Siguientes

            List<(string, List<string>)> siguientes = new List<(string, List<string>)>()
        {
            ("programa", new List<string> { "$" }),
            ("secuencia-sent", new List<string> { "end", "else", "until", "$" }),
            ("sentencia", new List<string> { "end", ";", "else", "until", "$" }),
            ("sent-if", new List<string> { "end", ";", "else", "until", "$" }),
            ("sent-repeat", new List<string> { "end", ";", "else", "until", "$" }),
            ("sent-assign", new List<string> { "end", ";", "else", "until", "$" }),
            ("sent-read", new List<string> { "end", ";", "else", "until", "$" }),
            ("sent-write", new List<string> { "end", ";", "else", "until", "$" }),
            ("exp", new List<string> { "end", ";", "else", "until", "$", ")", "then" }),
            ("op-comp", new List<string> { "(", "numero", "identificador" }),
            ("exp-simple", new List<string> { "<", ">", "=", "end", "else", "until", "then", ";", ")", "$" }),
            ("opsuma", new List<string> { "(", "numero", "identificador" }),
            ("term", new List<string> { "+", "-", "<", ">", "=", "end", "else", "until", "then", ";", ")", "$" }),
            ("opmult", new List<string> { "(", "numero", "identificador" }),
            ("factor", new List<string> { "*", "/", "+", "-", "<", ">", "=", "end", "else", "until", "then", ";", ")", "$" }),
            ("secuencia-sent'", new List<string> { "end", "else", "until", "$" }),
            ("sent-if'", new List<string> { "end", ";", "else", "until", "$" }),
            ("exp-simple'", new List<string> { "<", ">", "=", "end", "else", "until", "then", ";", ")", "$" }),
            ("term'", new List<string> { "+", "-", "<", ">", "=", "end", "else", "until", "then", ";", ")", "$" }),
            ("exp'", new List<string> { "end", ";", "else", "until", "$", ")", "then" })
        };
            llenaTablaAnalisis(producciones, primeros, siguientes);
        }

        private void llenaTablaAnalisis(List<(string, List<List<string>>)> producciones, List<(string, List<string>)> primeros, List<(string, List<string>)> siguientes)
        {
            tablaAnalisis.Rows.Clear();

            // Lista de terminales
            var terminales = new List<string> { "if", "repeat", "identificador", "read", "write", "numero", "then", "until", ":=", "else", "end", "(", ")", ";", "+", "-", "*", "/", "<", ">", "=", "$" };

            tablaAnalisis.ColumnCount = terminales.Count + 1; // Inicializar las columnas
            tablaAnalisis.Columns[0].Name = "No Terminal"; // Nombrar columna

            // Lista de no terminales
            var noTerminales = new List<string> { "programa", "secuencia-sent", "secuencia-sent'", "sentencia", "sent-if", "sent-if'", "sent-repeat", "sent-assign", "sent-read", "sent-write", "exp", "exp'", "op-comp", "exp-simple", "exp-simple'", "opsuma", "term", "term'", "opmult", "factor", };

            TablaM analizador = new TablaM(terminales);

            // Llena los terminales
            for (int i = 0; i < terminales.Count; i++)
            {
                tablaAnalisis.Columns[i + 1].Name = terminales[i];
            }

            // Llena los no terminales
            foreach (var nt in noTerminales)
            {
                tablaAnalisis.Rows.Add(nt);
            }



            foreach (var produccion in producciones)
            {

                var nt = produccion.Item1;
                var indexNT = noTerminales.IndexOf(nt);
                Dictionary<string, List<string>> currentNTDictionary = new Dictionary<string, List<string>>();

                foreach (var cuerpo in produccion.Item2)
                {
                    //textBox1.Text += nt + Environment.NewLine;

                    var primerosCuerpo = obtenerPrimeros(cuerpo, primeros); // Obtiene los primeros de la producción

                    /*
                    foreach (string s in primerosCuerpo) {

                            textBox1.Text += s + Environment.NewLine;
                    }


                    textBox1.Text += Environment.NewLine;*/





                    foreach (var terminal in primerosCuerpo.Where(t => t != "ε")) //busca todos los terminales que no sean epsilon
                    {

                        var indexT = terminales.IndexOf(terminal); // obtiene la columna -1 de donde se va a colocar la produccion en la tabla

                        if (tablaAnalisis.Rows[indexNT].Cells[indexT + 1].Value == null) //por alguna razon hace la verificacion de que la tabla este vacia
                        {
                            tablaAnalisis.Rows[indexNT].Cells[indexT + 1].Value = $"{nt}->{string.Join(" ", cuerpo)}";
                            //a;adir la produccion como un estado NTLL1
                            currentNTDictionary.Add(terminal, cuerpo);
                        }
                    }

                    if (primerosCuerpo.Contains("ε")) // Si los primeros de la producción incluyen cadena vacía
                    {
                        var siguienteNoTerminal = siguientes.FirstOrDefault(x => x.Item1 == nt).Item2; // Encuentra los siguientes del no terminal

                        if (siguienteNoTerminal != null)
                        {
                            foreach (var siguiente in siguienteNoTerminal)
                            {
                                var indexT = terminales.IndexOf(siguiente);
                                if (tablaAnalisis.Rows[indexNT].Cells[indexT + 1].Value == null)
                                {
                                    tablaAnalisis.Rows[indexNT].Cells[indexT + 1].Value = $"{nt}->{string.Join(" ", cuerpo)}"; ;
                                    currentNTDictionary.Add(siguiente, cuerpo);
                                }
                            }
                        }


                    }



                }

                analizador.agregarDerivacion(nt, currentNTDictionary);

            }


            analizador.simboloInicial = producciones[0].Item1;

            treeView1.Nodes.Clear();
            if (analizador.analisisSintactico(tokens) != null)
                treeView1.Nodes.Add(analizador.analisisSintactico(tokens));
            else
                lexicoSintacticoBox.Text += Environment.NewLine + "Hay un error sintactico";

            treeView1.ExpandAll();
            treeView1.Refresh();


            /*
             * 
            foreach (Token t in tokens) {
                textBox1.Text += t.valor +"   "+ t.tipo + Environment.NewLine; //acceder a la madre de tokens
            }

            //acceder a las derivaciones

            foreach (NTLL1 n in analizador.derivaciones) { 
                textBox1.Text += n.nombre + Environment.NewLine;
                foreach (var l in terminales) {
                    if (n.reducciones.ContainsKey(l)){
                        textBox1.Text += l+ ": " + Environment.NewLine;
                        foreach (string r in n.reducciones[l]) {
                            textBox1.Text += r + " || ";
                        }
                        textBox1.Text += Environment.NewLine;
                    }    
                    
                }
                textBox1.Text += Environment.NewLine;
            }
            */
        }


        private List<string> obtenerPrimeros(List<string> produccionCuerpo, List<(string, List<string>)> primeros)
        {



            var primerosProduccion = new List<string>();
            int indiceCuerpo = 0;
            int indicePrimeros = new int();
            if (produccionCuerpo.Contains("ε"))
            {
                primerosProduccion.Add("ε");
                return primerosProduccion;
            }


            do
            {
                for (int i = 0; i < primeros.Count(); i++)
                {
                    if (primeros[i].Item1 == produccionCuerpo[indiceCuerpo])
                        indicePrimeros = i;
                }

                foreach (string s in primeros[indicePrimeros].Item2.Where(t => t != "ε"))
                {
                    primerosProduccion.Add(s);
                }

                if (!primeros[indicePrimeros].Item2.Contains("ε"))
                {
                    return primerosProduccion;
                }
                else
                    indiceCuerpo++;
            }
            while (indiceCuerpo < produccionCuerpo.Count());

            //si todos los elementos de la produccion tienen epsilon en sus primeros entonces se agrega epsilon
            primerosProduccion.Add("ε");

            return primerosProduccion;
        }

        private void AnalisisLexicoSintactico_Click_1(object sender, EventArgs e)
        {
            //clasificarBoton(sender, e);
            if (tokens.Count == 0)
                MessageBox.Show("Es necesario clasificar los tokens primero");
            else
                produccionLenguaje();

        }
    }
}
