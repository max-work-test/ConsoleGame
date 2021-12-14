using System;
using System.Linq;

namespace ConsoleGame
{




    public class Fighter
    {
        public int health { set; get; }
        public int attack;
        public string name;
        public Fighter(int Health,int Attack,string Name)
        {
            name = Name;
            health = Health;
            attack = Attack;
        }
    }
    class Program
    {
        public static string[] direction = { "head", "body", "legs" };
        static Boolean Fight(Fighter opponent_1, Fighter opponent_2)
        {
            string impact_1, defense_1;
            int impact_2, defense_2;

            Random rnd = new Random();
            while (opponent_1.health > 0 && opponent_2.health > 0)
            {
                Console.WriteLine("Choose the direction of impact:(head/body/legs)");
                impact_1 = Console.ReadLine();
                Console.WriteLine("Okay, now choose your defense:(head/body/legs)");
                defense_1 = Console.ReadLine();
                impact_2 = rnd.Next(direction.Length);
                defense_2 = rnd.Next(direction.Length);
                Attack(impact_1, direction[impact_2], defense_1, direction[defense_2], opponent_1, opponent_2);
            }
            if (opponent_1.health < 0)
            {
                Console.WriteLine("You lose :(");
                return false;
            }
            else
            {
                Console.WriteLine("You win! " + opponent_2.name + " defeated!");
                Console.WriteLine("Prepare for next fight.");
                return true;
            }
        }
        static bool Pause()
        {
            Console.WriteLine("Are u ready for battle? (y/n)");
            string answer =  Console.ReadLine();
            if(answer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello fighter, introduce yourself: ");
            string name = Console.ReadLine();
            Fighter GG = new Fighter(100, 100, name);
            Fighter enemy_1 = new Fighter(50, 5, "Noob");
            Fighter enemy_2 = new Fighter(100, 10, "Teacher");
            Fighter enemy_3 = new Fighter(150, 15, "Master");
            Fighter enemy_4 = new Fighter(200, 20, "Beast");
            Fighter[] enemy = { enemy_1, enemy_2, enemy_3, enemy_4 };
            bool answer = Pause();
            if (answer)
            {
                bool win = true;
                int counter = 0;
                while (win && counter<4 && answer)
                {
                    win = Fight(GG, enemy[counter]);
                    counter++;
                    answer = Pause();
                }
                if (win)
                {
                    Console.WriteLine("Congratulations! You win all enemies!");
                }
                
            }
        }
        
        static void Attack(string impact_1,string impact_2,string defense_1,string defense_2,Fighter opponent_1,Fighter opponent_2)
        {
            if (direction.Contains(impact_1))
            {
                if (impact_1 == defense_2)
                {
                    Console.WriteLine(opponent_2.name + " blocked your beat :(");
                }
                else
                {
                    Console.WriteLine("You did " + opponent_1.attack + " damage to " + opponent_2.name);
                    opponent_2.health -= opponent_1.attack;
                }
            }
            else
            {
                Console.WriteLine("You choose wrong direction, are u noob?");
            }



            if (direction.Contains(defense_1))
            {
                if (impact_2 == defense_1)
                {
                    Console.WriteLine("You blocked the hit!");
                }
                else
                {
                    Console.WriteLine(opponent_2.name + " did " + opponent_2.attack + " damage to you" );
                    opponent_1.health -= opponent_2.attack;
                }
            }
            else
            {
                Console.WriteLine("You choose wrong direction, are u noob?");
            }
        }
    }
}
