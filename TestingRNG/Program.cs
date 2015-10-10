using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingRNG
{

    class Program
    {
        public Random Random = new Random();
        public int dropRate, itemAmmount;
        public List<Items> Loot = new List<Items>();
        public List<string> WeaponList = new List<string> { "Staff", "Sword", "Dagger", "Wand", "Axe", "Mace" };
        static void Main(string[] args)
        {
            Program Program = new Program();
        }
        public Program()
        {
            Console.WriteLine("How many items do you want to generate");
            itemAmmount = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < itemAmmount; i++)
            {
                dropRate = Random.Next(1, 6);
                Loot.Add(new Items(i,dropRate, Random));
            }
            foreach (var Item in Loot)
            {
                Console.WriteLine(Item.Name);
                Console.WriteLine(Item.NumberOfNames);
                if (WeaponList.Contains(Item.ItemType))
                {
                    Console.WriteLine("Damage :{0}", Item.Damage);
                }
                else
                {
                    Console.WriteLine("HP :{0}",Item.HP);
                    Console.WriteLine("MANA :{0}",Item.MANA);
                }
                Console.WriteLine("Price: {0}", Item.Price);
                Console.WriteLine("LevelReq: {0}", Item.LevelReq);
                Console.ReadLine();
             
            }
        }
    }
}
