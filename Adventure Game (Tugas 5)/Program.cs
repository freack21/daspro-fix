/*
Fikri Rivandi - 2207112583 - TIB
Adventure : The Game
*/

using System;

namespace Adventure {
    class Program {
        private static int gameState = 0;
        static void Main(string[] args)
        {
            Console.Clear();

            while(true)
            {
                switch(gameState)
                {
                    case 0:
                    gameState = Resources.Menu();
                    continue;
                    case 1:
                    Play();
                    continue;
                    case 2:
                    Resources.Help();
                    gameState = 0;
                    continue;
                    case 3:
                    Resources.About();
                    gameState = 0;
                    continue;
                    case 4:
                    gameState = Resources.Exit();
                    continue;
                    default:
                    break;
                }
                break;
            }
        }

        static void Play()
        {
            string str = "";
            while(true)
            {
                Console.Clear();

                Console.WriteLine("Selamat Datang, Player Baru!\nSiapa namamu?");
                Console.Write(">> ");
                str = Console.ReadLine();
                if(str == "")
                    continue;
                break;
            }
            Console.Clear();

            Console.WriteLine($"Halo, {str}!\nIngin melanjutkan ke petualangan ini? [y/n]");
            Console.Write(">> ");
            string input = Console.ReadLine();
            if(input == "n" || input == "N")
            {
                Console.Clear();
                Console.Write($"Selamat tinggal, {str}!\nKembalilah kesini kapanpun kamu mau {(char)2}{(char)2}");
                Console.ReadKey();
                gameState = 0;
            }
            else
            {
                Console.Clear();
                Console.Write("Memuat permainan.");
                int i = 0;
                Player player = new Player();
                Enemy enemy = new Enemy();
                while(i < 4)
                {
                    if(i < 1)
                    {
                        player = new Player(str,0);
                        i++;
                        Console.Write(".");
                        Thread.Sleep(60);
                        enemy = new Enemy("Gollum", 0);
                        i++;
                        Console.Write(".");
                        Thread.Sleep(60);
                        player.SetEnemy(enemy.name);
                        enemy.SetPlayer(player.name);
                    }
                    else
                    {
                        i++;
                        Console.Write(".");
                        Thread.Sleep(500);
                    }
                }
                Paint(player, enemy);
            }
        }

        static void Paint(Player player, Enemy enemy)
        {
            int level = 0;
            int maxLevel = 1;
            bool firstTime = true;
            bool conversation = true;
            int attackTurn = 0;
            int attackType = 0;
            Console.Clear();

            while(level != -1)
            {
                if(conversation)
                {
                    Resources.Conversation(level, player.name, enemy.name);
                    conversation = false;
                }
                int pl = player.name.Length;
                int el = enemy.name.Length;
                int l = Math.Max(pl, el);
                int k = l + 22;
                Console.WriteLine("{0,-" + (l) + "} {1,-11} {2,-11} {3, -13}", player.name, $"| HP : {player.HP}", $"| EXP : {player.exp}", $"| ENERGY : {player.energy}");
                Console.WriteLine("{0,-" + (l) + "} {1,-11} {2,-11} {3, -13}", enemy.name, $"| HP : {enemy.HP}", $"| EXP : {enemy.exp}", $"| ENERGY : {enemy.energy}");
                Console.WriteLine("LEVEL " + (level + 1));
                Console.WriteLine("-------");

                if(firstTime)
                {
                    if(level == maxLevel)
                        Console.WriteLine("PERTARUNGAN TERAKHIR!!");
                    Console.WriteLine($"{player.name.ToUpper()} vs {enemy.name.ToUpper()}");
                    Console.WriteLine("MULAI!!!\n");
                }

                if(attackTurn == 0 && !player.isDead)
                {
                    Console.WriteLine($"GILIRAN {player.name.ToUpper()}!");
                    Console.WriteLine("[1] Serangan Biasa [2] SpearFlip [3] Memulihkan Energi [4] Memulihkan HP [5] Lari");
                    Console.Write(">> ");
                    try {
                        attackType = int.Parse(Console.ReadLine());
                        if(attackType < 1 || attackType > 5)
                        {
                            Console.Clear();
                            continue;
                        }

                        attackTurn = 1;
                        firstTime = false;
                    } catch (Exception) {Console.Clear();continue;}

                    switch(attackType)
                    {
                        case 1:
                        enemy.GetHit(player.SingleAttack());
                        break;
                        case 2:
                        if(player.SpearFlip())
                        {
                            attackTurn = 2;
                            enemy.GetHit(player.damage);
                        }
                        break;
                        case 3:
                        player.Heal(0);
                        break;
                        case 4:
                        player.Heal(1);
                        break;
                        case 5:
                        player.RunAway();
                        Console.WriteLine();
                        break;
                        default:
                        break;
                    }
                }

                if(attackTurn == 1 && !enemy.isDead && !player.isDead)
                {
                    Console.WriteLine();
                    Console.WriteLine($"GILIRAN {enemy.name.ToUpper()}!");

                    if(enemy.type == 1)
                    {
                        enemy.damage = 3 * player.defaultDamage;
                        enemy.SetDamage(30 * player.HP / 100);
                    }
                    int s = enemy.Attack();
                    if(s != 2 && s != 0)
                        player.GetHit(enemy.skillDamage);
                    else if(s == 0)
                        player.GetHit(enemy.SingleAttack());
                    attackTurn = 0;
                    Console.WriteLine();
                }

                if(attackTurn == 2 && !enemy.isDead && !player.isDead)
                {
                    Console.WriteLine();
                    Console.WriteLine($"GILIRAN {enemy.name.ToUpper()}!");
                    Console.WriteLine(enemy.name + $" tidak bisa menyerang {player.name}...");
                    attackTurn = 0;
                    Console.WriteLine();
                }

                if(enemy.isDead)
                {
                    Console.WriteLine();
                    player.defaultDamage += 5;
                    player.AddHP(200);
                    player.Heal(0);
                    player.AddExp(10);
                    Console.WriteLine();
                }

                if(!player.isDead && !enemy.isDead)
                    Console.WriteLine("[ENTER] Lanjutkan Pertarungan [R] Lari");
                else
                    Console.WriteLine("[ENTER] Lanjutkan");
                Console.Write(">> ");
                string str = Console.ReadLine();
                if((str == "R" || str == "r") && (!enemy.isDead && !player.isDead))
                {
                    Console.Clear();
                    player.RunAway();
                    Console.WriteLine();
                }
                else
                {
                    Console.Clear();
                }

                while(enemy.isDead || player.isDead)
                {
                    if(enemy.isDead && level != maxLevel)
                    {
                        Console.WriteLine($"{player.name} memenangkan pertarungan! Mantap!\n");
                        Console.WriteLine("Lanjutkan ke level " + (level + 2) + "?");
                        Console.WriteLine("[1] Lanjut [2] Kembali ke Menu [3] Keluar");
                        Console.Write(">> ");
                        try {
                            int input = int.Parse(Console.ReadLine());
                            if(input < 1 || input > 3)
                            {
                                Console.Clear();
                                continue;
                            }
                            switch(input)
                            {
                                case 1:
                                Console.Clear();
                                level++;
                                conversation = true;
                                string enemyName = "Sauron";
                                enemy.setType(level);
                                player.SetEnemy(enemyName);
                                enemy.name = enemyName;
                                firstTime = true;
                                attackTurn = 0;
                                Console.Clear();
                                break;
                                case 2:
                                gameState = 0;
                                level = -1;
                                break;
                                case 3:
                                gameState = 5;
                                level = -1;
                                break;
                            }
                        } catch (Exception) {Console.Clear();continue;}
                    }
                    else if(level >= maxLevel && enemy.isDead)
                    {
                        Console.WriteLine($"Selamat, {player.name}! KAMU MENANG!\nKamu adalah Raja baru dari Kerajaan Cahaya!!\n");
                        Console.WriteLine("[1] Kembali Menu [2] Keluar");
                        Console.Write(">> ");
                        try {
                            int input = int.Parse(Console.ReadLine());
                            if(input < 1 || input > 2)
                            {
                                Console.Clear();
                                continue;
                            }
                            switch(input)
                            {
                                case 1:
                                gameState = 0;
                                level = -1;
                                break;
                                case 2:
                                gameState = 5;
                                level = -1;
                                break;
                            }
                        } catch (Exception) {Console.Clear();continue;}
                    }
                    else
                    {
                        Console.WriteLine($"PERMAINAN BERAKHIR!!\n{player.name}, kamu gagal menyelesaikan misi!\nDunia masih gelap, Kami membutuhkan kamu untuk mngalahkan semua iblis!\n");
                        Console.WriteLine("[1] Main Lagi [2] Kembali ke Menu [3] Keluar");
                        Console.Write(">> ");
                        try {
                            int input = int.Parse(Console.ReadLine());
                            if(input < 1 || input > 3)
                            {
                                Console.Clear();
                                continue;
                            }
                            level = -1;
                            switch(input)
                            {
                                case 1:
                                gameState = 1;
                                break;
                                case 2:
                                gameState = 0;
                                break;
                                case 3:
                                gameState = 5;
                                break;
                            }
                        } catch (Exception) {Console.Clear();continue;}
                    }
                    break;
                }
            }
        }
    }

    class Player
    {
        public int HP { get; set; }
        public int defaultDamage { get; set; }
        public int damage { get; set; }
        public int lives { get; set; }
        public int exp { get; set; }
        public int energy { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string enemyName { get; set; }
        public bool isDead { get; set; }
        Random rdg = new Random();

        public Player() {}

        public Player(string n, int t)
        {
            name = n;
            lives = 3;
            HP = 100;
            defaultDamage = 3;
            exp = 10;
            energy = 2;
            type = t;
        }

        public int SingleAttack()
        {
            damage += rdg.Next(defaultDamage, exp + 1);
            Console.WriteLine($"{name} menyerang.. ({damage} dmg)");
            return damage;
        }

        public void Die()
        {
            Console.WriteLine($"{name} mati. {enemyName} membunuh {name}..");
            isDead = true;
        }

        public void RunAway()
        {
            Console.WriteLine($"{name} melarikan diri dari {enemyName}! {name.ToUpper()} KALAH!");
            isDead = true;
        }

        public void GetHit(int dmg)
        {
            Console.WriteLine($"{name} mendapat damage dari {enemyName} (-{dmg} HP)");
            damage = defaultDamage;
            HP -= dmg;
            if(HP <= 0)
            {
                HP = 0;
                Die();
            }
        }

        public int AddExp(int e)
        {
            Console.WriteLine($"{name} mendapat +{e} poin EXP!");
            return exp += e;
        }

        public int AddEnergy(int e)
        {
            Console.WriteLine($"{name} mendapatkan +{e} Energi!");
            return energy += e;
        }

        public int AddHP(int e)
        {
            Console.WriteLine($"{name} mendapatkan +{e} HP!");
            return HP += e;
        }

        public void SetEnemy(string enemy)
        {
            enemyName = enemy;
        }

        public bool SpearFlip()
        {
            if(energy > 0)
            {
                damage += rdg.Next(defaultDamage, exp + 1);
                System.Console.WriteLine("SRINKKK!!!!");
                Console.WriteLine($"{name} menyerang {enemyName} dengan SpearFlip.. ({damage} dmg)");
                energy--;
                return true;
            }
            else
            {
                Console.WriteLine($"{name} tidak memiliki energi. Pulihkan energi terlebih dulu.");
                damage = defaultDamage;
                return false;
            }
        }

        public void Heal(int t)
        {
            if(t == 0)
            {
                Console.WriteLine($"{name} memulihkan energi..");
                AddEnergy(2);
            }
            else
            {
                Console.WriteLine($"{name} memulihkan HP..");
                AddHP(damage);
            }
        }
    }

    class Enemy
    {
        public int HP { get; set; }
        public int defaultDamage { get; set; }
        public int damage { get; set; }
        public int skillDamage { get; set; }
        public int lives { get; set; }
        public int exp { get; set; }
        public int energy { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string playerName { get; set; }
        public bool isDead { get; set; }
        Random rdg = new Random();

        public Enemy() {}

        public Enemy(string n, int t)
        {
            name = n;
            lives = 3;
            playerName = "Player";
            HP = 50;
            defaultDamage = 2;
            exp = 10;
            energy = 0;
            setType(t);
        }

        public void setType(int t)
        {
            switch(t)
            {
                case 1:
                HP = 1000;
                defaultDamage = 5;
                exp = 20;
                break;

                default:
                break;
            }
            isDead = false;
            skillDamage = defaultDamage;
            damage = defaultDamage;
            type = t;
        }

        public int SingleAttack()
        {
            if(damage == defaultDamage)
                damage = rdg.Next(defaultDamage, exp + 1);
            else
                damage += rdg.Next(defaultDamage, exp + 1);
            Console.WriteLine($"{name} menyerang.. ({damage} dmg)");
            skillDamage = damage;
            return damage;
        }

        public void Die()
        {
            Console.WriteLine($"{name} mati. {playerName} membunuh {name}..");
            isDead = true;
        }

        public void GetHit(int dmg)
        {
            Console.WriteLine($"{name} mendapat damage dari {playerName}.. (-{dmg} HP)");
            damage = defaultDamage;
            HP -= dmg;
            if(HP <= 0)
            {
                HP = 0;
                Die();
            }
        }

        public void SetPlayer(string enemy)
        {
            playerName = enemy;
        }

        public int SetDamage(int dmg)
        {
            return skillDamage = dmg;
        }

        public void SkillAttack()
        {
            if(energy > 0)
            {
                Console.WriteLine($"{name} menyerang {playerName} dengan WarAxe.. ({skillDamage} dmg)");
                energy--;
            }
            else
            {
                damage = defaultDamage;
                SingleAttack();
            }
        }

        public int Attack()
        {
            int attackType = rdg.Next(0,3);
            if(attackType == 1)
            {
                if(type == 1)
                {
                    SkillAttack();
                    return 1;
                }
            }
            else if(attackType == 2)
            {
                if(type != 0 && energy < 3)
                {
                    Heal();
                    return 2;
                }
                else if(type != 0 && energy >= 2)
                {
                    if(type == 1)
                    {
                        SkillAttack();
                        return 1;
                    }
                }
            }
            return 0;
        }

        public void Heal()
        {
            energy++;
            Console.WriteLine($"{name} memulihkan energi.. (+1 energi)");
        }
    }

    class Resources
    {
        public static int Menu()
        {
            Console.Clear();

            string str = "|--------------------|";
            Console.WriteLine(str);
            Console.WriteLine("{0,-9}{1,-12}{2}", "|", "MENU", "|");
            Console.WriteLine("{0,-21}{1}", "| 1. Main", "|");
            Console.WriteLine("{0,-21}{1}", "| 2. Bantuan", "|");
            Console.WriteLine("{0,-21}{1}", "| 3. Tentang", "|");
            Console.WriteLine("{0,-21}{1}", "| 4. Keluar", "|");
            Console.WriteLine(str);
            Console.Write(">> ");
            try
            {
                int retVal = Convert.ToInt16(Console.ReadLine());
                if(retVal < 0 || retVal > 4)
                {
                    retVal = 0;
                }
                return retVal;
            }
            catch(Exception)
            {
                Console.WriteLine("!! Input tidak valid !!");
                return 0;
            }
        }

        public static void Help()
        {
            Console.Clear();

            string str = "|----------------------------------------------------------------------|";
            Console.WriteLine(str);
            Console.WriteLine("{0,-34}{1,-37}{2}", "|", "BANTUAN", "|");
            Console.WriteLine("{0,-71}{1}", "| Pada game ini, Player akan masuk ke dunia petualangan yang sangat", "|");
            Console.WriteLine("{0,-71}{1}", "| gelap.", "|");
            Console.WriteLine("{0,-71}{1}", "| Player akan menemukan anak buah dan raja kegelapan.", "|");
            Console.WriteLine("{0,-71}{1}", "| Player ditugaskan untuk merebut dunia kegelapan dari raja kegelapan", "|");
            Console.WriteLine("{0,-71}{1}", "| dan menjadi raja didunia tersebut.", "|");
            Console.WriteLine(str);
            Console.Write(">> Press any key..");
            Console.ReadKey();
        }

        public static void About()
        {
            Console.Clear();

            string str = "|----------------------------------------------------------------------|";
            Console.WriteLine(str);
            Console.WriteLine("{0,-34}{1,-37}{2}", "|", "TENTANG", "|");
            Console.WriteLine("{0,-71}{1}", "| Adventure : The Game", "|");
            Console.WriteLine("{0,-71}{1}", "| Version 1.0", "|");
            Console.WriteLine("{0,-71}{1}", "|", "|");
            Console.WriteLine("{0,-17}{1,-54}{2}", "| Pembuat", " : Fikri Rivandi", "|");
            Console.WriteLine("{0,-71}{1}", "| Dosen Pengampu  : Rahmat Rizal Andhi, ST, MT", "|");
            Console.WriteLine("{0,-17}{1,-54}{2}", "| Kelas", " : S1 Teknik Informatika B", "|");
            Console.WriteLine("{0,-17}{1,-54}{2}", "| Proyek", " : Tugas 5 (Access Modifier & Class)", "|");
            Console.WriteLine("{0,-71}{1}", "|", "|");
            Console.WriteLine("{0,-25}{1,-46}{2}", "| ", "(c) 2022 Fikri Rivandi", "|");
            Console.WriteLine("{0,-25}{1,-46}{2}", "| ", "  All Right Deserved", "|");
            Console.WriteLine(str);
            Console.Write(">> Press any key..");
            Console.ReadKey();
        }

        public static int Exit()
        {
            Console.Clear();

            string str = "|---------------------------|";
            Console.WriteLine(str);
            Console.WriteLine("{0,-12}{1,-16}{2}", "|", "KELUAR", "|");
            Console.WriteLine("{0,-28}{1}", "| Yakin ingin keluar? [y/n]", "|");
            Console.WriteLine(str);
            Console.Write(">>  ");
            int retVal = 5;
            string input = Console.ReadLine();
            if(input == "n" || input == "N")
            {
                retVal = 0;
            }
            return retVal;
        }

        public static void Conversation(int level, string name1, string name2)
        {
            if(level == 0)
            {
                Console.Write(name1 + " memasuki dunia kegelapan...");
                Console.ReadKey();
                Console.WriteLine();
                Console.Write(name1 + " menyusuri hutan kegelapan..");
                Console.ReadKey();
                Console.WriteLine();
                Console.Write(name2 + " mendekat....");
                Console.ReadKey();
                Console.WriteLine();
            }
            else if(level == 1)
            {
                Console.Write(name1 + " berhasil keluar dari hutan kegelapan..");
                Console.ReadKey();
                Console.WriteLine();
                Console.Write(name1 + " pergi ke Mordor, Kerajaan kegelapan terkuat...");
                Console.ReadKey();
                Console.WriteLine();
                Console.Write(name1 + " akan bertemu Raja Kegelapan, " + name2 + "...");
                Console.ReadKey();
                Console.WriteLine();
                Console.Write(name2 + " datang....");
                Console.ReadKey();
                Console.WriteLine();
            }
            Console.Clear();
        }
    }
}