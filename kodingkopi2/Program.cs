using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#region === Model Produk & Transaksi ===

// Ukuran minuman
public enum Ukuran { Small, Medium, Large }

// Kelas abstrak untuk semua produk
public abstract class Produk
{
    private double _hargaDasar;

    public string SKU { get; private set; }
    public string Nama { get; set; }
    public double HargaDasar
    {
        get => _hargaDasar;
        set
        {
            if (value < 0) throw new ArgumentException("Harga tidak boleh negatif.");
            _hargaDasar = value;
        }
    }

    protected Produk(string sku, string nama, double hargaDasar)
    {
        SKU = sku;
        Nama = nama;
        HargaDasar = hargaDasar;
    }

    // Setiap produk menghitung harga akhirnya sendiri
    public abstract double HitungHarga();
}

// Produk khusus Minuman
public class Minuman : Produk
{
    public Ukuran UkuranPilihan { get; set; }

    public Minuman(string sku, string nama, double hargaDasar, Ukuran ukuran)
        : base(sku, nama, hargaDasar)
    {
        UkuranPilihan = ukuran;
    }

    public override double HitungHarga()
    {
        double harga = HargaDasar;
        if (UkuranPilihan == Ukuran.Medium) harga += 3000;
        if (UkuranPilihan == Ukuran.Large) harga += 5000;
        return harga;
    }
}

// Produk khusus Makanan
public class Makanan : Produk
{
    public bool ApakahDipanaskan { get; set; }

    public Makanan(string sku, string nama, double hargaDasar, bool dipanaskan)
        : base(sku, nama, hargaDasar)
    {
        ApakahDipanaskan = dipanaskan;
    }

    public override double HitungHarga()
    {
        return ApakahDipanaskan ? HargaDasar + 2000 : HargaDasar;
    }
}

// Kelas Transaksi
public class Transaksi
{
    private List<Produk> _daftarItem;

    public string NomorTransaksi { get; private set; }
    public string NamaPemesan { get; set; }
    public string NoTelp { get; set; }

    public Transaksi(string nomorTransaksi, string namaPemesan, string noTelp)
    {
        NomorTransaksi = nomorTransaksi;
        NamaPemesan = namaPemesan;
        NoTelp = noTelp;
        _daftarItem = new List<Produk>();
    }

    public void TambahItem(Produk produk)
    {
        _daftarItem.Add(produk);
        Console.WriteLine($"-> Menambahkan: {produk.Nama}");
    }

    public double HitungTotal() => _daftarItem.Sum(i => i.HitungHarga());

    // Menampilkan struk pembayaran
    public void TampilkanStruk()
    {
        Console.WriteLine("\n===== STRUK PEMBAYARAN - KODING KOPI =====");
        Console.WriteLine($"No. Transaksi: {NomorTransaksi}");
        Console.WriteLine($"Pemesan: {NamaPemesan} ({NoTelp})");
        Console.WriteLine("-------------------------------------------");

        foreach (var item in _daftarItem)
        {
            string detail = item switch
            {
                Minuman m => $"({m.UkuranPilihan})",
                Makanan mk when mk.ApakahDipanaskan => "(Dipanaskan)",
                Makanan => "(Normal)",
                _ => ""
            };

            Console.WriteLine($"{item.Nama,-22} {detail,-12} {item.HitungHarga(),10:C0}");
        }

        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"TOTAL PEMBAYARAN: {HitungTotal(),27:C0}");
        Console.WriteLine("===== Terima Kasih! =====\n");
    }
}

#endregion

#region === Aplikasi Utama ===

public class Program
{
    // Daftar menu awal
    static List<Produk> daftarMenu = new List<Produk>
    {
        new Minuman("COF-001", "Kopi Latte", 22000, Ukuran.Small),
        new Makanan("PST-002", "Croissant Cokelat", 18000, false),
        new Minuman("TEA-003", "Es Teh Manis", 12000, Ukuran.Small)
    };

    // Menyimpan semua transaksi
    static List<Transaksi> riwayatTransaksi = new List<Transaksi>();
    static Random rng = new Random();

    public static void Main(string[] args)
    {
        // Format uang jadi Rp
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("id-ID");

        Console.WriteLine("Selamat Datang di Koding Kopi POS!");

        bool jalan = true;
        while (jalan)
        {
            // Menu utama
            Console.WriteLine("\n--- MENU UTAMA ---");
            Console.WriteLine("[N] Transaksi Baru");
            Console.WriteLine("[L] Lihat Riwayat Transaksi");
            Console.WriteLine("[X] Keluar");
            Console.Write("Pilihan Anda: ");
            string pilihan = (Console.ReadLine() ?? "").Trim().ToUpper();

            switch (pilihan)
            {
                case "N": BuatTransaksiBaru(); break;
                case "L": LihatRiwayat(); break;
                case "X": Console.WriteLine("Menutup aplikasi..."); jalan = false; break;
                default: Console.WriteLine("Pilihan tidak valid."); break;
            }
        }
    }

    // Membuat transaksi baru
    static void BuatTransaksiBaru()
    {
        Console.WriteLine("\n--- TRANSAKSI BARU ---");
        Console.Write("Masukkan Nama Pemesan: ");
        string nama = Console.ReadLine() ?? "Anonim";
        Console.Write("Masukkan No. Telp Pemesan: ");
        string telp = Console.ReadLine() ?? "-";

        string kodeTransaksi = $"TRX-{DateTime.Now:yyyyMMdd}-{rng.Next(1000, 9999)}";
        Transaksi transaksi = new Transaksi(kodeTransaksi, nama, telp);

        Console.WriteLine($"\nMemulai Transaksi Baru: {kodeTransaksi} untuk {nama}");

        bool selesai = false;
        while (!selesai)
        {
            // Tampilkan menu produk
            Console.WriteLine("\n--- MENU PRODUK ---");
            for (int i = 0; i < daftarMenu.Count; i++)
                Console.WriteLine($"[{i + 1}] {daftarMenu[i].Nama} (Rp {daftarMenu[i].HargaDasar:N0})");
            Console.WriteLine("[0] SELESAI & CETAK STRUK");

            Console.Write("Pilih item untuk ditambahkan: ");
            if (!int.TryParse(Console.ReadLine(), out int pilihItem))
            {
                Console.WriteLine("Input salah. Masukkan angka.");
                continue;
            }

            if (pilihItem == 0)
            {
                // Selesai & cetak struk
                transaksi.TampilkanStruk();
                riwayatTransaksi.Add(transaksi);
                selesai = true;
            }
            else if (pilihItem > 0 && pilihItem <= daftarMenu.Count)
            {
                var template = daftarMenu[pilihItem - 1];

                if (template is Minuman)
                {
                    Ukuran ukuran = PilihUkuran();
                    transaksi.TambahItem(new Minuman(template.SKU, template.Nama, template.HargaDasar, ukuran));
                }
                else if (template is Makanan)
                {
                    bool dipanaskan = TanyaPanaskan();
                    transaksi.TambahItem(new Makanan(template.SKU, template.Nama, template.HargaDasar, dipanaskan));
                }
            }
            else
            {
                Console.WriteLine("Nomor produk tidak valid.");
            }
        }
    }

    // Memilih ukuran minuman
    static Ukuran PilihUkuran()
    {
        while (true)
        {
            Console.Write("Pilih ukuran (S/M/L): ");
            string u = (Console.ReadLine() ?? "").Trim().ToUpper();
            if (u == "S") return Ukuran.Small;
            if (u == "M") return Ukuran.Medium;
            if (u == "L") return Ukuran.Large;
            Console.WriteLine("Input tidak valid, coba lagi.");
        }
    }

    // Menanyakan apakah makanan dipanaskan
    static bool TanyaPanaskan()
    {
        while (true)
        {
            Console.Write("Panaskan item ini? (Y/T): ");
            string t = (Console.ReadLine() ?? "").Trim().ToUpper();
            if (t == "Y") return true;
            if (t == "T" || t == "N") return false;
            Console.WriteLine("Input tidak valid, coba lagi.");
        }
    }

    // Melihat riwayat transaksi
    static void LihatRiwayat()
    {
        if (riwayatTransaksi.Count == 0)
        {
            Console.WriteLine("Belum ada transaksi.");
            return;
        }

        Console.WriteLine("\n--- RIWAYAT TRANSAKSI ---");
        foreach (var trx in riwayatTransaksi)
        {
            Console.WriteLine($"{trx.NomorTransaksi} - {trx.NamaPemesan} ({trx.NoTelp}) - Total: {trx.HitungTotal():C0}");
        }
    }
}

#endregion
