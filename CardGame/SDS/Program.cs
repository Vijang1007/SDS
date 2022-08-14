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
            FirstMap.CreateMap();

            Character MainCharcter = new Character();
            MainCharcter.init(40, 3);

            List<Card> Cards = new List<Card>() { new Card(),};
            for (int i = 0; i < 7; i++)
            {
                //Cards[i] = new Card();
                Cards[i].init(1, 5, 0, 0);
                Cards.Add(Cards[i]);   
            } 
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
        public int Cost;
        public int Damage;
        public int inPower;
        public int inDefence;

        public void init(int cost, int damage, int powerup, int defenceup)
        {
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
    }

    public class Map
    {
        public char[] map = new char[5] { '♥', '●', '♨', '♠', '★' };

        public void CreateMap()
        {
            Write($@"
        지도


         {map[0]}
       ↙  ↘
     {map[1]}      {map[1]}
   ↙  ↘      ↘
 {map[1]}      {map[3]}      {map[3]}
   ↘    ↓    ↙
     ↘  ↓  ↙
       ↘↓↙
         {map[2]}
       ↙  ↘
     {map[1]}      {map[3]}
     ↓        ↘
     {map[1]}          {map[1]}
   ↙  ↘        ↓
 {map[1]}      {map[3]}      {map[2]}
   ↘    ↓      ↓
     ↘  ↓      ↓
       ↘↓      {map[1]}
         {map[2]}    ↙
         ↓  ↙
         ↓↙
         {map[4]}");
        }
    }
}
