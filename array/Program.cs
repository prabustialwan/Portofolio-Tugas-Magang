using System;
using System.Linq;

class Program
{
    static void tampilanMenu()
    {
        Console.WriteLine("Pilih operasi yang diinginkan:");
        Console.WriteLine("1. Penjumlahan");
        Console.WriteLine("2. Pengurangan");
        Console.WriteLine("3. Perkalian");
        Console.WriteLine("4. Pembagian");
        Console.WriteLine("5. Keluar");
    }

    static double mintaAngka(string urutan)
    {
        double angka;
        Console.Write($"Masukkan angka {urutan}: ");
        while (!double.TryParse(Console.ReadLine(), out angka))
        {
            Console.Write("Input tidak valid. Masukkan angka yang benar: ");
        }
        return angka;
    }

    static double tambah(double a, double b) => a + b;
    static double kurang(double a, double b) => a - b;
    static double kali(double a, double b) => a * b;
    static double bagi(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Pembagian dengan nol tidak diperbolehkan");
            return 0;
        }
        return a / b;
    }

    static void Main()  
    {
        bool running = true;
        while (running)
        {
            tampilanMenu();
            Console.Write("Masukkan pilihan (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int pilihan))
            {
                if (pilihan == 5)
                {
                    running = false;
                    Console.WriteLine("Terima kasih telah menggunakan kalkulator.");
                    continue;
                }
                else if (pilihan >= 1 && pilihan <= 4) 
                {
                    double angka1 = mintaAngka("pertama");
                    double angka2 = mintaAngka("kedua");
                    double hasil = 0;

                    switch (pilihan)
                    {
                        case 1: hasil = tambah(angka1, angka2); break;
                        case 2: hasil = kurang(angka1, angka2); break;
                        case 3: hasil = kali(angka1, angka2); break;
                        case 4: hasil = bagi(angka1, angka2); break;
                    }

                    Console.WriteLine($"Hasil: {hasil}");
                }
                else
                {
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                }
            }
            else
            {
                Console.WriteLine("Input salah, masukkan angka yang benar.");
            }

            Console.WriteLine(); // baris kosong untuk pemisah
        }
    }
    /*static void Main()
    {
        (string Nama, int Umur, double IPK)[] semuaSiswa =
        {
            ("Andi", 20, 2.9),
            ("Budi", 22, 4),
            ("Citra", 19, 3.4),
            ("Dewi", 21, 2.0),
            ("Eka", 23, 3.8)
        };

        //mengurutkan nilai IPK tertinggi
        var urutkan = semuaSiswa.OrderByDescending(s => s.IPK);

        Console.WriteLine("======= Hasil Pengurutan IPK =======");
        foreach (var siswa in urutkan)
        {
            if (siswa.IPK >= 3.0)
            {
                Console.WriteLine($"Nama: {siswa.Nama}, Lulus dengan IPK: {siswa.IPK}");
            }
            else
            {
                Console.WriteLine($"Nama: {siswa.Nama}, Tidak lulus dengan IPK: {siswa.IPK}");
            }
        }

        Console.WriteLine("======= Pencarian siswa berdasarkan nama =======");
        Console.Write("Masukkan nama siswa yang dicari: ");
        string namaDicari = Console.ReadLine();

        // cari siswa berdasarkan nama
        var hasil = semuaSiswa.FirstOrDefault(s => s.Nama.Equals(namaDicari, StringComparison.OrdinalIgnoreCase));
        if (hasil != default)
        {
            Console.WriteLine($"Siswa ditemukan: Nama: {hasil.Nama}, Umur: {hasil.Umur}, IPK: {hasil.IPK}");
        }
        else
        {
            Console.WriteLine("Siswa tidak ditemukan.");
        }
    }*/
}