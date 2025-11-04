using System;
namespace Odev2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sıralı bir dizi oluşturuyoruz
            int[] dizi = { 5, 12, 19, 23, 31, 45, 56, 67, 78 };
            Console.Write("Lütfen aranacak değeri giriniz: ");
            int aranan = Convert.ToInt32(Console.ReadLine());
            // Recursive ikili arama fonksiyonunu çağırıyoruz.
            int bulunan = RecursiveIkiliArama(dizi, aranan, 0, dizi.Length - 1);
            if (bulunan >= 0)
                Console.WriteLine($"{aranan} değeri dizinin {bulunan}. konumunda bulundu.");
            else
                Console.WriteLine($"{aranan} değeri dizide mevcut değil.");
            Console.ReadLine();
        }
      
        public static int RecursiveIkiliArama(int[] dizi, int aranan, int ilk, int son)
        {
            if (ilk <= son)
            {
                int orta = ilk + (son - ilk) / 2;
                if (dizi[orta] == aranan)
                    return orta;
                else if (dizi[orta] > aranan)
                    return RecursiveIkiliArama(dizi, aranan, ilk, orta - 1);
                else
                    return RecursiveIkiliArama(dizi, aranan, orta + 1, son);
            }
            return -1; 
        }
    }
}