// See https://aka.ms/new-Console-template for more information
//Console.WriteLine("Hello, World!");

//--Program Perkenalan Diri--
Console.WriteLine("================================");
Console.WriteLine(" SELAMAT DATANG ");
Console.WriteLine(" Nama: Rina ");
Console.WriteLine(" Umur: 21 Tahun ");
Console.WriteLine(" Hobi: MembaCa ");
Console.WriteLine("================================");


// --Program Penjumlahan Dua Angka--
Console.WriteLine("================================");
Console.WriteLine(" Program Penjumlahan Dua Angka ");
Console.WriteLine("================================");
Console.Write(" Masukan angka pertama: ");
string input = Console.ReadLine();
int angka1 = int.Parse(input);

Console.Write(" Masukan angka kedua: ");
int angka2 = int.Parse(Console.ReadLine());

int a = 5, b = 3;
int hasil = a;
for (int i = 0; i < b; i++)
{
    hasil += 1;
}
Console.WriteLine($" Hasil: {hasil}");


// --Kalkulator Sederhana-- 
Console.WriteLine("===== Selamat Datang di Kalkulator Sederhana =====");
Console.Write("Angka 1: ");
int a = int.Parse(Console.ReadLine());
Console.Write("Operator (+ - * /): ");
string op = Console.ReadLine();
Console.Write("Angka 2: ");
int b = int.Parse(Console.ReadLine());

int hasil = 0;

if (op == "+")
{
    hasil = a + b;
}
else if (op == "-")
{
    hasil = a - b;
}
else if (op == "*")
{
    // perkalian
    for (int i = 0; i < b; i++)
    {
        hasil += a;
    }
}
else if (op == "/")
{
    // pembagian
    int temp = a;
    while (temp >= b)
    {
        hasil += 1;
        temp -= b;
    }
}
else
{
    Console.WriteLine("Operator tidak ditemukan");
}

Console.WriteLine($"Hasil: {hasil}");


// --Program Menentukan Bilangan Prima--
Console.Write(" Masukan angka: ");
int n = int.Parse(Console.ReadLine());
bool prima = true;

if (n < 2) {
    prima = false;
} else {
    for (int i = 2; i < n; i++) {
        if (n % i == 0) {
            prima = false;
            break;
        }
    }   
}

Console.WriteLine(prima ? "Prima" : "Bukan Prima");


// --Program Reverse String dan Palindrome--
Console.Write("Masukan teks : ");
string? teks = Console.ReadLine()!;

if (string.IsNullOrEmpty(teks))
{
    Console.WriteLine("Teks tidak boleh kosong");
    return;
}

string balik = "";

for (int i = teks.Length - 1; i >= 0; i--)
{
    balik += teks[i];
}

Console.WriteLine($"Dibalik: {balik}");
 
if (teks == balik)
{
    Console.WriteLine("Palindrome");
}
else
{
    Console.WriteLine("Bukan Palindrome");
}


// --Program Menghitung Faktorial--
Console.Write("Masukan angka: ");
int n = int.Parse(Console.ReadLine()!);

int faktorial = 1;
for (int i = 1; i <= n; i++)
{
    faktorial *= i;
}
Console.WriteLine($"Faktorial dari {n} adalah {faktorial}");


// --Program Prima
Console.Write("Masukan angka pertama: ");
int start = int.Parse(Console.ReadLine()!);

Console.Write("Masukan angka kedua: ");
int end = int.Parse(Console.ReadLine()!);

Console.WriteLine($"Bilangan prima dari {start} sampai {end} adalah: ");

for (int n = start; n <= end; n++)
{
    bool prima = true;

    if (n < 2)
    {
        prima = false;
    }
    else
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0)
            {
                prima = false;
                break;
            }
        }
    }

    if (prima)
    {
        Console.WriteLine(n);
    }
}
