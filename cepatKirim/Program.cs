using System;

class Program
{
    // Data penjualan (array paralel)
    static string[] daftarProduk = { "Kopi Robusta 1kg", "Teh Hijau Celup", "Gula Aren 500g", "Susu UHT Full Cream", "Biskuit Cokelat" };
    static double[] hargaSatuan = { 120000, 25000, 35000, 18000, 9500 };
    static int[] jumlahTerjual = { 50, 75, 40, 120, 200 };

    // Array untuk pendapatan per produk
    static double[] pendapatanProduk = new double[5];

    static void Main()
    {
        // Tugas 1
        CetakTabelPenjualan();

        // Tugas 2
        double total = HitungPendapatan();
        Console.WriteLine($"\nTotal Pendapatan Hari Ini: Rp {total:N0}\n");

        // Tugas 3
        AnalisisProdukTerbaik();

        // Tugas 4
        UrutkanDenganSelectionSort();
        CetakLaporanLengkap();
    }

    // ===== Tugas 1 =====
    static void CetakTabelPenjualan()
    {
        Console.WriteLine("= LAPORAN PENJUALAN HARIAN - 17 Desember 2025 =");
        Console.WriteLine($"{"Produk",-25} {"Harga",10} {"Terjual",10}");
        Console.WriteLine(new string('-', 50));

        for (int i = 0; i < daftarProduk.Length; i++)
        {
            Console.WriteLine($"{daftarProduk[i],-25} Rp {hargaSatuan[i],8:N0} {jumlahTerjual[i],10}");
        }
        Console.WriteLine();
    }

    // ===== Tugas 2 =====
    static double HitungPendapatan()
    {
        double total = 0;
        Console.WriteLine("= KALKULASI PENDAPATAN =");

        for (int i = 0; i < daftarProduk.Length; i++)
        {
            pendapatanProduk[i] = hargaSatuan[i] * jumlahTerjual[i];
            total += pendapatanProduk[i];
            Console.WriteLine($"{daftarProduk[i],-25} Rp {pendapatanProduk[i],12:N0}");
        }

        return total;
    }

    // ===== Tugas 3 =====
    static void AnalisisProdukTerbaik()
    {
        int idxPendapatan = 0;
        int idxUnit = 0;

        for (int i = 1; i < daftarProduk.Length; i++)
        {
            if (pendapatanProduk[i] > pendapatanProduk[idxPendapatan])
                idxPendapatan = i;

            if (jumlahTerjual[i] > jumlahTerjual[idxUnit])
                idxUnit = i;
        }

        Console.WriteLine("= ANALISIS PERFORMA PRODUK =");
        Console.WriteLine($"Produk dengan pendapatan tertinggi : {daftarProduk[idxPendapatan]} (Rp {pendapatanProduk[idxPendapatan]:N0})");
        Console.WriteLine($"Produk dengan unit terjual terbanyak: {daftarProduk[idxUnit]} ({jumlahTerjual[idxUnit]} unit)\n");
    }

    // ===== Tugas 4 (Selection Sort) =====
    static void UrutkanDenganSelectionSort()
    {
        int n = pendapatanProduk.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int idxMaks = i;
            for (int j = i + 1; j < n; j++)
            {
                if (pendapatanProduk[j] > pendapatanProduk[idxMaks])
                {
                    idxMaks = j;
                }
            }
            Tukar(i, idxMaks);
        }
    }

    // Fungsi bantu untuk menukar data di semua array
    static void Tukar(int a, int b)
    {
        // pendapatan
        double tmpPendapatan = pendapatanProduk[a];
        pendapatanProduk[a] = pendapatanProduk[b];
        pendapatanProduk[b] = tmpPendapatan;

        // harga
        double tmpHarga = hargaSatuan[a];
        hargaSatuan[a] = hargaSatuan[b];
        hargaSatuan[b] = tmpHarga;

        // unit
        int tmpUnit = jumlahTerjual[a];
        jumlahTerjual[a] = jumlahTerjual[b];
        jumlahTerjual[b] = tmpUnit;

        // nama
        string tmpNama = daftarProduk[a];
        daftarProduk[a] = daftarProduk[b];
        daftarProduk[b] = tmpNama;
    }

    // Cetak laporan lengkap setelah diurutkan
    static void CetakLaporanLengkap()
    {
        Console.WriteLine("= MENGURUTKAN BERDASARKAN PENDAPATAN (TOP TO BOTTOM) =");
        Console.WriteLine($"{"Produk",-25} {"Harga",10} {"Terjual",10} {"Pendapatan",15}");
        Console.WriteLine(new string('-', 65));

        for (int i = 0; i < daftarProduk.Length; i++)
        {
            Console.WriteLine($"{daftarProduk[i],-25} Rp {hargaSatuan[i],8:N0} {jumlahTerjual[i],10} Rp {pendapatanProduk[i],12:N0}");
        }
    }
}
