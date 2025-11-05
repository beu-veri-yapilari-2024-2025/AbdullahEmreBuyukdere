using System;
using System.Linq;

public class StandartSapmaOrnegi
{
    public double Ortalama(double[] sayilar)
    {
        double toplam = 0;
        foreach (var s in sayilar)
            toplam += s;
        return toplam / sayilar.Length;
    }

    public double StandartSapma(double[] sayilar)
    {
        double ortalama = Ortalama(sayilar);
        double toplamKareFark = 0;
        foreach (var s in sayilar)
            toplamKareFark += Math.Pow(s - ortalama, 2);

        double varyans = toplamKareFark / sayilar.Length; // population
        return Math.Sqrt(varyans);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("=== STANDART SAPMA HESAPLAMA PROGRAMI ===");
        Console.WriteLine("Lütfen aralarına boşluk koyarak sayıları giriniz:");
        Console.WriteLine("Örnek: 10 20 30 40 50\n");

        string girdi = Console.ReadLine();

        // Burada uyumlu olan güvenli kullanım:
        string[] parcalar = girdi.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        double[] sayilar;
        try
        {
            sayilar = parcalar.Select(s => double.Parse(s)).ToArray();
        }
        catch (FormatException)
        {
            Console.WriteLine("Hatalı giriş: Lütfen sadece sayı giriniz ve aralarında boşluk bırakınız.");
            return;
        }

        var hesaplayici = new StandartSapmaOrnegi();
        double ort = hesaplayici.Ortalama(sayilar);
        double sapma = hesaplayici.StandartSapma(sayilar);

        Console.WriteLine($"\nOrtalama: {ort:F2}");
        Console.WriteLine($"Standart Sapma: {sapma:F4}");
        Console.WriteLine("\nÇıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
