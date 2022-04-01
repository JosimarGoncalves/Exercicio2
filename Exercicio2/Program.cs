using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    public static int[] numeroSorteado = new int[100];
    public static int valorMinimo = 100;
    public static int valorMaximo = 500;
    

    static void Main()
    {
        Random numeroAleatorio = new Random();

        var stopWatch = new Stopwatch();

        stopWatch.Start();
        
        Console.WriteLine("Numeros Sorteados:");
        PularLinha();
        for (int i = 0; i <numeroSorteado.Length; i++)
        {
            numeroSorteado[i] = numeroAleatorio.Next(valorMinimo, valorMaximo);
        }

        
        

        Thread t1 = new Thread(BuscarMaiorValor);
        t1.Start();

        Thread t2 = new Thread(BuscarMenorValor);
        t2.Start();

        t1.Join();
        t2.Join();

        int maiorValorEncontrado = numeroSorteado[0];
        int menorValorEncontrado = numeroSorteado[0];

        for (int i = 0; i < numeroSorteado.Length; i++)
        {
            if (numeroSorteado[i] > maiorValorEncontrado)
            {
                maiorValorEncontrado = numeroSorteado[i];
            }

            if (numeroSorteado[i] < menorValorEncontrado)
            {
                menorValorEncontrado = numeroSorteado[i];
            }
        }

        PularLinha();

        Console.WriteLine("\nMaior valor encontrado: " + maiorValorEncontrado + "  " + "e o Menor valor encontrado: " + menorValorEncontrado);
        PularLinha();

        stopWatch.Start();

        Console.WriteLine($"O Tempo de processamento total é de {stopWatch.ElapsedMilliseconds}ms");
    }

    public static void BuscarMaiorValor()
    {
        for (int i = 1; i <numeroSorteado.Length; i++)
        {
            Console.Write(numeroSorteado[i] + " - ");
                      
        }
       
    }

    public static void BuscarMenorValor()
    {
        for (int i = 0; i < numeroSorteado.Length; i++)
        {
            Console.Write(numeroSorteado[i] + " - ");
            

        }
       
    }

    public static void PularLinha()
    {
        Console.WriteLine("  ");
    }


}