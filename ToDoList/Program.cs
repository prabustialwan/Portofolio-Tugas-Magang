using System;
using System.Collections.Generic;

class Program
{
    static void tampilanMenu()
    {
        Console.WriteLine("=== Aplikasi To-Do List ===");
        Console.WriteLine("1. Tambah Tugas");
        Console.WriteLine("2. Lihat Tugas");
        Console.WriteLine("3. Edit Tugas");
        Console.WriteLine("4. Hapus Tugas");
        Console.WriteLine("5. Keluar");
    }

    static void tambahTugas(List<string> tasks)
    {
        Console.Write("Masukan Deskripsi Tugas: ");
        string? deskripsi = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(deskripsi))
        {
            tasks.Add(deskripsi);
            Console.WriteLine("Tugas Berhasil Ditambahkan!");
        }
        else
        {
            Console.WriteLine("Deskripsi tidak boleh kosong.");
        }
    }

    static void lihatTugas(List<string> tasks)
    {
        Console.WriteLine("=== Daftar Tugas ===");
        if (tasks.Count == 0)
        {
            Console.WriteLine("Belum ada tugas.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void editTugas(List<string> tasks)
    {
        lihatTugas(tasks);
        if (tasks.Count == 0) return;

        Console.Write("Pilih nomor tugas yang akan diubah: ");
        if (int.TryParse(Console.ReadLine(), out int nomor))
        {
            if (nomor > 0 && nomor <= tasks.Count)
            {
                Console.Write("Masukan Deskripsi Tugas Baru: ");
                string? deskripsiBaru = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(deskripsiBaru))
                {
                    tasks[nomor - 1] = deskripsiBaru;
                    Console.WriteLine($"Tugas Berhasil Diubah!");
                }
                else
                {
                    Console.WriteLine("Deskripsi tidak boleh kosong.");
                }
            }
            else
            {
                Console.WriteLine("Nomor tugas tidak valid.");
            }
        }
        else
        {
            Console.WriteLine("Input tidak valid.");
        }
    }

    static void hapusTugas(List<string> tasks)
    {
        lihatTugas(tasks);
        if (tasks.Count == 0) return;

        Console.Write("Pilih nomor tugas yang ingin dihapus: ");
        if (int.TryParse(Console.ReadLine(), out int nomor))
        {
            if (nomor > 0 && nomor <= tasks.Count)
            {
                Console.WriteLine($"Tugas '{tasks[nomor - 1]}' Berhasil Dihapus!");
                tasks.RemoveAt(nomor - 1);
            }
            else
            {
                Console.WriteLine("Nomor tugas tidak valid.");
            }
        }
        else
        {
            Console.WriteLine("Input tidak valid.");
        }
    }

    static void Main()
    {
        List<string> tasks = new List<string>();
        bool running = true;

        while (running)
        {
            tampilanMenu();
            Console.Write("Masukan Pilihan Anda: ");

            if (int.TryParse(Console.ReadLine(), out int pilihan))
            {
                switch (pilihan)
                {
                    case 1: tambahTugas(tasks); break;
                    case 2: lihatTugas(tasks); break;
                    case 3: editTugas(tasks); break;
                    case 4: hapusTugas(tasks); break;
                    case 5:
                        running = false;
                        Console.WriteLine("Keluar dari aplikasi. Terima kasih!");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input salah, harap masukan angka.");
            }
            Console.WriteLine();
        }
    }
}