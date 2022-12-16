/*
Fikri Rivandi - 2207112583 - TIB
UTS S1 - No. 2
*/

using System;

namespace UTS_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double USDtoRP = 15368.07; //nilai tukar usd ke rupiah
            double USD = 0.0; //input nilai usd
            string error = "";
            while(true)
            {
                Console.Clear();
                if(error != "")
                {
                    Console.WriteLine(error);
                    Console.WriteLine();
                }
                Console.WriteLine("Rate USD ke RP:\n" + USDtoRP);
                Console.WriteLine("Jumlah USD:");
                try
                {
                    USD = Convert.ToDouble(Console.ReadLine()); //input user
                    Console.WriteLine("Hasil Konversi: " + (USDtoRP * USD)); //konversikan usd ke rupiah
                    break; //end loop
                }
                catch(Exception)
                {
                    error = "Error : Input yang anda masukkan tidak valid.";
                    continue; //lanjutkan
                }
            }
            Console.ReadKey(); //exit
        }
    }
}