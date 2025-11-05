using System;

public class FibonacciOrnegi
{
    // 🔹 1. REKÜRSİF METOT (Özyinelemeli)
    public int HesaplaFibonacci(int n)
    {
        if (n < 0)
            throw new ArgumentException("Negatif sayı için Fibonacci hesaplanamaz.");

        if (n == 0) return 0;
        if (n == 1) return 1;

        return HesaplaFibonacci(n - 1) + HesaplaFibonacci(n - 2);
    }

    // 🔹 2. DÖNGÜ İLE (Iteratif) METOT
    public int HesaplaFibonacciFor(int n)
    {
        if (n < 0)
            throw new ArgumentException("Negatif sayı için Fibonacci hesaplanamaz.");

        if (n == 0) return 0;
        if (n == 1) return 1;

        int onceki1 = 0;
        int onceki2 = 1;
        int mevcut = 0;

        for (int i = 2; i <= n; i++)
        {
            mevcut = onceki1 + onceki2;
            onceki1 = onceki2;
            onceki2 = mevcut;
        }

        return mevcut;
    }

    // 🔹 3. MAIN METODU
    public static void Main(string[] args)
    {
        Console.WriteLine("=== FİBONACCİ HESAPLAMA PROGRAMI ===");
        Console.Write("Bir sayı giriniz: ");

        // Kullanıcıdan girdi al
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
        {
            Console.Write("Lütfen 0 veya daha büyük bir tam sayı giriniz: ");
        }

        // Nesne oluştur
        FibonacciOrnegi hesaplayici = new FibonacciOrnegi();

        // Hesaplamaları yap
        int sonucRekursif = hesaplayici.HesaplaFibonacci(n);
        int sonucFor = hesaplayici.HesaplaFibonacciFor(n);

        // Sonuçları ekrana yazdır
        Console.WriteLine($"\nRekürsif Fibonacci({n}) = {sonucRekursif}");
        Console.WriteLine($"Döngüyle Fibonacci({n}) = {sonucFor}");

        Console.WriteLine("\nProgram tamamlandı. Çıkmak için bir tuşa basın...");
        Console.ReadKey();








    }
}
