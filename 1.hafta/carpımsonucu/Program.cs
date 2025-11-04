using System;

namespace Odev1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrisA = new int[2, 3] { { 8, 6, 2 }, { 8, 3, 5 } }; 
            int[,] matrisB = new int[3, 2] { { 9, 1 }, { 7, 5 }, { 8, 2 } }; 

        
            int satir1 = matrisA.GetLength(0);
            int sutun1 =  matrisA.GetLength(1);
            int satir2 = matrisB.GetLength(0);
            int sutun2 = matrisB.GetLength(1);

            int[,] carpimSonuc = new int[satir1, sutun2];

            for (int x = 0; x < satir1; x++)
            {
               for (int y = 0; y < sutun2; y++)
                {
                    int toplam = 0; 

                  
                    for (int z = 0; z < sutun2; z++)
                    {
                        
                        toplam += matrisA[x, z] * matrisB[z, y];
                    }

                    carpimSonuc[x, y] = toplam;
                }
            }

            //Sonuç
            Console.WriteLine("Sonuç:");
            for (int i = 0; i < satir1; i++)
            {
                for (int j = 0; j < sutun2; j++)
                {
                    Console.Write(carpimSonuc[i, j] + "\t");
                }
                Console.WriteLine(); 
            }

            Console.ReadLine();
        }
    }
}
