/*
Fikri Rivandi - 2207112583 - TIB
UTS S1 - No. 1
*/

using System;

namespace UTS_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nama,nim,konsentrasi;

            Console.Clear();
            Console.WriteLine("Nama :");
            nama = Console.ReadLine(); //nama
            nama = nama.Trim(); //menghilangkan spasi diawal dan akhir
            Console.WriteLine("Nim :");
            nim = Console.ReadLine(); //nim
            nim = nim.Trim(); //menghilangkan spasi diawal dan akhir
            Console.WriteLine("Konsentrasi :");
            konsentrasi = Console.ReadLine(); //konsentrasi
            konsentrasi = konsentrasi.Trim(); //menghilangkan spasi diawal dan akhir

            CreateNameTag(nama, nim, konsentrasi); //membuat nametag

            Console.ReadKey(); //exit
        }

        static void CreateNameTag(string nama, string nim, string konsentrasi)
        {
            int maxNameLength = 15  <= nama.Length ? nama.Length + 1 : 15; //panjang maksimal nama
            int maxNIMLength = 15 <= nim.Length ? nim.Length + 1 : 15; //panjang maksimal nim
            int maxKonsentrasiLength = 15 <= konsentrasi.Length ? konsentrasi.Length + 1 : 15; //panjang maksimal konsentrasi
            int LongestLength = Math.Max(maxNameLength, maxNIMLength); //kata terpanjang antara nim dan nama
            LongestLength = Math.Max(LongestLength, maxKonsentrasiLength); //mengambil maksimal panjang antara nama, nim, dan konsentrasi

            string atribut = "Nama:";
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

            //membuat atribut nama
            atribut = "|" + atribut;
            Console.Write(atribut);
            for(int i = 0; i < maxLineLength - atribut.Length - nama.Length - 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write(nama + "|");
            Console.WriteLine();

            //membuat atribut nim
            atribut = "|";
            Console.Write(atribut);
            for(int i = 0; i < maxLineLength - atribut.Length - nim.Length - 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write(nim + "|");
            Console.WriteLine();

            //membuat sekat antara nim dan konsentrasi
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
 
            //membuat atribut konsentrasi
            atribut = "|";
            Console.Write(atribut);
            for(int i = 0; i < maxLineLength - atribut.Length - konsentrasi.Length - 1; i++)
            {
                Console.Write(" ");
            }
            Console.Write(konsentrasi + "|");
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
                    Console.Write("*");
                }
            }
            Console.WriteLine();
        }
    }
}