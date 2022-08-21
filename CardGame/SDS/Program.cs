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
            CursorVisible = false;
            Random rand = new Random();

            Map FirstMap = new Map();
            FirstMap.DisplayMap();
            //게임의 진행을 위한 맵생성 후 화면에 표시

            Character MainCharcter = new Character();
            MainCharcter.init(40, 3, 0, 0);
            //메인캐릭터 생성

            Character Enemy = new Character();
            Enemy.init(rand.Next(20) + 20, 0, rand.Next(5) + 3, 0);
            //적캐릭터 생성

            MainCharcter.DisplayCharacter();
            Enemy.DisplayEnemy();
            //나타내기

            //기본적인 카드를 생성
            List<Card> Cards = new List<Card>() { new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), };
            for (int i = 0; i < 10; i++)
            {
                Cards[i].init("공격", 1, 5, 0, 0);
                Cards.Add(Cards[i]);
            }
            for (int i = 0; i < 5; i++)
            {
                int x = rand.Next(10);
                Cards[x].init("방어", 2, 0, 0, 5);
                Cards.Add(Cards[x]);
            }


            //생성한 카드중 5개의 카드를 화면에 랜덤하게 나타냄
            for (int i = 0; i < 5; i++)
            {
                Cards[i].DisplayCard(i * 14 + 6, 20, i);
            }

            SelectKey(Cards[1], Enemy);

            SetCursorPosition(0, 0);

            ReadKey();
        }


        //메서드
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //커서생성(미완성)
        static void MovingCursor(int x, int y, int xrange, int yrange, int move, int direction)
        {
            SetCursorPosition(x, y);
            Write(">");
            ConsoleKeyInfo key;
            while (true)
            {
                key = ReadKey(true);
                if (direction == 0)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            SetCursorPosition(x, y);
                            Write(" ");
                            SetCursorPosition(x, y - move);
                            Write(">");
                            y -= move;
                            break;

                        case ConsoleKey.DownArrow:
                            SetCursorPosition(x, y);
                            Write(" ");
                            SetCursorPosition(x, y + move);
                            Write(">");
                            y += move;
                            break;

                        case ConsoleKey.Enter:
                            break;
                    }
                }
                else if (direction == 1)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            while (x > x - xrange)
                            {
                                SetCursorPosition(x, y);
                                Write(" ");
                                SetCursorPosition(x - move, y);
                                Write(">");
                                break;
                                x -= move;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            while (x < x + xrange)
                            {
                                SetCursorPosition(x, y);
                                Write(" ");
                                SetCursorPosition(x + move, y);
                                Write(">");
                                x += move;
                                break;
                            }
                            break;

                        case ConsoleKey.Enter:
                            break;
                    }
                }

            }
        }

        static void SelectKey(Card A, Character b)
        {
            ConsoleKeyInfo key;
            while (true)
            {
                key = ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:

                        A.Do(A);
                        break;

                    case ConsoleKey.D2:
                        A.Do(A);
                        break;

                    case ConsoleKey.D3:
                        A.Do(A);
                        break;

                    case ConsoleKey.D4:
                        A.Do(A);
                        break;

                    case ConsoleKey.D5:
                        A.Do(A);
                        break;

                    default:
                        break;
                }
            }

        }

    }
}

//클래스
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class Character//캐릭터의 클래스 생성
{
    public int Hp;
    public int Mana;
    public int Power;
    public int Defence;

    public void init(int hp, int mana, int power, int defence)
    {
        Hp = hp;
        Mana = mana;
        Power = power;
        Defence = defence;
    }
    public void Attacked(int Damage)
    {
        this.Hp = this.Hp - Damage;
    }
    public void DisplayCharacter()
    {
        SetCursorPosition(2, 1);
        Write($"Mana:{Mana}");
        SetCursorPosition(14, 7);
        Write("MainCharacter");
        SetCursorPosition(8, 15);
        Write($"HP:{Hp} Power:{Power} Defence:{Defence}");
    }
    public void DisplayEnemy()
    {
        SetCursorPosition(55, 7);
        Write("Enemy");
        SetCursorPosition(50, 15);
        Write($"HP:{Hp} Damage:{Power}");
    }
}

public class Card : Character//카드의 효과들은 캐릭터가 받으므로 카드에 캐릭터를 상속
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
    public void DefenceUP()
    {
        Defence += inDefence;

    }

    public void Attack(Character A)
    {
        A.Attacked(this.Damage + this.Power - A.Defence);
    }

    public void Do(Character A)
    {
        if (this.Name == "공격")
        {
            Attack(A);
        }
        else if (this.Name == "방어")
        {
            DefenceUP();
        }
    }

    public void DisplayCard(int x, int y, int i)//카드의 모양 표시
    {
        SetCursorPosition(x, y);
        WriteLine(" ---------- ");
        SetCursorPosition(x, y + 1);
        WriteLine($"|        {Cost} |");
        SetCursorPosition(x, y + 2);
        WriteLine("|          |");
        SetCursorPosition(x, y + 3);
        WriteLine($"|   {Name}   |");
        SetCursorPosition(x, y + 4);
        WriteLine("|          |");
        SetCursorPosition(x, y + 5);
        WriteLine("|          |");
        SetCursorPosition(x, y + 6);
        WriteLine($"|A:{Damage}    D:{inDefence}|");
        SetCursorPosition(x, y + 7);
        WriteLine(" ----------");
        SetCursorPosition(x, y + 8);
        WriteLine($"     [{i + 1}]     ");
    }
}

public class Map //맵
{
    public char[] map = new char[5] { '♥', '●', '♨', '♠', '★' };

    public void DisplayMap()
    {
        //랜덤한 수를 넣어서 맵을 랜덤하게 생성해야함
        Random rand = new Random();
        int x = rand.Next(2) + 1;

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


