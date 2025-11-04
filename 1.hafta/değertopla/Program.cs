using System;
class Program
{
    static void Main()
    {
        int[] degerler = { 3, 13, 23, 33, 43, 53 };
        int sonuc = 0;
        for (int j = 0; j < degerler.Length; j++)
        {
            sonuc += degerler[j];
        }
        Console.WriteLine("Dizideki değerlerin toplamı: " + sonuc);
    }
}