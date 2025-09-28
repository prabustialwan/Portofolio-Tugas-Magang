using System;
using System.Collections.Generic;

// CLASS PRODUK DENGAN ENCAPSULATION
public class Produk
{
    private double harga;

    public string SKU { get; private set; }
    public string namaProduk { get; set; }
    public double Harga
    {
        get { return harga; }
        set
        {
            if (value >= 0)
            {
                harga = value;
            }
            else
            {
                Console.WriteLine($"Error: Harga untuk {namaProduk} tidak boleh negatif.");
            }

        }
    }

    public Produk(string sku, string nama, double harga)
    {
        SKU = sku;
        namaProduk = nama;
        Harga = harga;
    }

    public virtual void tampilkanDetail()
    {
        Console.WriteLine($"[{SKU}] {namaProduk} - Harga: {Harga:C}");
    }

    // CLASS TURUNAN LAPTOP
    public class Laptop : Produk
    {
        public int ukuranRAM { get; set; } // dalam GB
        public string tipePenyimpanan { get; set; } // SSD atau HDD

        public Laptop(string sku, string nama, double harga, int ram, string penyimpanan)
            : base(sku, nama, harga)
        {
            ukuranRAM = ram;
            tipePenyimpanan = penyimpanan;
        }

        public override void tampilkanDetail()
        {
            Console.WriteLine($"[LAPTOP]{SKU} - {namaProduk}");
            Console.WriteLine($" ->Harga: {Harga:C}, RAM: {ukuranRAM}GB, Penyimpanan: {tipePenyimpanan}");
        }
    }

    // CLASS TURUNAN SMARTPHONE
    public class Smartphone : Produk
    {
        public int ukuranLayar { get; set; } // dalam inci
        public int kapasitasBaterai { get; set; } // dalam mAh

        public Smartphone(string sku, string nama, double harga, int layar, int baterai)
            : base(sku, nama, harga)
        {
            ukuranLayar = layar;
            kapasitasBaterai = baterai;
        }

        public override void tampilkanDetail()
        {
            Console.WriteLine($"[SMARTPHONE]{SKU} - {namaProduk}");
            Console.WriteLine($" ->Harga: {Harga:C}, Layar: {ukuranLayar}\" , Baterai: {kapasitasBaterai}mAh");
        }
    }

    // CLASS TURUNAN TELEVISI
    public class Televisi : Produk
    {
        public int ukuranPanel { get; set; } // dalam inci
        public int Resolusi { get; set; } // dalam piksel

        public Televisi(string sku, string nama, double harga, int panel, int resolusi)
            : base(sku, nama, harga)
        {
            ukuranPanel = panel;
            Resolusi = resolusi;
        }
        
        public override void tampilkanDetail()
        {
            Console.WriteLine($"[TELEVISI]{SKU} - {namaProduk}");
            Console.WriteLine($" ->Harga: {Harga:C}, Panel: {ukuranPanel}\" , Resolusi: {Resolusi}p");
        }

    }

    // PROGRAM UTAMA
    public class Program
    {
        // FUNGSI UNTUK MENAMPILKAN SEMUA INVENTARIS MENGGUNAKAN POLIMORFISME
        public static void tampilkanSemuaInventaris(List<Produk> inventaris)
        {
            Console.WriteLine("=== INVENTARIS PRODUK ===");
            foreach (var item in inventaris)
            {
                item.tampilkanDetail();
            }
            Console.WriteLine("===========================");
        }

        public static void Main(string[] args)
        {
            // MEMBUAT LIST 'PRODUK' UNTUK MENAMPUNG SEMUA JENIS PRODUK
            List<Produk> inventarisToko = new List<Produk>();

            // MENAMBAHKAN OBJEK LAPTOP DAN SMARTPHONE KE DALAM SEMUA LIST
            inventarisToko.Add(new Laptop("ACER NITRO", "Laptop Gaming XYZ", 15000000, 16, "SSD"));
            inventarisToko.Add(new Smartphone("GOOGLE PIXEL", "Smartphone ABC", 5000000, 6, 4000));
            inventarisToko.Add(new Laptop("DELL XPS", "Laptop Ultrabook DEF", 20000000, 32, "SSD"));
            inventarisToko.Add(new Televisi ("SAMSUNG QLED", "Televisi 4K GHI", 12000000, 55, 2160));
            inventarisToko.Add(new Smartphone("IPHONE 13", "Smartphone JKL", 10000000, 6, 3500));
            inventarisToko.Add(new Televisi("LG OLED", "Televisi 8K MNO", 25000000, 65, 4320));

            // MENAMPILKAN SEMUA INVENTARIS
            tampilkanSemuaInventaris(inventarisToko);
        }

    }

}