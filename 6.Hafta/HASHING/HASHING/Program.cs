using System;

class Program
{
    static void Main()
    {
        int boyut = 100;
        int[] hashTablosu = new int[boyut];
        int[] hashTablosu2 = new int[boyut];

        Random rnd = new Random();

        // ============================
        // 1) LINEER PROBING
        // ============================

        for (int i = 0; i < 100; i++)
        {
            int sayi = rnd.Next(1, 1000);

            int indeks = sayi % boyut;  

        
            while (hashTablosu[indeks] != 0)
            {
                indeks = (indeks + 1) % boyut;
            }

            hashTablosu[indeks] = sayi;
        }

        // ============================
        // 2) QUADRATIC PROBING
        // ============================

        for (int i = 0; i < 100; i++)
        {
            int sayi = rnd.Next(1, 1000);

            int indeks = sayi % boyut; 

            if (hashTablosu2[indeks] != 0)
            {
                
                int j = 1;
                bool yerlesti = false;

                while (!yerlesti && j < boyut)
                {
                    int yeniIndeks = (indeks + j * j) % boyut;

                    if (hashTablosu2[yeniIndeks] == 0)
                    {
                        hashTablosu2[yeniIndeks] = sayi;
                        yerlesti = true;
                    }

                    j++;
                }
            }
            else
            {
                hashTablosu2[indeks] = sayi;
            }
        }

        // ============================
        // ÇIKTI
        // ============================
        Console.WriteLine("==== LINEER PROBING ====");
        for (int i = 0; i < boyut; i++)
        {
            Console.WriteLine($"{i}. indeks = {hashTablosu[i]}");
        }

        Console.WriteLine("\n==== QUADRATIC PROBING ====");
        for (int i = 0; i < boyut; i++)
        {
            Console.WriteLine($"{i}. indeks = {hashTablosu2[i]}");
        }
    }
}
