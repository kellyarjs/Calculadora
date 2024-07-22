using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Operacoes> filaOperacoes = new Queue<Operacoes>();
            filaOperacoes.Enqueue(new Operacoes { valorA = 2, valorB = 3, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 14, valorB = 8, operador = '-' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 5, valorB = 6, operador = '*' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 2147483647, valorB = 2, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 18, valorB = 3, operador = '/' });

            Calculadora calculadora = new Calculadora();

            Stack<BigInteger> pilhaResultados = new Stack<BigInteger>();

            while (filaOperacoes.Count > 0)
            {
                Console.WriteLine("\nOperação atual:");
                Operacoes operacao = filaOperacoes.Dequeue();
                calculadora.calcular(operacao);
                Console.WriteLine("{0} {1} {2} = {3}", operacao.valorA,operacao.operador,operacao.valorB, operacao.resultado);
                Console.WriteLine("\nLista de operações a serem processadas:");

                foreach (var calculoFila in filaOperacoes)
                {
                    Console.WriteLine(calculoFila.valorA +"   "+ calculoFila.operador +"   "+ calculoFila.valorB);
                }
                Console.WriteLine("\n=======================================================");

                pilhaResultados.Push(operacao.resultado);   
            }
            Console.WriteLine("Resultados dos cálculos efetuados:");
            foreach (var resultadoPilha in pilhaResultados)
            {
                Console.WriteLine(resultadoPilha);
            }
        }
    }
}
