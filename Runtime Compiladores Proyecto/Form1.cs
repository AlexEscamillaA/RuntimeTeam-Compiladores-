namespace Runtime_Compiladores_Proyecto
{
    public partial class Form1 : Form
    {
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

        
    }
}