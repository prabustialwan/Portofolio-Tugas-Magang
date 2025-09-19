using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Selamat Datang di Kalkulator Sederhana ===");
        Console.Write("Masukkan angka pertama: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Masukkan operasi (+, -, *, /): ");
        string operation = Console.ReadLine()!;

        Console.Write("Masukkan angka kedua: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;
        bool validOperation = true;

        switch (operation)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Error: Pembagian dengan nol tidak diperbolehkan.");
                    validOperation = false;
                }
                break;
            default:
                Console.WriteLine("Error: Operasi tidak valid.");
                validOperation = false;
                break;
        }
        if (validOperation)
        {
            Console.WriteLine($"Hasil: {num1} {operation} {num2} = {result}");
        }
    }
}