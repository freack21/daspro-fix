/*
 Author:
  Fikri Rivandi
  2207112583
  TI-B
  QUIZ 1
  Dasar Pemrograman
*/

using System;

namespace ADUDADU
{
    class Program
    {
        //deklarasi variabel
        static int ronde, maxRonde; //ronde
        static int skorCPU, skorPlayer; //skor
        static int daduCPU, daduPlayer; //nilai dadu
        static bool gamestate; //penunjuk state game
        static Random rng = new Random(); //random mesin

        static void Main(string[] args)
        {
            Init(); //inisialisasi
            Intro(); //intro
            //loop
            while(gamestate)
            {
                Play();
            }

            //exit
            Console.WriteLine("\n(c) ADU DADU - Fikri Rivandi (TI-B)"); Console.ReadKey();
        }

        static void Init() //inisialisasi variabel
        {
            //nilai default
            ronde = 1; //ronde 1
            maxRonde = 10; //max ronde
            skorCPU = 0; //skor cpu
            skorPlayer = 0; //skor player
            daduCPU = 0; //nilai dadu cpu
            daduPlayer = 0; //nilai dadu player
            gamestate = true; //game mulai
        }

        static void Intro() //inisialisasi variabel
        {
            //Intro
            Console.WriteLine("========");
            Console.WriteLine("ADU DADU");
            Console.WriteLine("========\n");
            Console.WriteLine("Pada game ini, player dan CPU akan mengadu keberuntungan\ndalam mengocok dadu.");
            Console.WriteLine("Masing-masing akan mempunyai giliran, dan akan berlangsung selama "+maxRonde+".");
            Console.WriteLine("Yang nilai dadunya tinggi akan mendapatkan skor.");
            Console.WriteLine("Skor tertinggi dialah pemenangnya.\n");
        }

        static void Play()
        {
            Console.WriteLine("========");
            Console.WriteLine("Ronde " + ronde); //print ronde
            Console.WriteLine("========");

            Console.Write("Mulai? "); //mulai?
            Console.ReadKey();

            // CPU TURN
            Console.WriteLine("\n\n-Giliran CPU-");
            Console.Write("Mengocok...    ");

            //animasi
            int t = 0;
            while(t < 1)
            {
                for(int i=0;i<7;i++) //animasi acak dadu player
                {
                    Console.SetCursorPosition(Console.CursorLeft-4,Console.CursorTop);
                    daduCPU = rng.Next(1,7);
                    Console.Write(" ("+daduCPU+")");
                    Thread.Sleep(60);
                }
                t++;
                Thread.Sleep(500); //delay
            }
            Console.WriteLine("    ");
            Console.WriteLine("Dadu CPU: "+daduCPU);
            Console.WriteLine(" ");

            Thread.Sleep(500);  //delay

            //Player TURN
            Console.WriteLine("-Giliran Player-");
            Console.ReadKey(); //input player

            Console.Write("Mengocok...    ");

            //animasi
            t = 0;
            while(t < 1)
            {
                for(int i=0;i<7;i++) //animasi acak dadu player
                {
                    Console.SetCursorPosition(Console.CursorLeft-4,Console.CursorTop);
                    daduPlayer = rng.Next(1,7);
                    Console.Write(" ("+daduPlayer+")");
                    Thread.Sleep(60);
                }
                t++;
                Thread.Sleep(500);  //delay
            }
            Console.WriteLine("    ");
            Console.WriteLine("Dadu Player: "+daduPlayer);
            Console.WriteLine(" ");

            Thread.Sleep(500);  //delay

            //cek hasil
            Console.WriteLine("-Hasil-");
            if(daduCPU > daduPlayer) //dadu cpu besar
            {
                Console.WriteLine("CPU : ("+daduCPU+" > "+daduPlayer+") : Player");
                Console.WriteLine("CPU Menang!");
                skorCPU++;
            }
            else if(daduCPU < daduPlayer) //dadu player besar
            {
                Console.WriteLine("CPU : ("+daduCPU+" < "+daduPlayer+") : Player");
                Console.WriteLine("Player Menang!");
                skorPlayer++;
            }
            else //dadu sama
            {
                Console.WriteLine("CPU : ("+daduCPU+" = "+daduPlayer+") : Player");
                Console.WriteLine("Seri!");
            }

            //cek ronde
            if(ronde >= maxRonde) //ronde sudah max
            {
                Console.WriteLine("\n-Skor Akhir-\n- Skor CPU: "+skorCPU+"\n- Skor Player: "+skorPlayer);
                if(skorCPU > skorPlayer) //cpu menang
                {
                    Console.WriteLine("\n============-");
                    Console.WriteLine("PLAYER KALAH!");
                    Console.WriteLine("============-");
                    Console.WriteLine("\nTetap semangat, Player!");
                }
                else if(skorCPU < skorPlayer) //player menang
                {
                    Console.WriteLine("\n==============");
                    Console.WriteLine("PLAYER MENANG!");
                    Console.WriteLine("==============");
                    Console.WriteLine("\nHEBAT!");
                }
                else //seri
                {
                    Console.WriteLine("\n=====");
                    Console.WriteLine("SERI!");
                    Console.WriteLine("=====");
                    Console.WriteLine("\nAyo main lagi, dan kalahkan musuhmu!");
                }
                gamestate = false; //end loop
            }
            else //jika ronde belum max
            {
                Console.WriteLine("\n-Skor Sementara-\n- Skor CPU: "+skorCPU+"\n- Skor Player: "+skorPlayer);
                Console.WriteLine("\nLanjut ke Ronde selanjutnya.\n");
                ronde++; //ronde ditambah
            }
        }
    }
}