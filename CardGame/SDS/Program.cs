using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SDS
{
    class Program
    {
        static void Main()
        {
            int turn = 1;

            CursorVisible = false;
            Random rand = new Random();

            Map FirstMap = new Map();
            FirstMap.CreateMap();
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

            //초기 카드를 생성
            List<Card> Cards = new List<Card>() { new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), new Card(), };
            for (int i = 0; i < 5; i++)
            {
                Cards[i].init("공격", 1, 5, 0, 0);
                Cards.Add(Cards[i]);
            }
            for (int i = 5; i < 10; i++)
            {     
                Cards[i].init("방어", 2, 0, 0, 5);
                Cards.Add(Cards[i]);
            }

            //기본적인 세팅 후 게임 시작
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            while (true)
            {
                SetCursorPosition(70, 1);
                Write($"Turn : {turn}");


                //생성한 카드중 5개의 카드를 화면에 랜덤하게 나타냄
                for (int i = 0; i < 5; i++)
                {
                    int x = rand.Next(10);
                    Cards[x].DisplayCard(i * 14 + 6, 20, i);
                }

                //커서를 생성
                MovingCursor(11, 19, 11, 54, 0, 0, 14, true, '▼');

                Thread.Sleep(500);

                turn++;

            }
        }

        //메서드
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static void MovingCursor(int x, int y, int xFirst, int xMax, int yFirst, int yMax, int range, bool direction, char Arrow)//커서생성
        {
            SetCursorPosition(x, y);
            Write($"{Arrow}");
            ConsoleKeyInfo key;
            while (true)
            {
                key = ReadKey(true);
                if (direction == false)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            while (y > yFirst)
                            {
                                SetCursorPosition(x, y);
                                Write("  ");
                                SetCursorPosition(x, y - range);
                                Write($"{Arrow}");
                                y -= range;
                                break;
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            while (y < yMax)
                            {
                                SetCursorPosition(x, y);
                                Write("  ");
                                SetCursorPosition(x, y + range);
                                Write($"{Arrow}");
                                y += range;
                                break;
                            }
                            break;

                        case ConsoleKey.Enter:

                            break;
                    }
                }
                else
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            while (x > xFirst)
                            {
                                SetCursorPosition(x, y);
                                Write("  ");
                                SetCursorPosition(x - range, y);
                                Write($"{Arrow}");
                                x -= range;
                                break;
                            }
                            break;

                        case ConsoleKey.RightArrow:
                            while (x < xMax)
                            {
                                SetCursorPosition(x, y);
                                Write("  ");
                                SetCursorPosition(x + range, y);
                                Write($"{Arrow}");
                                x += range;
                                break;
                            }
                            break;

                        case ConsoleKey.Enter:
                            SetCursorPosition(x, y);
                            Write("  ");
                            if (x == 11)
                            {

                            }
                            else if (x == 25)
                            {

                            }
                            else if (x == 39)
                            {

                            }
                            else if (x == 53)
                            {

                            }
                            else if (x == 67)
                            {

                            }
                            return;
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

                        A.Do(b);
                        break;

                    case ConsoleKey.D2:
                        A.Do(b);
                        break;

                    case ConsoleKey.D3:
                        A.Do(b);
                        break;

                    case ConsoleKey.D4:
                        A.Do(b);
                        break;

                    case ConsoleKey.D5:
                        A.Do(b);
                        break;

                    default:
                        break;
                }
            }

        }

    }
}

//클래스
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        Write($"HP:{Hp} Defence:{Defence} Power:{Power}");
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
    }
}

public class Map //맵
{
    public char[] map = new char[6] { '♥', '●', '♠', '♨', '★', '○' };

    public void CreateMap()
    {
        //플레이할때마다 랜덤한 맵을 만들기 위해 랜덤으로 생성
        Random rand = new Random();
        int[] nmap = new int[11];
        for (int i = 0; i < 11; i++)
        {
            nmap[i] = rand.Next(2) + 1;
        }

        //맵을 화면에 표시
        SetCursorPosition(80, 0);
        Write($@"|             지도        
                                                                                |                         ♥ = Me
                                                                                |                         ● = Field
                                                                                |                         ♠ = SemiBoss
                                                                                |                         ♨ = SafeZone
                                                                                |              {map[0]}         ★ = Boss
                                                                                |            ↙  ↘
                                                                                |          {map[nmap[0]]}      {map[nmap[1]]}
                                                                                |        ↙  ↘      ↘
                                                                                |      {map[nmap[2]]}      {map[nmap[3]]}      {map[nmap[4]]}
                                                                                |        ↘    ↓    ↙
                                                                                |          ↘  ↓  ↙
                                                                                |            ↘↓↙
                                                                                |              {map[3]}
                                                                                |            ↙  ↘
                                                                                |          {map[nmap[5]]}      {map[nmap[6]]}
                                                                                |          ↓        ↘
                                                                                |          {map[3]}          {map[nmap[7]]}
                                                                                |        ↙  ↘        ↓
                                                                                |      {map[nmap[8]]}      {map[nmap[9]]}      {map[3]}
                                                                                |        ↘    ↓      ↓
                                                                                |          ↘  ↓      ↓
                                                                                |            ↘↓      {map[nmap[10]]}
                                                                                |              {map[3]}    ↙
                                                                                |              ↓  ↙
                                                                                |              ↓↙
                                                                                |              {map[4]}
                                                                                |
                                                                                |
                                                                                |");
    }
}


