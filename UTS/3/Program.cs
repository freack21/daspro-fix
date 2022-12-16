/*
Fikri Rivandi - 2207112583 - TIB
UTS S1 - No. 3
*/

using System;

namespace UTS_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string nama, error = "";
            int tahunLahir, umur;

            while(true)
            {
                Console.Clear();
                if(error != "")
                {
                    Console.WriteLine(error);
                    Console.WriteLine();
                }
                Console.WriteLine("Nama :");
                nama = Console.ReadLine(); //nama
                nama = nama.Trim(); //menghapus spasi diawal dan akhir
                Console.WriteLine("Tahun Kelahiran :");
                try
                {
                    tahunLahir = Convert.ToInt16(Console.ReadLine()); //tahun lahir
                    umur = 2022 - tahunLahir; //umur

                    CreateTiket(nama, umur); //membuat tiket
                    break; //endloop
                }
                catch(Exception)
                {
                    error = "Error : Input yang anda masukkan tidak valid.";
                    continue; //lanjutkan
                }
            }

            Console.ReadKey(); //exit
        }

        static void CreateTiket(string nama, int umur)
        {
            string harga = "25000.00";
            if(umur < 10 || umur > 60)
            {
                harga = "10000.00";
            }
            int maxNameLength = 14  <= nama.Length ? nama.Length + 1 : 14; //panjang maksimal nama
            int maxHargaLength = 14 <= harga.Length ? harga.Length + 1 : 14; //panjang maksimal nim
            int LongestLength = Math.Max(maxNameLength, maxHargaLength); //mengambil kata terpanjang antara harga dan nama

            string atribut = "Harga:  Rp";
            int maxLineLength = LongestLength + atribut.Length + 2; //maksimal panjang perbaris

            //membuat border atas
            for(int i = 0; i < maxLineLength; i++)
            {
                if(i == 0 || i == maxLineLength - 1)
                {
                    Console.Write("|");
                }
                else
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();

            //membuat nama studio
            atribut = "|   -- Studio 1 --";
            Console.Write(atribut);
            for(int i = 0; i < maxLineLength - atribut.Length - 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|");
            Console.WriteLine();

            //membuat atribut nama
            atribut = "|Nama:";
            Console.Write(atribut);
            for(int i = 0; i < maxLineLength - atribut.Length - nama.Length - 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write(nama + "|");
            Console.WriteLine();

            //membuat atribut harga
            atribut = "|Harga:  Rp";
            Console.Write(atribut);
            for(int i = 0; i < maxLineLength - atribut.Length - harga.Length - 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write(harga + "|");
            Console.WriteLine();

           //membuat border bawah
            for(int i = 0; i < maxLineLength; i++)
            {
                if(i == 0 || i == maxLineLength - 1)
                {
                    Console.Write("|");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine();
       }
    }
}