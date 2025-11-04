using System;
using System.Collections.Generic;

public class Araba
{
    public string Plaka { get; set; }
    public string Model { get; set; }
    public int Yil { get; set; }

    public Araba(string plaka, string model, int yil)
    {
        Plaka = plaka;
        Model = model;
        Yil = yil;
    }

    public override string ToString()
    {
        return $"Plaka: {Plaka}, Model: {Model}, Yıl: {Yil}";
    }
}

public class Node
{
    public Araba Data;
    public Node Next;
    public Node Prev;

    public Node(Araba data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

public class ArabaListesi
{
    Node head;
    Node tail;

    // BAŞA EKLEME
    public void BasaEkle(Araba araba)
    {
        Node yeni = new Node(araba);
        if (head == null)
            head = tail = yeni;
        else
        {
            yeni.Next = head;
            head.Prev = yeni;
            head = yeni;
        }
    }

    // SONA EKLEME
    public void SonaEkle(Araba araba)
    {
        Node yeni = new Node(araba);
        if (tail == null)
            head = tail = yeni;
        else
        {
            tail.Next = yeni;
            yeni.Prev = tail;
            tail = yeni;
        }
    }

    // ARAYA (SONRA) EKLEME
    public void SonraEkle(string plaka, Araba yeniAraba)
    {
        Node temp = head;
        while (temp != null && temp.Data.Plaka != plaka)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Plaka bulunamadı!");
            return;
        }

        Node yeni = new Node(yeniAraba);
        yeni.Next = temp.Next;
        yeni.Prev = temp;

        if (temp.Next != null)
            temp.Next.Prev = yeni;
        else
            tail = yeni;

        temp.Next = yeni;
    }

    // ARAYA (ÖNCE) EKLEME
    public void OnceEkle(string plaka, Araba yeniAraba)
    {
        Node temp = head;
        while (temp != null && temp.Data.Plaka != plaka)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Plaka bulunamadı!");
            return;
        }

        Node yeni = new Node(yeniAraba);
        yeni.Next = temp;
        yeni.Prev = temp.Prev;

        if (temp.Prev != null)
            temp.Prev.Next = yeni;
        else
            head = yeni;

        temp.Prev = yeni;
    }

    // BAŞTAN SİLME
    public void BastanSil()
    {
        if (head == null) return;

        head = head.Next;

        if (head != null)
            head.Prev = null;
        else
            tail = null;
    }

    // SONDAN SİLME
    public void SondanSil()
    {
        if (tail == null) return;

        tail = tail.Prev;

        if (tail != null)
            tail.Next = null;
        else
            head = null;
    }

    // ARADAN SİLME
    public void PlakaIleSil(string plaka)
    {
        Node temp = head;
        while (temp != null && temp.Data.Plaka != plaka)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Plaka bulunamadı!");
            return;
        }

        if (temp.Prev != null)
            temp.Prev.Next = temp.Next;
        else
            head = temp.Next;

        if (temp.Next != null)
            temp.Next.Prev = temp.Prev;
        else
            tail = temp.Prev;
    }

    // ARAMA
    public void Ara(string plaka)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.Plaka == plaka)
            {
                Console.WriteLine("Araba bulundu → " + temp.Data);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Aranan araba yok.");
    }

    // LİSTELEME
    public void Listele()
    {
        Node t = head;
        Console.WriteLine("\n--- ARABA LİSTESİ ---");
        while (t != null)
        {
            Console.WriteLine(t.Data);
            t = t.Next;
        }
        Console.WriteLine("---------------------\n");
    }

    // TÜMÜNÜ SİLME
    public void TumunuSil()
    {
        head = tail = null;
        Console.WriteLine("Tüm liste silindi.");
    }
}

class Program
{
    static void Main()
    {
        ArabaListesi liste = new ArabaListesi();
        int secim;

        do
        {
            Console.WriteLine("\n===== ARABA YÖNETİM MENÜSÜ =====");
            Console.WriteLine("1) Başa Ekle");
            Console.WriteLine("2) Sona Ekle");
            Console.WriteLine("3) Araya (Sonra) Ekle");
            Console.WriteLine("4) Araya (Önce) Ekle");
            Console.WriteLine("5) Baştan Sil");
            Console.WriteLine("6) Sondan Sil");
            Console.WriteLine("7) Plaka ile Sil");
            Console.WriteLine("8) Ara");
            Console.WriteLine("9) Listele");
            Console.WriteLine("10) Tümünü Sil");
            Console.WriteLine("0) Çıkış");
            Console.Write("Seçim: ");
            secim = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (secim)
            {
                case 1:
                    liste.BasaEkle(ArabaGir());
                    break;

                case 2:
                    liste.SonaEkle(ArabaGir());
                    break;

                case 3:
                    Console.Write("Hangi plakanın SONRASINA eklensin? ");
                    liste.SonraEkle(Console.ReadLine(), ArabaGir());
                    break;

                case 4:
                    Console.Write("Hangi plakanın ÖNCESİNE eklensin? ");
                    liste.OnceEkle(Console.ReadLine(), ArabaGir());
                    break;

                case 5:
                    liste.BastanSil();
                    break;

                case 6:
                    liste.SondanSil();
                    break;

                case 7:
                    Console.Write("Silinecek plaka: ");
                    liste.PlakaIleSil(Console.ReadLine());
                    break;

                case 8:
                    Console.Write("Aranacak plaka: ");
                    liste.Ara(Console.ReadLine());
                    break;

                case 9:
                    liste.Listele();
                    break;

                case 10:
                    liste.TumunuSil();
                    break;
            }

        } while (secim != 0);
    }

    static Araba ArabaGir()
    {
        Console.Write("Plaka: ");
        string p = Console.ReadLine();

        Console.Write("Model: ");
        string m = Console.ReadLine();

        Console.Write("Yıl: ");
        int y = int.Parse(Console.ReadLine());

        return new Araba(p, m, y);
    }
}
