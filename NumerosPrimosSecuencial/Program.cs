using System;
using System.Diagnostics;

class Program
{
    static int EsPrimo(int numero)
    {
        if (numero < 2) return 0;
        for (int i = 2; i * i <= numero; i++)
        {
            if (numero % i == 0) return 0;
        }
        return numero;
    }

    static void Main()
    {
        Console.WriteLine("Ingrese el número límite:");
        int N = int.Parse(Console.ReadLine());

        Stopwatch stopwatch = Stopwatch.StartNew();

        int sumaTotal = 0;
        for (int i = 1; i <= N; i++)
        {
            sumaTotal += EsPrimo(i);
        }

       
        stopwatch.Stop();
        Console.WriteLine($"Suma total de números primos hasta {N}: {sumaTotal}");
        Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
    }
}