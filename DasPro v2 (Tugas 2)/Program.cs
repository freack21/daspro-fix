/*
Created by Fikri Rivandi - 2207112583
*/

using System;

namespace DasPro
{
    class Program
    {
        /*
        deklarasi variabel,
        deklarasi dilakukan diluar agar
        semua function bisa menggunakan variabelnya
        */
        public static int codeA;
        public static int codeB;
        public static int codeC;
        public static int jumlahKode;
        public static int level;
        public static int maxLevel;
        public static int hasilTambah;
        public static int hasilKali;
        public static int hasilKurang;
        public static int hasilBagi;
        public static int kesempatan;
        public static String tebakanA;
        public static String tebakanB;
        public static String tebakanC;
        public static bool bGameStart;

        //Main Method
        static void Main(string[] args)
        {
            //Inisialisasi awal variabel penting
            Init();

            //mencari nilai awal code
            GetCode();
            //tampilkan splash
            Splash();

            //ketika gamestart adalah true
            while(bGameStart)
            {
                //Membersihkan console
                Console.Clear();

                if(kesempatan >= 1 && level <= maxLevel) //jika level masih belum max dan kesempatan menjawab masih ada
                {
                    //bermain
                    PlayGame();
                }
                else if(kesempatan >= 1 && level > maxLevel) //jika kesempatan belum habis, tapi sudah terjawab semua
                {
                    //akhiri program, player menang
                    ShowEnd(2);
                }
                else if(kesempatan < 1 && level != 1) //jika kesempatan habis, tapi sudah pernah bisa menjawab
                {
                    //akhiri program, player sudah bisa menjawab beberapa level
                    ShowEnd(1);
                }
                else //jika kesempatan habis, dan tidak pernah bisa menjawab
                {
                    //akhiri program, player tidak bisa menjawab
                    ShowEnd(4);
                }
            }

            //Press any key to exit
            Console.WriteLine("(c) Fikri Rivandi - 2207112583 (TI-B)"); Console.ReadKey();
        }

        static void Init()
        {
            //Inisialisasi variabel penting
            jumlahKode = 3;
            level = 1;
            kesempatan = 3;
            bGameStart = true;
            maxLevel = 5;
        }

        static void GetCode()
        {
            //Cari nilai random untuk code
            Random rng = new Random();
            /*
            isi code dengan nilai random
            besar index berdasarkan level+2
            */
            codeA = rng.Next(1,level+2);
            codeB = rng.Next(1,level+2);
            codeC = rng.Next(1,level+2);

            //Operasi variabel untuk hint jawaban
            hasilTambah = codeA + codeB + codeC;
            hasilKali = codeA * codeB * codeC;
            //hasilKurang = codeA - codeB - codeC;
            //hasilBagi = codeA / codeB / codeC;
        }

        static void Intro()
        {
            //Print Level dan kesempatan, agar player tau level kesulitan dan kesempatan ia menjawab
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Kesempatan: " + kesempatan);
            Console.WriteLine("-------------");

            //Print Intro
            Console.WriteLine("Anda adalah agen rahasia yang bertugas mendapatkan data dari server");
            Console.WriteLine("Akses ke server membutuhkan password yang tidak diketahui...");

            //hint
            Console.WriteLine("- Password terdiri dari " + jumlahKode +" angka");
            Console.WriteLine("- Jika ditambahkan hasilnya " + hasilTambah);
            Console.WriteLine("- Jika dikalikan hasilnya " + hasilKali);
            //Console.WriteLine("- Jika dikurangkan hasilnya " + hasilKurang);
            //Console.WriteLine("- Jika dibagikan hasilnya " + hasilBagi);

            //Cheat melihat code secara langsung
            //Console.WriteLine("Code : " + codeA + " " + codeB + " " + codeC);
        }

        static void PlayGame()
        {
            //Print Intro
            Intro();

            //Print UI tebak kode
            Console.Write("\n-TEBAK-\n");
            Console.Write("Masukkan Kode Pertama : "); tebakanA = Console.ReadLine();
            Console.Write("Masukkan Kode Kedua : "); tebakanB = Console.ReadLine();
            Console.Write("Masukkan Kode Ketiga : "); tebakanC = Console.ReadLine();
            Console.WriteLine("Tebakan anda : " + tebakanA + " " + tebakanB + " " + tebakanC);

            //animasi splash
            /* Console.Write("Mengecek.");
            int timer=3;
            while(timer > 0)
            {
                Console.Write(".");
                Thread.Sleep(500);
                timer--;
            } */
            Console.WriteLine("\n-------------------");

            //Cek tebakan
            if(tebakanA == codeA.ToString() && tebakanB == codeB.ToString() && tebakanC == codeC.ToString())
            {
                Console.WriteLine("Tebakan anda benar!");

                //jika tebakan benar, level ditambah
                level++;
                if(level <= maxLevel) //jika tebakan benar dan level belum max, print level ditambah
                {
                    Console.WriteLine("Level ditambah.. (Level "+level+")");
                }

                //jika benar, code akan dirandom lagi
                GetCode();
            }
            else //keadaan kode salah
            {
                Console.WriteLine("Tebakan anda salah!");

                //membuat hint kepada player
                int jumlahBenar = 0;
                jumlahBenar = (tebakanA == codeA.ToString() ? jumlahBenar + 1 : jumlahBenar);
                jumlahBenar = (tebakanB == codeB.ToString() ? jumlahBenar + 1 : jumlahBenar);
                jumlahBenar = (tebakanC == codeC.ToString() ? jumlahBenar + 1 : jumlahBenar);
                Console.WriteLine("Anda sudah menjawab " + jumlahBenar + " kode dengan benar.");

                //jika salah, kesempatan menjawab berkurang
                kesempatan--;
                Console.WriteLine("Kesempatan menebak sisa " + kesempatan + "..");
            }
            Console.WriteLine("-------------------");

            //Loading delay 3-5 detik
            /* Console.Write("Memuat..   ");
            int timer=4;
            while(timer > 0)
            {
                Console.SetCursorPosition(Console.CursorLeft-2, Console.CursorTop);
                Console.Write(timer + "s");
                Thread.Sleep(1000);
                timer--;
            } */

            //konfirmasi player
            //lanjutkan game ke level selanjutnya atau berhenti bermain
            //akan tampil ketika kesempatan > 0
            if(kesempatan > 0 && level <= 5)
            {
                Console.Write("\nLanjutkan game? [1=iya] [2=tidak]\nJawab: ");
                if(Console.ReadLine() == "2") //player tidak ingin melanjutkan game
                {
                    if(level == 1)
                    {
                        ShowEnd(-1);                    
                    }
                    else
                    {
                        ShowEnd(0);
                    }
                }
            }
       }

       static void Splash()
       {
            //animasi splash
            Console.Clear();
            Console.Write("Memuat game");
            int timer=5;
            while(timer > 0)
            {
                Console.Write(".");
                Thread.Sleep(200);
                timer--;
            }
       }

       static void ShowEnd(int type)
       {
            /*type
            3 = menang
            2,1,0,-1 = game over
            4 = kalah
            */
            Console.Clear();
            if(type == 2) //kondisi level mencapai max dan kesempatan masih ada
            {
                Console.WriteLine("------");
                Console.WriteLine("MENANG");
                Console.WriteLine("------");
                Console.WriteLine("Tebakan anda benar semuanya!\nAnda sudah memecahkan semua level.");
                Console.WriteLine("\nHEBAT!!\n");
            }
            else if(type == 1) //kondisi level belom max tapi kesempatan sudah habis
            {
                Console.WriteLine("---------");
                Console.WriteLine("GAME OVER");
                Console.WriteLine("---------");
                Console.WriteLine("Kesempatan menebak habis.\nAnda sudah menjawab sampai level " + (level - 1) + ".");
                Console.WriteLine((maxLevel - level + 1) + " level yang tersisa.\n");
                Console.WriteLine("Semangat dan coba lagi.\n");
            }
            else if(type == 0) //kondisi level belom max tapi player mengakhiri game
            {
                Console.WriteLine("---------");
                Console.WriteLine("GAME OVER");
                Console.WriteLine("---------");
                Console.WriteLine("Anda mengakhiri game.\nAnda sudah menjawab sampai level " + (level - 1) + ".");
                Console.WriteLine((maxLevel - level + 1) + " level yang tersisa.\n");
                Console.WriteLine("Ayo main lagi!\n");
            }
            else if(type == -1) //kondisi level belom max tapi player mengakhiri game
            {
                Console.WriteLine("---------");
                Console.WriteLine("GAME OVER");
                Console.WriteLine("---------");
                Console.WriteLine("Anda mengakhiri game.\nAnda belum menjawab 1 level pun.");
                Console.WriteLine("\nAyo main lagi!\n");
            }
            else //tidak bisa menjawab
            {
                Console.WriteLine("-----");
                Console.WriteLine("KALAH");
                Console.WriteLine("-----");
                Console.WriteLine("Kesempatan menebak habis.\nAnda belum bisa menjawab 1 level pun.\n");
                Console.WriteLine("Semangat dan coba lagi.\n");
            }
            //end loop
            bGameStart = false;
       }
    }
}