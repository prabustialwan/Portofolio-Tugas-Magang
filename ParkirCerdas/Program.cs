using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Kendaraan
{
    public string PlatNomor { get; set; }
    public DateTime WaktuMasuk { get; set; }

    public Kendaraan(string platNomor, DateTime waktuMasuk)
    {
        PlatNomor = platNomor;
        WaktuMasuk = waktuMasuk;
    }

    public abstract int HitungBiayaParkir(int durasiJam);
}

public class Mobil : Kendaraan
{
    public Mobil(string platNomor, DateTime waktuMasuk) : base(platNomor, waktuMasuk) { }

    public override int HitungBiayaParkir(int durasiJam)
    {
        if (durasiJam <= 1) return 5000;
        return 5000 + (durasiJam - 1) * 3000; // Tarif parkir mobil: 5000 untuk jam pertama, 3000 untuk jam berikutnya
    }
}

public class Motor : Kendaraan
{
    public Motor(string platNomor, DateTime waktuMasuk) : base(platNomor, waktuMasuk) { }
    public override int HitungBiayaParkir(int durasiJam)
    {
        if (durasiJam <= 1) return 2000;
        return 2000 + (durasiJam - 1) * 1000; // Tarif parkir motor: 2000 untuk jam pertama, 1000 untuk jam berikutnya
    }
}

// Menghitung kapasitas parkir
public class Parkir
{
    private List<Kendaraan> daftarKendaraan = new List<Kendaraan>();
    private const int KapasitasMotorMobil = 100;// Kapasitas parkir maksimum

    public void Masuk(Kendaraan k)
    {
        if (daftarKendaraan.Count >= KapasitasMotorMobil)
        {
            Console.WriteLine("Parkir penuh. Tidak bisa menambah kendaraan.");
            return;
        }

        if (daftarKendaraan.Any(x => x.PlatNomor == k.PlatNomor))
        {
            Console.WriteLine("Kendaraan dengan plat nomor yang sama sudah ada di parkir.");
            return;
        }

        daftarKendaraan.Add(k);
        Console.WriteLine($"Kendaraan dengan plat nomor {k.PlatNomor} ({k.GetType().Name}) berhasil masuk pada {k.WaktuMasuk:HH:mm}.");
    }

    public void TampilkanDaftarKendaraan()
    {
        if (daftarKendaraan.Count == 0)
        {
            Console.WriteLine("Tidak ada kendaraan yang sedang parkir.");
            return;
        }

        Console.WriteLine("\n======= Daftar Kendaraan di Parkir: =======");
        foreach (var k in daftarKendaraan)
        {
            Console.WriteLine($"Plat Nomor: {k.PlatNomor} | Jenis Kendaraan: {k.GetType().Name} | Masuk pada: {k.WaktuMasuk:HH:mm}");
        }
    }

    public void Keluar(string platNomor, DateTime waktuKeluar)
    {
        var kendaraan = daftarKendaraan.FirstOrDefault(k => k.PlatNomor.Equals(platNomor, StringComparison.OrdinalIgnoreCase));
        if (kendaraan == null)
        {
            Console.WriteLine("Kendaraan dengan plat nomor tersebut tidak ditemukan.");
            return;
        }

        TimeSpan durasi = waktuKeluar - kendaraan.WaktuMasuk;
        if (durasi.TotalMinutes < 0)
        {
            Console.WriteLine("Waktu keluar tidak boleh sebelum waktu masuk.");
            return;
        }

        int durasiJam = (int)Math.Ceiling(durasi.TotalHours); //Dibulatkan ke atas
        int biaya = kendaraan.HitungBiayaParkir(durasiJam);

        // cetak struk biaya parkir
        Console.WriteLine("\n======= Struk Biaya Parkir =======");
        Console.WriteLine($"Plat Nomor: {kendaraan.PlatNomor}");
        Console.WriteLine($"Jenis Kendaraan: {kendaraan.GetType().Name}");
        Console.WriteLine($"Waktu Masuk: {kendaraan.WaktuMasuk:HH:mm}");
        Console.WriteLine($"Waktu Keluar: {waktuKeluar:HH:mm}");
        Console.WriteLine($"Durasi Parkir: {durasiJam} jam");
        Console.WriteLine($"Biaya Parkir: Rp{biaya:N0}");
        Console.WriteLine("==================================");

        daftarKendaraan.Remove(kendaraan);
        Console.WriteLine($"Kendaraan dengan plat nomor {platNomor} telah keluar dari parkir.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Parkir parkir = new Parkir();
        bool jalan = true;
        
        while (jalan)
        {
            Console.WriteLine("\n======= Sistem Parkir Cerdas =======");
            Console.WriteLine("1. Masuk Kendaraan");
            Console.WriteLine("2. Daftar Kendaraan Parkir");
            Console.WriteLine("3. Kendaraan Keluar");
            Console.WriteLine("4. Keluar Aplikasi");
            Console.Write("Pilih Menu: ");
            string pilihan = Console.ReadLine()!;

            switch (pilihan)
            {
                case "1": //Masuk kendaraan
                    Console.Write("Masukan Plat Nomor: ");
                    string platNomor = Console.ReadLine()!.Trim();

                    Console.Write("Jenis Kendaraan (1. Mobil, 2. Motor): ");
                    string jenis = Console.ReadLine()!.Trim();

                    Console.Write("Waktu Masuk (HH:mm): ");
                    DateTime waktuMasuk;
                    if (!DateTime.TryParse(Console.ReadLine()!, out waktuMasuk))
                    {
                        Console.WriteLine("Format waktu tidak valid. Gunakan format HH:mm.");
                        break;
                    }

                    Kendaraan k;
                    if (jenis == "1")
                        k = new Mobil(platNomor, waktuMasuk);
                    else if (jenis == "2")
                        k = new Motor(platNomor, waktuMasuk);
                    else
                    {
                        Console.WriteLine("Jenis kendaraan tidak valid.");
                        break;
                    }

                    parkir.Masuk(k);
                    break;

                case "2": //menampilkan daftar kendaraan
                    parkir.TampilkanDaftarKendaraan();
                    break;

                case "3": //Kendaraan keluar
                    Console.Write("Masukan Plat Nomor: ");
                    string platKeluar = Console.ReadLine()!;

                    Console.Write("Waktu Keluar (HH:mm): ");
                    DateTime waktuKeluar;
                    if (!DateTime.TryParse(Console.ReadLine()!, out waktuKeluar))
                    {
                        Console.WriteLine("Format waktu tidak valid");
                        break;
                    }

                    parkir.Keluar(platKeluar, waktuKeluar);
                    break;

                case "4": //Keluar aplikasi
                    jalan = false;
                    Console.WriteLine("Terima kasih telah menggunakan sistem parkir cerdas.");
                    break;

                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }
}
