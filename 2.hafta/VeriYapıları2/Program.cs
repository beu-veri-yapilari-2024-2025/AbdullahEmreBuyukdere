using System;

class Node
{
    public string Ad;
    public string Soyad;
    public int Numara;
    public Node Next;

    public Node(string ad, string soyad, int numara)
    {
        Ad = ad;
        Soyad = soyad;
        Numara = numara;
        Next = null;
    }
}

class LinkedList
{
    Node head;

    public LinkedList()
    {
        head = null;
    }

    // 🔹 Listenin başına ekleme
    public void BasaEkle(string ad, string soyad, int numara)
    {
        Node yeni = new Node(ad, soyad, numara);
        yeni.Next = head;
        head = yeni;
    }

    // 🔹 Listenin sonuna ekleme
    public void SonaEkle(string ad, string soyad, int numara)
    {
        Node yeni = new Node(ad, soyad, numara);

        if (head == null)
        {
            head = yeni;
            return;
        }

        Node temp = head;
        while (temp.Next != null)
            temp = temp.Next;

        temp.Next = yeni;
    }

    // 🔹 Belirli numaradan sonrasına ekleme
    public void NumaraSonrasinaEkle(int numara, string ad, string soyad, int yeniNumara)
    {
        Node temp = head;
        while (temp != null && temp.Numara != numara)
            temp = temp.Next;

        if (temp == null)
        {
            Console.WriteLine("Belirtilen numara bulunamadı.");
            return;
        }

        Node yeni = new Node(ad, soyad, yeniNumara);
        yeni.Next = temp.Next;
        temp.Next = yeni;
    }

    // 🔹 Belirli numaraya sahip öğrenciyi silme
    public void NumaraIleSil(int numara)
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        if (head.Numara == numara)
        {
            head = head.Next;
            Console.WriteLine($"{numara} numaralı öğrenci silindi.");
            return;
        }

        Node temp = head;
        while (temp.Next != null && temp.Next.Numara != numara)
            temp = temp.Next;

        if (temp.Next == null)
            Console.WriteLine("Öğrenci bulunamadı.");
        else
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine($"{numara} numaralı öğrenci silindi.");
        }
    }

    // 🔹 Arama
    public void Ara(int numara)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Numara == numara)
            {
                Console.WriteLine($"Bulundu: {temp.Ad} {temp.Soyad} - {temp.Numara}");
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Öğrenci bulunamadı.");
    }

    // 🔹 Listeleme
    public void Listele()
    {
        Node temp = head;
        if (temp == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        Console.WriteLine("\n📋 Öğrenci Listesi:");
        while (temp != null)
        {
            Console.WriteLine($"{temp.Ad} {temp.Soyad} - {temp.Numara}");
            temp = temp.Next;
        }
    }

    // 🔹 Kullanıcıdan değer alarak ekleme
    public void KullaniciEkle()
    {
        Console.Write("Ad: ");
        string ad = Console.ReadLine();

        Console.Write("Soyad: ");
        string soyad = Console.ReadLine();

        Console.Write("Numara: ");
        int numara = int.Parse(Console.ReadLine());

        SonaEkle(ad, soyad, numara);
        Console.WriteLine("✅ Öğrenci başarıyla eklendi!");
    }
}

class Program
{
    static void Main()
    {
        LinkedList ogrenciler = new LinkedList();

        // Başlangıçta senin öğrencilerin eklensin:
        ogrenciler.SonaEkle("Emre", "Büyükdere", 11);
        ogrenciler.SonaEkle("Bedirhan", "Yıldız", 12);
        ogrenciler.SonaEkle("Murat", "Sili", 13);
        ogrenciler.SonaEkle("Kasım", "Özer", 14);
        ogrenciler.SonaEkle("Fırat", "Zülfikar", 15);

        int secim = -1;
        while (secim != 0)
        {
            Console.WriteLine("\n--- 🎓 ÖĞRENCİ LİSTE MENÜSÜ ---");
            Console.WriteLine("1 - Öğrencileri Listele");
            Console.WriteLine("2 - Yeni Öğrenci Ekle");
            Console.WriteLine("3 - Başına Öğrenci Ekle");
            Console.WriteLine("4 - Numara ile Arama");
            Console.WriteLine("5 - Numara ile Silme");
            Console.WriteLine("6 - Belirli Numaranın Sonrasına Ekle");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçiminiz: ");
            secim = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (secim)
            {
                case 1:
                    ogrenciler.Listele();
                    break;

                case 2:
                    ogrenciler.KullaniciEkle();
                    break;

                case 3:
                    Console.Write("Ad: ");
                    string adB = Console.ReadLine();
                    Console.Write("Soyad: ");
                    string soyadB = Console.ReadLine();
                    Console.Write("Numara: ");
                    int numaraB = int.Parse(Console.ReadLine());
                    ogrenciler.BasaEkle(adB, soyadB, numaraB);
                    Console.WriteLine("✅ Öğrenci listenin başına eklendi!");
                    break;

                case 4:
                    Console.Write("Aranacak numara: ");
                    int aranan = int.Parse(Console.ReadLine());
                    ogrenciler.Ara(aranan);
                    break;

                case 5:
                    Console.Write("Silinecek numara: ");
                    int silinecek = int.Parse(Console.ReadLine());
                    ogrenciler.NumaraIleSil(silinecek);
                    break;

                case 6:
                    Console.Write("Ekleme yapılacak öğrencinin numarası: ");
                    int hedef = int.Parse(Console.ReadLine());
                    Console.Write("Yeni öğrencinin adı: ");
                    string adYeni = Console.ReadLine();
                    Console.Write("Yeni öğrencinin soyadı: ");
                    string soyadYeni = Console.ReadLine();
                    Console.Write("Yeni öğrencinin numarası: ");
                    int numaraYeni = int.Parse(Console.ReadLine());
                    ogrenciler.NumaraSonrasinaEkle(hedef, adYeni, soyadYeni, numaraYeni);
                    break;

                case 0:
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim, tekrar deneyin.");
                    break;
            }
        }
    }
}
