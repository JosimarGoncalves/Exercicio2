using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    public static int[] numeroSorteado = new int[100];
    public static int valorMinimo = 15;
    public static int valorMaximo = 500;
    public static int maiorValorEncontrado =0;
    public static int menorValorEncontrado = 0;

    static void Main()
    {
        Random numeroAleatorio = new Random();

        var stopWatch = new Stopwatch();

       

        for (int i = 0; i <numeroSorteado.Length; i++)
        {
            numeroSorteado[i] = numeroAleatorio.Next(valorMinimo, valorMaximo);
        }
        

        //stopWatch.Start();

        Thread t1 = new Thread(BuscarMaiorValor);
        t1.Start();

        Thread t2 = new Thread(BuscarMenorValor);
        t2.Start();

        t1.Join();
        t2.Join();


        Console.WriteLine("\nMaior valor encontrado: " + maiorValorEncontrado + "  " + "e o Menor valor encontrado: " + menorValorEncontrado);



    }

    public static void BuscarMaiorValor()
    {
        for (int i = 1; i <numeroSorteado.Length; i++)
        {
            Console.Write(numeroSorteado[i] + " - ");
            if (numeroSorteado[i] > maiorValorEncontrado)
            {
                maiorValorEncontrado = numeroSorteado[i];
            }
            
        }
       
    }

    public static void BuscarMenorValor()
    {
        for (int i = 1; i < numeroSorteado.Length; i++)
        {
            Console.Write(numeroSorteado[i] + " - ");
            if (numeroSorteado[i] < menorValorEncontrado)
            {
                menorValorEncontrado = numeroSorteado[i];
            }

        }
        
    }

    public static void PularLinha()
    {
        Console.WriteLine("  ");
    }


}