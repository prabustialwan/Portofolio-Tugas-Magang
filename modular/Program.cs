using System;
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
}