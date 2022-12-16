/*
Fikri Rivandi - 2207112583 - TIB
UTS S1 - No. 4
*/

using System;

namespace UTS_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input, output;
            string error = "";

            while(true)
            {
                Console.Clear(); //bersihkan tampilan

                if(error != "") //jika error tidak null
                {
                    Console.WriteLine(error); // tampilkan error
                    Console.WriteLine();
                }
                Console.Write("Teks : ");
                input = Console.ReadLine(); //input password
                input = input.Trim(); //menghilangkan spasi diawal dan akhir
                if(input == "" || input == " ")  //jika kode tidak valid
                {
                    error = "Error : Input yang anda masukkan tidak valid.\nInput yang valid (Aa-Zz)";
                    continue;
                }
                else //jika input valid
                {
                    output = Encrypt(input); //meng-encrypt input
                    if(output == "0") //jika error
                    {
                        error = "Error : Input yang anda masukkan tidak valid.\nInput yang valid (Aa-Zz)";
                        continue;
                    }
                    else //jika berhasil meng-encrypt
                    {
                        Console.WriteLine("Hasil Enkripsi : " + output);
                        break;
                    }
                }
            }
            Console.ReadKey(); //exit
        }

        static string Encrypt(string input)
        {
            string output = "";
            for(int i = 0; i < input.Length; i++)
            {
                char code = input[i]; //mengambil karakter pada i
                int codeChar; //menampung kode char yang akan diubah
                if(code == ' ') //jika spasi
                {
                    codeChar = (int)' '; //tetap spasi
                }
                else if((code < 'A' || code > 'z') || (code < 'a' && code > 'Z')) //jika tidak (Aa-Zz)
                {
                    return "0"; //maka error
                }
                else if(code >= 'X' && code <= 'Z') //jika karakter nya X,Y,Z
                {
                    codeChar = (int)'A' + 2 + ((int)code - (int)'Z'); //maka diubah jadi A,B,C
                }
                else if(code >= 'x' && code <= 'z') //jika karakter nya x,y,z
                {
                    codeChar = (int)'a' + 2 + ((int)code - (int)'z'); //maka diubah jadi a,b,c
                }
                else //jika a-w
                {
                    codeChar = 3 + (int)code; //diubah ke karakter yang ke 3 dari karakter sebelumnya
                }
                output = output + (char)codeChar; //mengisi output dengan karakter yang telah diubah
            }
            return output;
        }
    }
}