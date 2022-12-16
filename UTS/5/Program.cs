/*
Fikri Rivandi - 2207112583 - TIB
UTS S1 - No. 5
*/

using System;
using System.Collections.Generic;

namespace UTS_5
{
    class Program
    {
        static string[] hangMan;
        static string[] kataMisteris;
        static string kataMisteri;
        static List<string> listTebakan;
        static string kataTertebak;
        static string falseMsg, endMsg;
        static int countFalse;
        static int maxFalse;
        static bool gameOver;
        static Random rkg = new Random();

        static void Main(string[] args)
        {
            Init(); // inisialisasi variabel
            StartProgram(); //mulai program
            Console.ReadKey(); //exit
        }

        static void Init()
        {
            hangMan = new string[] { //the hangman
                "_|___",
                " |\n |\n |\n |\n_|___",
                " |/\n |\n |\n |\n |\n_|___",
                "__________\n |/\n |\n |\n |\n |\n_|___",
                "__________\n |/      |\n |\n |\n |\n |\n_|___",
                "__________\n |/      |\n |      (_)\n |\n |\n |\n_|___",
                "__________\n |/      |\n |      (_)\n |      \\|/\n |\n |\n_|___",
                "__________\n |/      |\n |      (_)\n |      \\|/\n |       |\n |\n_|___",
                "__________\n |/      |\n |      (_)\n |      \\|/\n |       |\n |      / \\\n_|___",
            };
            kataMisteris = new string[]
            {
                "universitas",
                "riau",
                "teknik",
                "informatika",
                "kelas",
                "komputer",
                "laptop",
                "android",
                "windows",
                "macintosh"
            }; // kata tebakan
            kataMisteri = kataMisteris[rkg.Next(0,10)]; // kata tebakan diambil random dari array
            listTebakan = new List<string>{}; //list huruf yang diinput player
            kataTertebak = ""; //untuk tempat kata tebakan
            falseMsg = ""; //pesan salah
            countFalse = 0; //penghitung salah
            maxFalse = 10; //maksimal salah
            gameOver = false;
            endMsg = "";
        }

        static void StartProgram()
        {
            while(countFalse <= maxFalse) // selama kesalahan belum max dan belum game over
            {
                Console.Clear(); //bersihkan layar

                if(falseMsg != "") //jika ada pesan kesalahan
                {
                    Console.WriteLine(falseMsg); //tampilkan pesan salahnya
                }

                if(kataTertebak != "") //jika sudah ada kata yang tertebak
                {
                    Console.WriteLine(kataTertebak); //tampilkan kata yang tertebak
                    Console.WriteLine();
                }

                if(countFalse != 0) //jika sudah pernah salah
                {
                    Console.WriteLine(hangMan[countFalse < 9 ? countFalse - 1 : 8]); //tampilkan Hang Man
                }

                if(gameOver) //jika game over
                {
                    Console.WriteLine(endMsg); //tampilkan pesan akhir
                    break; //end loop
                }
                else //jika belum game over
                {
                    Console.Write("Huruf Tebakan : ");
                    string input = Console.ReadLine(); //input jawaban
                    input = input.Trim(); //menghilangkan spasi diawal dan akhir
                    //jika dijawab 'enter', maka ulangi pertanyaan
                    if(input == "")
                    {
                        continue;
                    }

                    input = input.Substring(0,1); //jika input lebih dari 1, maka ambil 1 saja
                    //masukkan input ke list
                    listTebakan.Add(input);                
                    //cek huruf yang benar
                    kataTertebak = CekHuruf(kataMisteri, listTebakan);

                    //cek kebenaran kata
                    if(CekKata(kataMisteri, listTebakan)) //jika sudah benar semua
                    {
                        endMsg = "Selamat, anda menang!"; //pesan menang
                        gameOver = true; //game over
                    }
                    else if(kataMisteri.Contains(input))//jika input huruf benar
                    {
                        falseMsg = ""; //tidak ada pesan salah
                    }
                    else //jika input huruf salah
                    {
                        falseMsg = "Tebakan anda salah."; //pesan salah
                        countFalse++; //tambah jawaban salah
                        if(countFalse >= maxFalse) //jika sudah lewat batas salah, game over
                        {
                            endMsg = "Anda kurang beruntung"; //pesan kesalahan
                            gameOver = true; //game over
                        }
                    }
                }
            }
        }

        static bool CekKata(string kata, List<string> list) //cek jawaban apakah sudah benar semua
        {
            bool retValue = false; //nilai return
            for(int i = 0; i < kata.Length; i++)
            {
                string str = Convert.ToString(kata[i]); //huruf ke i
                if(list.Contains(str)) //jika huruf ada, maka benar
                {
                    retValue = true;
                }
                else //jika tidak ada, maka kata belum lengkap
                {
                    return retValue = false; //jika ada yang salah 1 saja, maka langsung return salah
                }
            }
            return retValue;
        }
        
        static string CekHuruf(string kata, List<string> list) //cek huruf apakah benar
        {
            string retValue = "";
            for(int i = 0; i < kataMisteri.Length; i++)
            {
                string str = Convert.ToString(kataMisteri[i]); //huruf ke i
                if(listTebakan.Contains(str)) //jika ada huruf yang benar
                {
                    retValue += str; //tambahkan ke string
                }
                else //jika tidak ada
                {
                    retValue += "_"; //tutupi dengan underscore
                }
            }
            return retValue;
        }
    }
}