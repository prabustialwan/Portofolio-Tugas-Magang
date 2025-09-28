using System;
using System.Collections.Generic;
using System.Linq;

// PRODUK (ABSTRACT CLASS)
public abstract class Produk
{
    private double _hargaDasar;
    public string SKU { get; private set; }
    public string Nama { get; set; }
    public double HargaDasar
    {
        get { return _hargaDasar; }
        set
        {
            if (value >= 0) _hargaDasar = value;
        }
    }

    public Produk(string sku, string nama, double hargaDasar)
    {
        SKU = sku;
        Nama = nama;
        HargaDasar = hargaDasar;
    }

    public abstract double HitungHargaJual();
}

// SPESIALISASI PRODUK: MAKANAN DAN MINUMAN (INHERITANCE)
public enum Ukuran
{
    Small,
    Medium,
    Large
}
public class Minuman : Produk
{
    public Ukuran UkuranMinuman { get; set; }

    public Minuman(string sku, string nama, double hargaDasar, Ukuran ukuran)
        : base(sku, nama, hargaDasar)
    {
        UkuranMinuman = ukuran;
    }

    public override double HitungHargaJual()
    {
        double hargaAkhir = HargaDasar;
        switch (UkuranMinuman)
        {
            case Ukuran.Medium:
                hargaAkhir += 3000;
                break;
            case Ukuran.Large:
                hargaAkhir += 6000;
                break;
        }
        return hargaAkhir;
    }
}

public class Makanan : Produk
{
    public bool DiPanaskan { get; set; }

    public Makanan(string sku, string nama, double hargaDasar, bool diPanaskan)
        : base(sku, nama, hargaDasar)
    {
        DiPanaskan = diPanaskan;
    }

    public override double HitungHargaJual()
    {
        double hargaAkhir = HargaDasar;
        if (DiPanaskan)
        {
            hargaAkhir += 2000;
        }
        return hargaAkhir;
    }
}

// MENGELOLA PESANAN - TRANSAKSI (COMPOSITION DAN POLYMORPHISM)
public class Transaksi
{
    public string NomorTransaksi { get; private set; }
    public string NamaPesanan { get; set; }
    public string NomorTelepon { get; set; }
    private List<Produk> daftarProduk;

    public Transaksi(string nomorTransaksi, string namaPesanan, string nomorTelepon)
    {
        NomorTransaksi = nomorTransaksi;
        NamaPesanan = namaPesanan;
        NomorTelepon = nomorTelepon;
        daftarProduk = new List<Produk>();
    }

    public void TambahProduk(Produk produk)
    {
        daftarProduk.Add(produk);
        Console.WriteLine($" -> Menambahkan: {produk.Nama}");
    }

    public double HitungTotalHarga()
    {
        return daftarProduk.Sum(p => p.HitungHargaJual());
    }

    public void TampilkanStruck()
    {
        Console.WriteLine("\n========= STRUK PEMBAYARAN - KODING KOPI =========");
        Console.WriteLine($"No. Transaksi : {NomorTransaksi}");
        Console.WriteLine($"Nama Pesanan  : {NamaPesanan}");
        Console.WriteLine($"No. Telepon   : {NomorTelepon}");
        Console.WriteLine("---------------------------------------------------");
        foreach (var produk in daftarProduk)
        {
            //menambahkan detail item (ukuran/dipanaskan) untuk kejelasan
            string detail = "";
            if (produk is Minuman minuman)
            {
                detail = $" ({minuman.UkuranMinuman})";
            }
            else if (produk is Makanan makanan)
            {
                detail = "(Dipanaskan)";
            }

            Console.WriteLine($"{produk.Nama}{detail} - Rp {produk.HitungHargaJual():N0}");
        }

        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Total Bayar   : Rp {HitungTotalHarga():N0}");
        Console.WriteLine("=========== TERIMA KASIH - KODING KOPI ===========\n");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Sistem POS Koding Kopi Sedang Berjalan...");

        Console.WriteLine("\nMembuat transaksi baru untuk pelanggan #1...");

        //format kode transaksi: TRX-YYYYMMDD-RandomCode
        string kodeUnik = new Random().Next(1000, 9999).ToString();
        string kodeTransaksi = $"TRX-{DateTime.Now:yyyyMMdd}-{kodeUnik}";

        Transaksi transaksi1 = new Transaksi(kodeTransaksi, "Andi", "081234567890");
        Minuman kopi = new Minuman("DRK-001", "Kopi Susu", 10000, Ukuran.Large);
        Makanan roti = new Makanan("FD-001", "Roti Bakar", 25000, true);
        Makanan nasiGoreng = new Makanan("FD-002", "Nasi Goreng", 30000, false);

        transaksi1.TambahProduk(kopi);
        transaksi1.TambahProduk(roti);
        transaksi1.TambahProduk(nasiGoreng);

        transaksi1.TampilkanStruck();   
    }
}






