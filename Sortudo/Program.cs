using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication2
{
    class Program
    {
        public class NumeroSortudo
        {
            public string GetNumeroSortudo(int range)
            {
                return ImprimirResultado(FindNumeroSortudo(range));
            }

            public string GetsortudoPrimoNumeros(int range)
            {
                bool[] numeros = FindNumeroSortudo(range);

                for (int i = 0; i < numeros.Length; i++)
                {
                    if (numeros[i]) continue;
                    numeros[i] = !NumeroPrimo(i + 1);
                }

                return ImprimirResultado(numeros);
            }

            private bool[] FindNumeroSortudo(int range)
            {
                if (range < 1) range = 0;
                bool[] numeros = new bool[range];
                int sortudoContar = 2;

                while (sortudoContar < numeros.Length)
                {
                    sortudoContar = NumeroFora(numeros, sortudoContar);
                }

                return numeros;
            }

            private int NumeroFora(bool[] numeros, int sortudoContar)
            {
                int contador = 0;

                for (int i = 0; i < numeros.Length; i++)
                {
                    if (numeros[i]) continue;
                    contador++;

                    if (contador == sortudoContar)
                    {
                        numeros[i] = true;
                        contador = 0;
                    }
                }

                return GetsortudoContar(numeros, sortudoContar);
            }

            private int GetsortudoContar(bool[] numeros, int pular)
            {
                if (pular >= numeros.Length) return numeros.Length;

                for (int i = pular; i < numeros.Length; i++)
                {
                    if (!numeros[i]) return i + 1;
                }

                return numeros.Length;
            }

            private static bool NumeroPrimo(int numero)
            {
                if (numero == 1) return false;

                for (short i = 3; i <= Math.Sqrt(numero); i += 2)
                {
                    if (numero % i == 0) return false;
                }

                return true;
            }

            private static string ImprimirResultado(bool[] numeros)
            {
                string resultado = string.Empty;

                for (int i = 0; i < numeros.Length; i++)
                {
                    if (!numeros[i]) resultado = resultado + (i + 1) + ",";
                }

                if (!string.IsNullOrEmpty(resultado)) resultado = resultado.Substring(0, resultado.Length - 1);

                return resultado;
            }
        }


        static void Main(string[] args)
        {
            // arrange
            NumeroSortudo sortudo = new NumeroSortudo();
            IDictionary<int, string> CasoTeste = new Dictionary<int, string>();
            for (int i = 0; i < 100; i++)
            {
                CasoTeste.Add(i, Convert.ToString(i));                
            }
            // act
            foreach (var testCase in CasoTeste)
            {
                string resultado = sortudo.GetNumeroSortudo(testCase.Key);

                // assert
                Console.WriteLine("{0}", resultado);
                
            }
            Console.ReadKey();
        }
        
    }
}
