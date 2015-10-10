using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingRNG
{
    public class Items
    {
        public int ID { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Price { get; set; }
        public int Price1 { get; set; }
        public int Price2 { get; set; }
        public int MANA { get; set; }
        public int LevelReq { get; set; }
        public string Rarity { get; set; }
        public int NumberOfNames { get; set; }
        public string ItemType { get; set; }
        public Random Random;
        public List<string> ItemTypeList = new List<string> {"Weapon", "Armor" };
        public List<string> WeaponList = new List<string> { "Staff", "Sword", "Dagger", "Wand", "Axe", "Mace" };
        public List<string> ArmorList = new List<string> { "Chest area armor", "Shield", "Head area armor", "Leggings", "Shoes", "Gloves", "Belt", "Ring" };
        public string WeaponType { get; set; }
        public string Value { get; set; }
        public List<string> DamageType = new List<string> { "Meele", "Magic" };
        public List<string> WeaponListMeele = new List<string> { "Staff", "Wand" };
        public List<string> WeaponListMagic = new List<string> { "Sword", "Dagger", "Axe", "Mace" };
        public List<string> ValuePoor = new List<string> { "Wooden", "Bronze" };
        public List<string> ValueCommon = new List<string> { "Bronze", "Iron" };
        public List<string> Value2 = new List<string> { "Silver", "Steel", "Iron" };
        public List<string> ValueElite = new List<string> { "Silver", "Steel", "Dragon Glass", "Adamantium", "Titanium", "Arcane" };
        public List<string> ValueLegendary = new List<string> { "Dragon Glass", "Adamantium", "Titanium", "Arcane" };
        public List<string> ArmorValuePoor = new List<string> { "Cloth", "Leather" };
        public List<string> ArmorValueCommon = new List<string> { "Cloth", "Leather", "Iron" };
        public List<string> ArmorValue2 = new List<string> { "Iron", "Silver", "Steel" };
        public List<string> ArmorValueElite = new List<string> { "Silver", "Steel", "Titanium", "Arcane", "Dragon Glass" };
        public List<string> ArmorValueLegendary = new List<string> { "Titanium", "Arcane", "Dragon Glass", "Adamantium" };
        public List<string> Name1 = new List<string> { "Stupid", "Great", "Powerful", "Epic", "Masterfull", "Mighty", "Bountiful", "Foreverlasting", "Pointless", "Useless" };
        public List<string> Name2 = new List<string> { "Things","Learning", "Power", "Proportions", "Torment", "Legs", "Turnament", "Shit", "Crazyness", "Awesomeness" };
        public List<string> NameLenght3List = new List<string> { "Ragnarok","Hitler", "Power", "Bondage", "Noobs", "Great Weakness", "Error", "404", "Torture", "SHIT STATS(No idea since I'm not good enough to programm stats based on names)", "The Dark Lord", "Emperor", "Monkey Kong", "I ran out of words", "Blablabla" };

        public Items(int iD,int droprarity, Random random)
        {
            Random = random;
            ID = iD;
            int dropRarity = droprarity;
            NumberOfNames = NumberOfNamesGenerator(dropRarity);
            Rarity = RarityGenerator(dropRarity);
            ItemType = ItemTypeGenerator();
            if (ItemType == "Weapon")
            {
                WeaponType = DamageType[Random.Next(0, DamageType.Count)];

                if (ItemType == "Meele")
                {
                    ItemType = WeaponListMeele[Random.Next(0, WeaponListMeele.Count)];
                }
                else
                {
                    ItemType = WeaponListMagic[Random.Next(0, WeaponListMagic.Count)];
                }
            }
            if (ItemType == "Armor")
            {
                ItemType = ArmorList[Random.Next(0, ArmorList.Count)];
            }
            if (WeaponList.Contains(ItemType))
            {
                Value = WeaponValueGenerator(dropRarity);
                Damage = WeaponDamage(dropRarity);
            }
            else
            {
                Value = ArmorValueGenerator(dropRarity);
                HP = ArmorHealthGen(dropRarity);
                int RandomChance = Random.Next(0, 100);
                if (RandomChance <= 75)
                {
                    MANA = ArmorManaGen(dropRarity);
                }
            }
            Name = NameGenerator();
            Price1 = PriceGenerator(dropRarity);
            Price2 = PriceGeneratorValue();
            Price = (Price1 + Price2);
            LevelReq = LevelRqGenerator(dropRarity);

        }
        public int LevelRqGenerator(int droprate)
        {
            switch (droprate)
            {
                case 1:
                    LevelReq = Random.Next(1,3);
                    break;
                case 2:
                    LevelReq = Random.Next(4,7);
                    break;
                case 3:
                    LevelReq = Random.Next(8,12);
                    break;
                case 4:
                    LevelReq = Random.Next(12,17);
                    break;
                case 5:
                    LevelReq = Random.Next(18,23);
                    break;
                case 6:
                    LevelReq = Random.Next(24,25);
                    break;
            }
            return LevelReq;
        }
        public int PriceGeneratorValue()
        {
            
            switch (Value)
            {
                case "Wooden":
                    Price2 = 0;
                    break;
                case "Cloth":
                    Price2 = 0;
                    break;
                case "Leather":
                    Price2 = 10;
                    break;
                case "Bronze":
                    Price2 = 10;
                    break;
                case "Iron":
                    Price2 = 30;
                    break;
                case "Steel":
                    Price2 = 70;
                    break;
                case "Silver":
                    Price2 = 115;
                    break;
                case "Adamantium":
                    Price2 = 210;
                    break;
                case "Titanium":
                    Price2 = 350;
                    break;
                case "Arcane":
                    Price2 = 666;
                    break;
                case "Dragon Glass":
                    Price2 = 1500;
                    break;
            }
            return Price2;
        }
        public int PriceGenerator(int droprarity)
        {
            switch (droprarity)
            {
                case 1:
                    Price1 = Random.Next(5, 23);
                    break;
                case 2:
                    Price1 = Random.Next(20, 75);
                    break;
                case 3:
                    Price1 = Random.Next(75, 120);
                    break;
                case 4:
                    Price1 = Random.Next(200, 467);
                    break;
                case 5:
                    Price1 = Random.Next(600, 999);
                    break;
                case 6:
                    Price1 = Random.Next(2000, 10000);
                    break;
            }
            return Price1;
        }
        public string RarityGenerator(int dropRarity)
        {
            switch (dropRarity)
            {
                case 1:
                    Rarity = "Poor";
                    break;
                case 2:
                    Rarity = "Common";
                    break;
                case 3:
                    Rarity = "Uncommon";
                    break;
                case 4:
                    Rarity = "Elite";
                    break;
                case 5:
                    Rarity = "Rare";
                    break;
                case 6:
                    Rarity = "Legendary";
                    break;
            }

            return Rarity;
        }
        public string ItemTypeGenerator()
        {
            return string.Format("{0}", ItemTypeList[Random.Next(0, ItemTypeList.Count)]);
        }
        public int NumberOfNamesGenerator(int dropRarity)
        {
            switch (dropRarity)
            {
                case 1:
                    NumberOfNames = 2;
                    break;
                case 2:
                    NumberOfNames = Random.Next(2, 4);
                    break;
                case 3:
                    NumberOfNames = Random.Next(2, 4);
                    break;
                case 4:
                    NumberOfNames = Random.Next(2, 5);
                    break;
                case 5:
                    NumberOfNames = Random.Next(3, 5);
                    break;
                case 6:
                    NumberOfNames = Random.Next(4, 6);
                    break;
            }
            return NumberOfNames;
        }
        public string NameGenerator()
        {
            int nameNR = NumberOfNames;
            if (nameNR == 2)
            {
                return string.Format("{0} {1} {2}", Rarity, Value, ItemType);
            }
            else if (nameNR == 3)
            {
                return string.Format("{0} {1} {2} of {3}", Rarity, Value, ItemType, NameLenght3List[Random.Next(0, NameLenght3List.Count)]);
            }
            else if (nameNR == 4)
            {
                return string.Format("{0} {1} {2} of {3} {4}", Rarity, Value, ItemType, Name1[Random.Next(0, Name1.Count)], Name2[Random.Next(0, Name2.Count)]);
            }
            else if (nameNR == 5)
            {
                return string.Format("{0} {1} {2} of {3} {4} {5}", Rarity, Value, ItemType, Name1[Random.Next(0, Name1.Count)], Name1[Random.Next(0, Name1.Count)], Name2[Random.Next(0, Name2.Count)]);
            }
            else if (nameNR == 6)
            {
                return string.Format("{0} {1} {2} of {3} {4} {5} {6}", Rarity, Value, ItemType, Name1[Random.Next(0, Name1.Count)], Name1[Random.Next(0, Name1.Count)], Name1[Random.Next(0, Name1.Count)], Name2[Random.Next(0, Name2.Count)]);
            }
            else
            {
                string ErrorSword = "Error Sword/Armor/blablabla";
                return ErrorSword;
            }
        }
        public string WeaponValueGenerator(int droprarity)
        {
            switch (droprarity)
            {
                case 1:
                    Value = ValuePoor[Random.Next(0, ValuePoor.Count)];
                    break;
                case 2:
                    Value = ValueCommon[Random.Next(0, ValueCommon.Count)];
                    break;
                case 3:
                    Value = Value2[Random.Next(0, Value2.Count)];
                    break;
                case 4:
                    Value = ValueElite[Random.Next(0, ValueElite.Count)];
                    break;
                case 5:
                    Value = ValueElite[Random.Next(0, ValueElite.Count)];
                    break;
                case 6:
                    Value = ValueLegendary[Random.Next(0, ValueLegendary.Count)];
                    break;

            }
            return Value;
        }

        public string ArmorValueGenerator(int droprarity)
        {
            switch (droprarity)
            {
                case 1:
                    Value = ArmorValuePoor[Random.Next(0, ArmorValuePoor.Count)];
                    break;
                case 2:
                    Value = ArmorValueCommon[Random.Next(0, ArmorValueCommon.Count)];
                    break;
                case 3:
                    Value = ArmorValue2[Random.Next(0, ArmorValue2.Count)];
                    break;
                case 4:
                    Value = ArmorValueElite[Random.Next(0, ArmorValueElite.Count)];
                    break;
                case 5:
                    Value = ArmorValueElite[Random.Next(0, ArmorValueElite.Count)];
                    break;
                case 6:
                    Value = ArmorValueLegendary[Random.Next(0, ArmorValueLegendary.Count)];
                    break;

            }
            return Value;
        }

        public int WeaponDamage(int droprarity)
        {
            switch (droprarity)
            {
                case 1:
                    Damage = Random.Next(5, 20);
                    break;
                case 2:
                    Damage = Random.Next(25, 45);
                    break;
                case 3:
                    Damage = Random.Next(50, 105);
                    break;
                case 4:
                    Damage = Random.Next(110, 200);
                    break;
                case 5:
                    Damage = Random.Next(210, 500);
                    break;
                case 6:
                    Damage = Random.Next(550, 1200);
                    break;
            }
            return Damage;
        }

        public int ArmorHealthGen(int droprarity)
        {
            switch (droprarity)
            {
                case 1:
                    HP = Random.Next(5, 20);
                    break;
                case 2:
                    HP = Random.Next(25, 45);
                    break;
                case 3:
                    HP = Random.Next(50, 105);
                    break;
                case 4:
                    HP = Random.Next(110, 200);
                    break;
                case 5:
                    HP = Random.Next(210, 500);
                    break;
                case 6:
                    HP = Random.Next(550, 1200);
                    break;
            }
            return HP;
        }

        public int ArmorManaGen(int droprarity)
        {
            switch (droprarity)
            {
                case 1:
                    MANA = Random.Next(5, 20);
                    break;
                case 2:
                    MANA = Random.Next(25, 45);
                    break;
                case 3:
                    MANA = Random.Next(50, 105);
                    break;
                case 4:
                    MANA = Random.Next(110, 200);
                    break;
                case 5:
                    MANA = Random.Next(210, 500);
                    break;
                case 6:
                    MANA = Random.Next(550, 1200);
                    break;
            }
            return MANA;
        }
    }
}
