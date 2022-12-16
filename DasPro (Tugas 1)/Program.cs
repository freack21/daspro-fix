/*
Created by Fikri Rivandi - 2207112583
*/

using System;

namespace DasPro
{
    class Program
    {
        //Main Method
        static void Main(string[] args)
        {
            //Deklarasi variabel
            const int a = 1;
            const int b = 2;
            const int c = 3;

            //Operasi variabel
            int tambah = a + b + c;
            int kali = a * b * c;
            int kurang = a - b - c;
            int bagi = a / b / c;

            Console.WriteLine("Anda adalah agen rahasia yang bertugas mendapatkan data dari server");
            Console.WriteLine("Akses ke server membutuhkan password yang tidak diketahui...");
            Console.WriteLine("- Password terdiri dari 4 angka");
            Console.WriteLine("- Jika ditambahkan hasilnya " + tambah);
            Console.WriteLine("- Jika dikalikan hasilnya " + kali);
            Console.WriteLine("- Jika dikurangkan hasilnya " + kurang);
            Console.WriteLine("- Jika dibagikan hasilnya " + bagi);
            Console.Write("\n\nEnter Code : ");

            //Press any key to exit
            Console.ReadKey();
        }
    }
}
