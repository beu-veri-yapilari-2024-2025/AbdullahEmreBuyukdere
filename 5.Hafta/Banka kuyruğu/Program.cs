using System;
using System.Collections.Generic;
using System.Linq;

// Müşteri öncelik seviyeleri (Öncelik 1 en yüksek)
public enum Oncelik
{
    Yuksek = 1, // Kredi, Hesap Açma
    Orta = 2,   // Para Transferi
    Dusuk = 3   // Fatura, Bilgi Güncelleme
}

// Banka Müşterisi Sınıfı
public class Musteri
{
    public string Ad;
    public Oncelik OncelikSeviyesi;

    public Musteri(string ad, Oncelik oncelik)
    {
        Ad = ad;
        OncelikSeviyesi = oncelik;
    }

    public override string ToString()
    {
        return $"[{Ad} - Öncelik: {(int)OncelikSeviyesi}]";
    }
}

// --- 1. DİZİ (Array/List) MANTIĞI İLE ÖNCELİKLİ KUYRUK ---
public class ArrayPriorityQueue
{
    private List<Musteri> kuyruk;

    public ArrayPriorityQueue()
    {
        kuyruk = new List<Musteri>();
    }

    // Ekleme (Enqueue): Listenin sonuna ekle
    public void Enqueue(Musteri musteri)
    {
        kuyruk.Add(musteri);
        Console.WriteLine($"[Array Kuyruk] Eklendi: {musteri.Ad} ({musteri.OncelikSeviyesi}).");
    }

    // Çıkarma (Dequeue): En yüksek öncelikli müşteriyi bul ve çıkar (O(N) karmaşıklık)
    public Musteri Dequeue()
    {
        if (kuyruk.Count == 0)
        {
            Console.WriteLine("[Array Kuyruk] Kuyruk boş.");
            return null;
        }

        Musteri yuksekOncelikliMusteri = kuyruk[0];
        int cikarilacakIndex = 0;

        for (int i = 1; i < kuyruk.Count; i++)
        {
            if (kuyruk[i].OncelikSeviyesi < yuksekOncelikliMusteri.OncelikSeviyesi)
            {
                // Daha düşük sayısal değere sahip öncelik (yani daha yüksek öncelik) bulundu
                yuksekOncelikliMusteri = kuyruk[i];
                cikarilacakIndex = i;
            }
        }

        kuyruk.RemoveAt(cikarilacakIndex);
        return yuksekOncelikliMusteri;
    }

    public void Goster()
    {
        if (kuyruk.Count == 0)
        {
            Console.WriteLine("Kuyruk: [Boş]");
            return;
        }
        Console.WriteLine("Kuyruk: " + string.Join(" -> ", kuyruk));
    }
}

// --- 2. BAĞLI LİSTE (Linked List) MANTIĞI İLE ÖNCELİKLİ KUYRUK ---
public class LinkedListPriorityQueue
{
    // Her öncelik seviyesi için ayrı bir bağlı liste tutar.
    private Dictionary<Oncelik, LinkedList<Musteri>> oncelikliKuyruklar;

    public LinkedListPriorityQueue()
    {
        oncelikliKuyruklar = new Dictionary<Oncelik, LinkedList<Musteri>>();
        oncelikliKuyruklar.Add(Oncelik.Yuksek, new LinkedList<Musteri>());
        oncelikliKuyruklar.Add(Oncelik.Orta, new LinkedList<Musteri>());
        oncelikliKuyruklar.Add(Oncelik.Dusuk, new LinkedList<Musteri>());
    }

    // Ekleme (Enqueue): Müşteriyi ait olduğu öncelik grubunun sonuna ekle (O(1) karmaşıklık)
    public void Enqueue(Musteri musteri)
    {
        oncelikliKuyruklar[musteri.OncelikSeviyesi].AddLast(musteri);
        Console.WriteLine($"[Linked Kuyruk] Eklendi: {musteri.Ad} ({musteri.OncelikSeviyesi}).");
    }

    // Çıkarma (Dequeue): En yüksek öncelikli grubun ilk elemanını al (O(1) karmaşıklık)
    public Musteri Dequeue()
    {
        // Öncelik sırasına göre kontrol et (1 > 2 > 3)
        if (oncelikliKuyruklar[Oncelik.Yuksek].Count > 0)
        {
            return Cikar(Oncelik.Yuksek);
        }

        if (oncelikliKuyruklar[Oncelik.Orta].Count > 0)
        {
            return Cikar(Oncelik.Orta);
        }

        if (oncelikliKuyruklar[Oncelik.Dusuk].Count > 0)
        {
            return Cikar(Oncelik.Dusuk);
        }

        Console.WriteLine("[Linked Kuyruk] Kuyruk boş.");
        return null;
    }

    private Musteri Cikar(Oncelik oncelik)
    {
        // Bağlı listenin ilk elemanını al ve listeden kaldır
        Musteri musteri = oncelikliKuyruklar[oncelik].First.Value;
        oncelikliKuyruklar[oncelik].RemoveFirst();
        return musteri;
    }

    public void Goster()
    {
        Console.WriteLine("Kuyruk (Yuksek): " + (oncelikliKuyruklar[Oncelik.Yuksek].Count > 0 ? string.Join(" -> ", oncelikliKuyruklar[Oncelik.Yuksek]) : "[Boş]"));
        Console.WriteLine("Kuyruk (Orta):   " + (oncelikliKuyruklar[Oncelik.Orta].Count > 0 ? string.Join(" -> ", oncelikliKuyruklar[Oncelik.Orta]) : "[Boş]"));
        Console.WriteLine("Kuyruk (Dusuk):  " + (oncelikliKuyruklar[Oncelik.Dusuk].Count > 0 ? string.Join(" -> ", oncelikliKuyruklar[Oncelik.Dusuk]) : "[Boş]"));
    }
}


public class Program
{
    // İş seçimine göre otomatik öncelik atayan yardımcı metod
    public static Musteri MusteriOlustur(string ad, string islem)
    {
        Oncelik oncelik;
        string islemKucuk = islem.ToLower();

        if (islemKucuk.Contains("kredi") || islemKucuk.Contains("hesap açma"))
        {
            oncelik = Oncelik.Yuksek;
        }
        else if (islemKucuk.Contains("transfer") || islemKucuk.Contains("para"))
        {
            oncelik = Oncelik.Orta;
        }
        else // Fatura, Bilgi güncelleme vb.
        {
            oncelik = Oncelik.Dusuk;
        }

        return new Musteri(ad, oncelik);
    }

    public static void Main(string[] args)
    {
        // Örnek Müşteriler
        Musteri m1 = MusteriOlustur("Ahmet", "Fatura Ödeme");       // Düşük (3)
        Musteri m2 = MusteriOlustur("Zeynep", "Kredi Başvurusu");   // Yüksek (1)
        Musteri m3 = MusteriOlustur("Can", "Para Çekme");           // Orta (2)
        Musteri m4 = MusteriOlustur("Deniz", "Hesap Açma");         // Yüksek (1)
        Musteri m5 = MusteriOlustur("Emre", "Para Yatırma");        // Orta (2)

        Console.Title = "Öncelikli Banka Kuyruğu Simülasyonu";


        // --- 1. Dizi Mantığı ile Çalıştırma ---
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n==============================================");
        Console.WriteLine("1. DİZİ/LISTE MANTIĞI İLE ÖNCELİKLİ KUYRUK");
        Console.WriteLine("==============================================\n");
        Console.ResetColor();

        var arrayKuyruk = new ArrayPriorityQueue();
        arrayKuyruk.Enqueue(m1);
        arrayKuyruk.Enqueue(m2);
        arrayKuyruk.Enqueue(m3);
        arrayKuyruk.Enqueue(m4);
        arrayKuyruk.Enqueue(m5);

        Console.WriteLine("\n-- Anlık Kuyruk Durumu --");
        arrayKuyruk.Goster();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n-- Kuyruktan Eleman Alma (Dequeue) --");
        Console.ResetColor();

        Console.WriteLine($"İşlem: {arrayKuyruk.Dequeue()} alındı."); // Önce Zeynep (Ö1)
        Console.WriteLine($"İşlem: {arrayKuyruk.Dequeue()} alındı."); // Sonra Deniz (Ö1)
        Console.WriteLine($"İşlem: {arrayKuyruk.Dequeue()} alındı."); // Sonra Can (Ö2)
        Console.WriteLine($"İşlem: {arrayKuyruk.Dequeue()} alındı."); // Sonra Emre (Ö2)
        Console.WriteLine($"İşlem: {arrayKuyruk.Dequeue()} alındı."); // Sonra Ahmet (Ö3)
        Console.WriteLine($"İşlem: {arrayKuyruk.Dequeue()} alındı."); // Kuyruk boş


        // --- 2. Bağlı Liste Mantığı ile Çalıştırma ---
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n==============================================");
        Console.WriteLine("2. BAĞLI LİSTE MANTIĞI İLE ÖNCELİKLİ KUYRUK");
        Console.WriteLine("==============================================\n");
        Console.ResetColor();

        var linkedKuyruk = new LinkedListPriorityQueue();
        linkedKuyruk.Enqueue(m1);
        linkedKuyruk.Enqueue(m2);
        linkedKuyruk.Enqueue(m3);
        linkedKuyruk.Enqueue(m4);
        linkedKuyruk.Enqueue(m5);

        Console.WriteLine("\n-- Anlık Kuyruk Durumu --");
        linkedKuyruk.Goster();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n-- Kuyruktan Eleman Alma (Dequeue) --");
        Console.ResetColor();

        // Ö1'ler (Zeynep, Deniz) -> Ö2'ler (Can, Emre) -> Ö3 (Ahmet) sırasıyla çıkacak.
        Console.WriteLine($"İşlem: {linkedKuyruk.Dequeue()} alındı.");
        Console.WriteLine($"İşlem: {linkedKuyruk.Dequeue()} alındı.");
        Console.WriteLine($"İşlem: {linkedKuyruk.Dequeue()} alındı.");
        Console.WriteLine($"İşlem: {linkedKuyruk.Dequeue()} alındı.");
        Console.WriteLine($"İşlem: {linkedKuyruk.Dequeue()} alındı.");
        Console.WriteLine($"İşlem: {linkedKuyruk.Dequeue()} alındı.");
    }
}