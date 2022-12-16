/*
Author:
 Fikri Rivandi
 2207112583
 TI-B
 Tugas 3
 Dasar Pemrograman
*/

using System;
using System.Collections.Generic;

namespace TebakKata
{
    class Program
    {
        //deklarasi variabel
        static int kesempatan; //kesempatan menebak
        static string kataMisteri, kataTertebak; //kata yang digunakan di game
        static List<string> listTebakan = new List<string>{}; //list huruf yang diinput player

        //gerbang utama program
        static void Main(string[] args)
        {
            Init(); //inisialisasi variabel
            Intro(); //print intro
            PlayGame(); //play
            EndGame(); //gameover
        }

        static void Init()
        {
            //inisialisasi variabel awal
            kesempatan = 5;
            kataMisteri = "maguire";
        }

        static void Intro()
        {
            //Intro
            Console.WriteLine("\nSelamat Datang!\nHari ini kita akan bermain tebak kata.");
            Console.WriteLine($"Kamu punya {kesempatan} kesempatan untuk menebak kata misteri hari ini.");

            //hint
            Console.WriteLine("Petunjuknya adalah:\n- Kata ini merupakan nama pemain bola terbaik dunia.");
            Console.WriteLine($"- Kata tersebut terdiri dari {kataMisteri.Length} huruf.");
            Console.WriteLine("Kata apa yang dimaksud?\n");
        }

        //Luncurkan game
        static void PlayGame()
        {
            //loop, saat kesempatan masih ada, jalankan game
            while(kesempatan > 0)
            {
                //string untuk menampikan kata yang sudah tertebak
                kataTertebak = "";

                //input jawaban
                Console.Write("Apa huruf tebakanmu? (a-z): ");
                string input = Console.ReadLine();
                if(input == "") //jika dijawab 'enter', maka ulangi pertanyaan
                {
                    continue;
                }

                //masukkan input ke list
                listTebakan.Add(input);

                //cek kebenaran kata
                if(cekKata(kataMisteri,listTebakan)) //jika sudah benar semua
                {
                    Console.WriteLine("Selamat! Anda berhasil menebak kata misteri.");
                    Console.WriteLine($"Kata misteri hari ini adalah \"{kataMisteri}\".\n");
                    break; //hentikan loop
                }
                else if(kataMisteri.Contains(input)) //jika input benar, tapi belum lengkap
                {
                    Console.WriteLine($"Huruf \'{input}\' ada didalam kata misteri.");

                    //cek huruf yang benar
                    for(int i=0;i<kataMisteri.Length;i++)
                    {
                        string str = Convert.ToString(kataMisteri[i]);
                        if(listTebakan.Contains(str))
                        {
                            kataTertebak+=str;
                        }
                        else
                        {
                            kataTertebak+="_";
                        }
                    }

                    //tampilkan huruf-huruf yang benar
                    Console.WriteLine(kataTertebak);
                    Console.WriteLine("Silahkan tebak huruf yang lain...\n");
                }
                else //jika input huruf salah
                {
                    Console.WriteLine($"Huruf \'{input}\' tidak ada didalam kata misteri.");
                    kesempatan--; //kurangi kesempatan menjawab
                    if(kesempatan == 0) //jika kesempatan habis, game over
                    {
                        Console.WriteLine("\nKesempatan menjawab sudah habis.\nCoba lagi yaa!\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Kesempatan menjawab tinggal {kesempatan}.\n");
                    }
                }
            }
        }

        //cek jawaban apakah sudah benar semua
        static bool cekKata(string kata, List<string> list)
        {
            bool ret = false;
            for(int i=0;i<kata.Length;i++)
            {
                string str = Convert.ToString(kata[i]);
                if(list.Contains(str))
                {
                    ret = true;
                }
                else
                {
                    return ret = false; //jika ada yang salah 1 saja, maka langsung return salah
                }
            }
            return ret;
        }

        //game overrrrr
        static void EndGame()
        {
            Console.WriteLine("Permainan Berakhir!");
            Console.WriteLine("Terimakasih sudah bermain.");
            Console.ReadKey(); //press any key to exit
       }
   }
}