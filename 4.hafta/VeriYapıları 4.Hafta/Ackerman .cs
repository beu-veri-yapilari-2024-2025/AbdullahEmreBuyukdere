using System;

public class AckermannOrnegi
{
    // 🔹 ACKERMANN FONKSİYONU (Rekürsif)
    public int Ackermann(int m, int n)
    {
        if (m < 0 || n < 0)
            throw new ArgumentException("Ackermann fonksiyonu negatif sayılar için tanımlı değildir.");

        if (m == 0)
            return n + 1;
        else if (n == 0)
            return Ackermann(m - 1, 1);
        else
            return Ackermann(m - 1, Ackermann(m, n - 1));
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("=== ACKERMANN FONKSİYONU HESAPLAMA ===");
       
       
        int m, n;
        Console.Write("m değerini giriniz: ");
        while (!int.TryParse(Console.ReadLine(), out m) || m < 0)
            Console.Write("Lütfen 0 veya daha büyük bir m değeri giriniz: ");

        Console.Write("n değerini giriniz: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            Console.Write("Lütfen 0 veya daha büyük bir n değeri giriniz: ");

        // 🔹 Hesaplama
        AckermannOrnegi hesaplayici = new AckermannOrnegi();

        try
        {
            int sonuc = hesaplayici.Ackermann(m, n);
            Console.WriteLine($"\nA({m}, {n}) = {sonuc}");
        }
        catch (StackOverflowException)
        {
            Console.WriteLine("\n⚠️ Çok büyük değer girdiniz! Derin özyineleme nedeniyle bellek sınırını aştı.");
        }

        Console.WriteLine("\nProgram tamamlandı. Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
