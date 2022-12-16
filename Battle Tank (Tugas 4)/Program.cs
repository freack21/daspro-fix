/*
Originally created by
    Fikri Rivandi
    2207112583
    TI-B
    Tugas 4 | Dasar Pemrograman
*/

using System;

namespace BattleTank
{
    class Program
    {            
        //deklarasikan variabel yang akan dipakai
        static char[,] tankMap; //map tank
        static int[,] posisiMap; //koordinat posisi yang benar
        static int[,] storePosisi; //jawaban yang sudah ditebak
        static int[] tebakPosisi; //tebakan user
        static int jumlahBenar; //jumlah tebakan benar
        static int maxBenar; //jumlah maksimal tebakan benar
        static bool gameOver; //boolean game over
        static int cekPosisi; //cek kebenaran tebakan

        static void Main(string[] args) //Main method / Gerbang program
        {
            Console.Clear(); //clear console

            Init(); //inisialisasi awal variabel

            while(!gameOver) //jika belum game over, maka bermain
            {
                /* un-comment line ini, agar semua ronde tidak menumpuk
                Console.Clear(); //clear console
                */

                try //antisipasi kesalahan input user / index array diluar batas
                {
                    DrawTank(); //menggambar map tank

                    TebakPosisi(); //form menebak posisi

                    cekPosisi = CekTank(); //mengecek tebakan

                    CekBenar(); //print kebenaran tebakan
                }
                catch(Exception e) //handle menggunakan exception
                {
                    //mencari error
                    if(e.GetType().FullName == "System.IndexOutOfRangeException") //index
                    {
                        Console.WriteLine("Error: Index array diluar batas, angka yang valid (1-5)"); //pesan error
                    }
                    else //error yang lain
                    {
                        Console.WriteLine("Error: Yang anda masukkan bukan angka valid"); //pesan error
                    }
                    ResumeGame(); //resume game
                    continue; //skip perulangan sekarang
                }
            } //end loop

            GameOver(); //game over scene
        }

        static void Init() //inisialisasi variabel
        {
            // array[6,6] yang berisi map untuk tank
            tankMap = new char[,]{
                {' ','1','2','3','4','5'},
                {'1','~','~','~','~','~'},
                {'2','~','~','~','~','~'},
                {'3','~','~','~','~','~'},
                {'4','~','~','~','~','~'},
                {'5','~','~','~','~','~'}
            };

            //maksimal jumlah jawaban yang benar
            maxBenar = 3;

            //array[3,2] yang berisi posisi koordinat yang benar
            // posisiMap = new int[,]{
            //     {3,3},
            //     {2,3},
            //     {4,3}
            // };

            //RANDOM posisi tank
            posisiMap = new int[maxBenar,2];
            for(int i = 0; i < maxBenar; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    posisiMap[i,j] = GetPosisi();
                }
            }

            //array untuk mengecek posisi koordinat yang sudah terjawab benar
            storePosisi = new int[3,2];

            //array[2] untuk tempat menyimpan jawaban posisi koordinat dari user
            tebakPosisi = new int[2];

            //menghitung sudah berapa jawaban yang benar
            jumlahBenar = 0;

            //boolean untuk situasi game over
            gameOver = false;

            /*
            Menyimpan hasil cek jawaban user,
            Jika 0, maka salah
            Jika 1, maka benar
            Jika 2, maka sudah terjawab
            */
            cekPosisi = 0;
        }

        static int GetPosisi() //function random posisi tank
        {
            Random rpg = new Random(); //random position generator
            return rpg.Next(1,6);
        }

        static void DrawTank() //menggambar dan mengupdate map
        {
            for(int y = 0; y < 6; y++) //posisi y/vertikal map
            {
                for(int x = 0; x < 6; x++) //posisi x/horizontal map
                {
                    Console.Write(tankMap[y,x] + " "); //gambar map di console
                }
                Console.Write("\n"); //enter sesudah menggambar seluruh koordinat x
            }
        }

        static void AnimasiTank(int state) //menggambar animasi map
        {
            DrawTank(); //gambar map

            //mendapatkan posisi kursor
            int left = Console.GetCursorPosition().Left;
            int top = Console.GetCursorPosition().Top;

            if(state == 1) //jika tebakan benar
            {
                for(int i = 1; i < 49; i++)
                {
                    //menempatkan kursor di tempat yang benar
                    Console.SetCursorPosition((tebakPosisi[1] * 2), (top - 6) + tebakPosisi[0]);

                    Console.Write((char)(49 - i)); //menggambar animasi kode tank

                    Thread.Sleep(30); //delay
                }

                //gambar map tank kembali
                Console.SetCursorPosition(0, top - 6);
                DrawTank();
            }
        }

        static int CekTank() //mengecek kebenaran tebakan posisi koordinat tank
        {
            for(int i = 0; i < 3; i++)
            {
                /*
                Cek, apakah tebakan user sudah ada di isi dari recent?
                Jika sudah, akhiri method, dan return 2
                Jika belum, lanjutkan method untuk mengecek kebenaran tebakan
                */
                if(storePosisi[i,0] == tebakPosisi[0] && storePosisi[i,1] == tebakPosisi[1])
                {
                    return 2; //cekPosisi = 2, maka sudah terjawab
                }
            }

            for(int i = 0; i < 3; i++)
            {
                //Cek, apakah tebakan user benar?
                if(posisiMap[i,0] == tebakPosisi[0] && posisiMap[i,1] == tebakPosisi[1]) //jika benar
                {
                    tankMap[tebakPosisi[0],tebakPosisi[1]] = 'X'; //ubah char posisi benar menjadi tanda tank

                    //memasukkan tebakan yang sudah benar
                    storePosisi[i,0] = tebakPosisi[0];
                    storePosisi[i,1] = tebakPosisi[1];

                    return 1; //cekPosisi = 1, maka jawaban benar
                }
                else //jika salah
                {
                    tankMap[tebakPosisi[0],tebakPosisi[1]] = '.'; //ubah char di posisi salah
                }
            }
            return 0; //cekPosisi = 0, maka salah
        }

        static void CekBenar() //cek kebenaran tebakan
        {
            Console.WriteLine($"Menyerang [{tebakPosisi[0]},{tebakPosisi[1]}]...");

            if(cekPosisi == 2) //jika tebakan sudah pernah diinput
            {
                Console.WriteLine("\nPosisi musuh sudah dideteksi,\n");

                AnimasiTank(2); //update dan gambar tank map

                Console.WriteLine("\nTank musuh sudah dihancurkan!");
            }
            else if(cekPosisi == 1) //jika tebakan benar
            {
                Console.WriteLine("\nPosisi musuh terdeteksi,\n");

                AnimasiTank(1); //update dan gambar tank map

                Console.WriteLine("\nBOOM!! Tank musuh hancur!");

                jumlahBenar++; //jumlah jawaban benar ditambah
            }
            else //jika tebakan salah
            {
                Console.WriteLine("\nMISS!! Serangan meleset!\n");

                AnimasiTank(0); //update dan gambar tank map

                Console.WriteLine("\nPosisi musuh belum terdeteksi.");
            }

            //cek, apakah semua posisi tank sudah terjawab semua?
            if(jumlahBenar >= maxBenar) //jika sudah
            {
                Console.WriteLine("\n-Menang! Tank musuh telah dihancurkan semua!-".ToUpper());
                Console.ReadKey();
                gameOver = true; //maka akan game over
            }
            else if(jumlahBenar < maxBenar) //jika belum
            {
                ResumeGame(); //resume game
            }
        }

        static void GameOver() //game over scene
        {
            Console.Clear(); //clear console
            Console.WriteLine("Permainan berakhir!!");
            Console.WriteLine("Terimakasih sudah bermain.");
            Console.Write("\n(c) Battle Tank - Fikri Rivandi"); Console.ReadKey(); //exit
            Console.WriteLine();
        }

        static void ResumeGame() //resume game yang sedang dihentikan
        {
            Console.Write("\nLanjut? [n=tidak / ENTER=lanjut] "); //konfirmasi lanjut game atau tidak

            if(Console.ReadLine() == "n") //jika pilih no
            {
                gameOver = true; //maka game over
            }

            Console.WriteLine("--------------------------------");
        }

        static void TebakPosisi() //form menebak posisi koordinat tank
        {
            Console.Write("Pilih Baris (1-5): ");
            tebakPosisi[0] = Convert.ToInt32(Console.ReadLine()); //mengisi tebakan posisi baris

            Console.Write("Pilih Kolom (1-5): ");
            tebakPosisi[1] = Convert.ToInt32(Console.ReadLine()); //mengisi tebakan posisi kolom

            if(tebakPosisi[0] == 0 || tebakPosisi[1] == 0) //jika input 0, ubah jadi 6, maka akan error
            {
                tebakPosisi[0] = 6;
                tebakPosisi[1] = 6;
            }
        }
    }
}