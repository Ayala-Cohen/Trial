using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEx
{
    class Game
    {
        CardStock stock;
        Player p1, p2;

        public Game(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            stock = new CardStock();
            InitGame();
        }

        //without using
        public CardStock Stock
        {
            get
            {
                return stock;
            }
        }

        //without using
        public Player P1
        {
            get
            {
                return p1;
            }
        }
        //without using
        public Player P2
        {
            get
            {
                return p2;
            }
        }

        public void InitGame()
        {
            stock.Mixing();
            stock.distribute(p1, p2);
        }

        public string CheckVictory()
        {
            if (p1.CheckLosing())
                return p2.Name;
            return p1.Name;
        }

        public bool CheckGameOver()
        {
            if (p1.CheckLosing() || p2.CheckLosing())
                return true;
            return false;
        }

        public override string ToString()
        {
            return $"{p1.Name} cards number: {p1.Cards_of_player.Count}\n{p2.Name} cards numbers: {p2.Cards_of_player.Count}";
        }

        public string StepInGame()
        {
            Card c_of_p1, c_of_p2;
            List<Card> cards_of_p1 = new List<Card>();
            List<Card> cards_of_p2 = new List<Card>();
            int times = 0;
            c_of_p1 = p1.First();
            c_of_p2 = p2.First();
            cards_of_p1.Add(c_of_p1);
            cards_of_p2.Add(c_of_p2);
            Console.WriteLine($"{p1.Name}: {c_of_p1}\n{p2.Name}: {c_of_p2}");
            while (!CaseEqualsCards(c_of_p1, c_of_p2,cards_of_p1, cards_of_p2)) //כל עוד לא הוכרז נצחון זמני 
            {
                times += 1;
                c_of_p1 = cards_of_p1[times * 4];
                c_of_p2 = cards_of_p2[times * 4];
                Console.WriteLine("Numbers after war:");
                Console.WriteLine($"{p1.Name}: {c_of_p1}\n{p2.Name}: {c_of_p2}");
            }
            int result_of_comparing = c_of_p1.CompareTo(c_of_p2);
            if (cards_of_p1.Count > 0)
                cards_of_p1.AddRange(cards_of_p2);
            if (result_of_comparing > 0)
            {
                if(cards_of_p1.Count == 0)
                    p1.AddCards(c_of_p1, c_of_p2);
                else
                    p1.AddCards(cards_of_p1.ToArray());
            }
            if (result_of_comparing < 0)
            {
                if(cards_of_p1.Count == 0)
                    p2.AddCards(c_of_p1, c_of_p2);
                else
                    p2.AddCards(cards_of_p1.ToArray());
            }
            return ToString();
        }

        public bool CaseEqualsCards(Card c1, Card c2, List<Card> cards_of_p1,List<Card> cards_of_p2)
        {
            Card tmp;
            if (c1.CompareTo(c2) != 0)
                return true;
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    tmp = p1.First();
                    cards_of_p1.Add(tmp);
                }
                catch
                {
                    cards_of_p1.AddRange(cards_of_p2);
                    p2.AddCards(cards_of_p1.ToArray());
                    return true; //נגמר הסבב
                }
                try
                {
                    tmp = p2.First();
                    cards_of_p2.Add(tmp);
                }
                catch
                {
                    cards_of_p2.AddRange(cards_of_p1);
                    p1.AddCards(cards_of_p2.ToArray());
                    return true;//נגמר הסבב
                }
            }
            return false;//לא נגמר
        }
    }
}
