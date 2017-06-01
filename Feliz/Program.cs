using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<int> lista = new List<int>();
            for (int i = 0; i < 100; i++)
                if (VerificarNumero(i)) lista.Add(i);
            var recebe = GerarListaNumeros();

            lista.ForEach(i => Console.WriteLine("Feliz {0}", i));
            Console.ReadKey();

        }        

        public static List<int> GerarListaNumeros()
        {
            List<int> lista = new List<int>();
            for (int i = 0; i < 100; i++)
                if (VerificarNumero(i)) lista.Add(i);
            return lista;
        }

        public static bool VerificarNumero(int numero)
        {
            bool numeroFeliz = false;
            List<int> listaDigitos = new List<int>();
            listaDigitos = DividirDigitos(numero);
            for (int i = 0; i < 20 && !numeroFeliz; i++)
            {
                int sumaActual = CalcularQuadrados(listaDigitos);
                if (sumaActual != 1)
                    listaDigitos = DividirDigitos(sumaActual);
                else numeroFeliz = true;
            }
            return numeroFeliz;
        }
        
        public static List<int> DividirDigitos(int digito)
        {
            List<int> digitos = new List<int>();
            while (digito != 0)
            {
                digitos.Add(digito % 10);
                digito = digito / 10;
            }
            return digitos;
        }
        
        public static int CalcularQuadrados(List<int> listaDigitos)
        {
            int resultado = 0;
            foreach (int elem in listaDigitos) resultado += elem * elem;
            return resultado;
        }
    }
}
