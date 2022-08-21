using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS
{
    class Program
    {
        static void Main()
        {
            
            Map FirstMap = new Map();
            FirstMap.DisplayMap();

            Character MainCharcter = new Character();
            MainCharcter.init(40, 3);

            List<Card> Cards = new List<Card>() { new Card(),};
            for (int i = 0; i < 5; i++)
            {
                Cards[i].init("공격", 1, 5, 0, 0);
                Cards.Add(Cards[i]);
                Cards[i].DisplayCard(i * 14 + 6, 20, i);
            }

            SetCursorPosition(0, 0);

            ReadKey();
        }
    }

    public class Character
    {
        public int Hp;
        public int Mana;
        public int Power;
        public int Defence;
 
        public void init(int hp, int mana)
        {
            Hp = hp;
            Mana = mana;
        }
        public void Attacked(int Damage)
        {
            this.Hp = this.Hp - Damage;
        }
    }

    public class Card : Character
    {
        public string Name;
        public int Cost;
        public int Damage;
        public int inPower;
        public int inDefence;

        public void init(string name, int cost, int damage, int powerup, int defenceup)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            inPower = powerup;
            inDefence = defenceup;
        }
        public int PowerUP()
        {
            Power += inPower;

            return Power;
        }
        public int DefenceUP()
        {
            Defence += inDefence;

            return Defence;
        }

        public void Attack(Character A)
        {
            A.Attacked(this.Damage + this.Power - A.Defence);
        }

        public void DisplayCard(int x, int y, int i)
        {
            SetCursorPosition(x, y);
            WriteLine(" ---------- ");
            SetCursorPosition(x, y + 1);
            WriteLine($"|        {Cost} |");
            SetCursorPosition(x, y + 2);
            WriteLine("|          |");
            SetCursorPosition(x, y + 3);
            WriteLine("|          |");
            SetCursorPosition(x, y + 4);
            WriteLine("|          |");
            SetCursorPosition(x, y + 5);
            WriteLine("|          |");
            SetCursorPosition(x, y + 6);
            WriteLine("|          |");
            SetCursorPosition(x, y + 7);
            WriteLine(" ----------");
            SetCursorPosition(x, y + 8);
            WriteLine($"     [{i + 1}]     ");
        }
    }

    public class Map
    {
        public char[] map = new char[5] { '♥', '●', '♨', '♠', '★' };

        public void DisplayMap()
        {
            SetCursorPosition(80, 0);
            Write($@"|             지도        
                                                                                |                         ♥ = Me
                                                                                |                         ● = Field
                                                                                |                         ♨ = SafeZone
                                                                                |                         ♠ = SemiBoss
                                                                                |              {map[0]}         ★ = Boss
                                                                                |            ↙  ↘
                                                                                |          {map[1]}      {map[1]}
                                                                                |        ↙  ↘      ↘
                                                                                |      {map[1]}      {map[3]}      {map[3]}
                                                                                |        ↘    ↓    ↙
                                                                                |          ↘  ↓  ↙
                                                                                |            ↘↓↙
                                                                                |              {map[2]}
                                                                                |            ↙  ↘
                                                                                |          {map[1]}      {map[3]}
                                                                                |          ↓        ↘
                                                                                |          {map[1]}          {map[1]}
                                                                                |        ↙  ↘        ↓
                                                                                |      {map[1]}      {map[3]}      {map[2]}
                                                                                |        ↘    ↓      ↓
                                                                                |          ↘  ↓      ↓
                                                                                |            ↘↓      {map[1]}
                                                                                |              {map[2]}    ↙
                                                                                |              ↓  ↙
                                                                                |              ↓↙
                                                                                |              {map[4]}
                                                                                |
                                                                                |
                                                                                |");
        }
    }
}
