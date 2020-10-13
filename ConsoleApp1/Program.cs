using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ItemWeapon itemWeapon = new ItemWeapon();
            itemWeapon.GetInfo();
            ItemArmor itemArmor = new ItemArmor();
            itemArmor.GetInfo();
        }
    }

    class Item
    {
        private protected static Random Rnd = new Random();
        private protected ItemRare Rare;
        private protected int Cost;
        private protected int MinLvl;
        private protected string Name;
        private protected int Str;
        private protected int Agl;
        private protected int Intl;

        protected Item()
        {
            Rare = IGenRare.GenRare();
            SetType();
            Cost = Rnd.Next(100, 200);
            MinLvl = Rnd.Next(1, 30);
            Name = NameGenerator();
            SetAttr();
        }
        protected virtual void SetType()
        {
        }

        protected virtual void SetAttr()
        {
        }

        protected virtual string NameGenerator()
        {
            return "";
        }
    }

    class ItemArmor : Item
    {
        private ItemArmorType _type;
        private int _rndType = Rnd.Next(1, Enum.GetNames(typeof(ItemArmorType)).Length);

        protected override void SetType()
        {
            switch (_rndType)
            {
                case 1:
                    _type = ItemArmorType.Boots;
                    break;
                case 2:
                    _type = ItemArmorType.Chest;
                    break;
                case 3:
                    _type = ItemArmorType.Gloves;
                    break;
                case 4:
                    _type = ItemArmorType.Helmet;
                    break;
                case 5:
                    _type = ItemArmorType.Legs;
                    break;
                default:
                    _type = ItemArmorType.Shoulder;
                    break;
            }
        }
        
        public void GetInfo()
        {
            Console.WriteLine(
                $"Cost: {Cost} \nName: {Name} \nMin level: {MinLvl} \nType: {_type}\n Str: +{Str}; Agl: +{Agl}; Int: +{Intl}");
        }
    }

    class ItemWeapon : Item
    {
        private ItemWeaponType _type;
        private int _rndType = Rnd.Next(1, Enum.GetNames(typeof(ItemWeaponType)).Length);
        
        protected override string NameGenerator()
        {
            string[] arr = new String[] {"of Hunters", "of Gods", "of Gangs"};
            return $"{Rare} {_type} {arr[Rnd.Next(0, arr.Length)]} ";
        }

        protected override void SetAttr()
        {
            if (MinLvl >= 1 && MinLvl < 10)
            {
                Str = Rnd.Next(1, 10);
                Intl = Rnd.Next(1, 10);
                Agl = Rnd.Next(1, 10);
                if (_type == ItemWeaponType.OneHandedSword)
                {
                    Str += Rnd.Next(5, 10);
                }

                if (_type == ItemWeaponType.Bow || _type == ItemWeaponType.Dagger)
                {
                    Agl += Rnd.Next(5, 10);
                }

                if (_type == ItemWeaponType.Staff || _type == ItemWeaponType.Wand)
                {
                    Intl += Rnd.Next(5, 10);
                }
            }

            if (MinLvl >= 10 && MinLvl < 20)
            {
                Str = Rnd.Next(11, 20);
                Intl = Rnd.Next(11, 20);
                Agl = Rnd.Next(11, 20);
                if (_type == ItemWeaponType.OneHandedSword)
                {
                    Str += Rnd.Next(10, 20);
                }

                if (_type == ItemWeaponType.Bow || _type == ItemWeaponType.Dagger)
                {
                    Agl += Rnd.Next(10, 20);
                }

                if (_type == ItemWeaponType.Staff || _type == ItemWeaponType.Wand)
                {
                    Intl += Rnd.Next(10, 20);
                }
            }

            if (MinLvl >= 20 && MinLvl < 30)
            {
                Str = Rnd.Next(21, 30);
                Intl = Rnd.Next(21, 30);
                Agl = Rnd.Next(21, 30);
                if (_type == ItemWeaponType.OneHandedSword || _type == ItemWeaponType.Shield)
                {
                    Str += Rnd.Next(20, 30);
                }

                if (_type == ItemWeaponType.Bow || _type == ItemWeaponType.Dagger)
                {
                    Agl += Rnd.Next(20, 30);
                }

                if (_type == ItemWeaponType.Staff || _type == ItemWeaponType.Wand)
                {
                    Intl += Rnd.Next(20, 30);
                }
            }
        }

        protected override void SetType()
        {
            switch (_rndType)
            {
                case 1:
                    _type = ItemWeaponType.OneHandedSword;
                    break;
                case 2:
                    _type = ItemWeaponType.Bow;
                    break;
                case 3:
                    _type = ItemWeaponType.Dagger;
                    break;
                case 4:
                    _type = ItemWeaponType.Staff;
                    break;
                case 5:
                    _type = ItemWeaponType.Shield;
                    break;
                default:
                    _type = ItemWeaponType.Wand;
                    break;
            }
        }

        public void GetInfo()
        {
            Console.WriteLine(
                $"Cost: {Cost} \nName: {Name} \nMin level: {MinLvl} \nType: {_type}\n Str: +{Str}; Agl: +{Agl}; Int: +{Intl}");
        }
    }

    enum ItemRare
    {
        Common,
        Rare,
        Mythical,
        Legendary
    }

    interface IGenRare
    {
        private static Random Rnd = new Random();
        private static int _rndRare = Rnd.Next(1, Enum.GetNames(typeof(ItemRare)).Length);

        public static ItemRare GenRare()
        {
            switch (_rndRare)
            {
                case 1:
                    return ItemRare.Common;
                case 2:
                    return ItemRare.Rare;
                case 3:
                    return ItemRare.Mythical;
                default:
                    return ItemRare.Legendary;
            }
        }
    }

    interface IGenTypeOfItem
    {
        private static Random Rnd = new Random();
        private static int _rndRare = Rnd.Next(1, Enum.GetNames(typeof(ItemRare)).Length);

        
    }

    interface IGenItemType
    {
        private static Random rnd = new Random();
        private static int _rndType = rnd.Next(1, 4);

        public static ItemType GetType()
        {
            switch (ItemType)
            {
                
            }
        }
    }
    enum ItemWeaponType
    {
        Dagger,
        OneHandedSword,
        TwoHandedSword,
        Bow,
        Staff,
        Wand,
        Shield
    }

    enum ItemArmorType
    {
        Helmet,
        Legs,
        Boots,
        Chest,
        Shoulder,
        Gloves
    }

    enum ItemType
    {
        Armor,
        Weapon,
        Potions,
        Misc
    }
}