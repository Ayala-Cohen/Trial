using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEx
{
    class CardStock
    {
        List<Card> l_cards;

        //בנאי לאתחול חבילת הקלפים
        public CardStock()
        {
            bool flag = true;
            E_color color;
            l_cards = new List<Card>();
            for (int i = 0; i < 2; i++)
            {
                if (flag)
                    color = E_color.Red;
                else
                    color = E_color.Black;
                for (int j = 2; j <= 14; j++)
                {
                    AddCard(new Card(color, j));
                }
                flag = !flag;
            }
        }

        //מעטפת להחזרת חבילת הקלפים
        public List<Card> L_cards
        {
            get
            {
                return l_cards;
            }
        }


        //פונקציה לערבוב חבילת הקלפים
        public void Mixing()
        {
            int index_1, index_2;
            Card tmp;
            Random r = new Random();
            List<int> indexes = new List<int>(); 
            while(indexes.Count < 26)
            {
                index_1 = r.Next(0, 26);
                while (indexes.IndexOf(index_1) != -1)
                    index_1 = r.Next(0, 26);
                indexes.Add(index_1);
                tmp = l_cards[index_1];
                index_2 = r.Next(0, 25);
                while(indexes.IndexOf(index_2)!=-1)
                    index_2 = r.Next(0, 25);
                indexes.Add(index_2);
                l_cards[index_1] = l_cards[index_2];
                l_cards[index_2] = tmp;
            }
        }

        //without using
        //פונקציה להצגת רשימת הקלפים לאחר הערבוב
        public override string ToString()
        {
            string str = "";
            foreach (var item in l_cards)
            {
                str += item + "\n";
            }
            return str;
        }

        public void distribute(params Player [] players)
        {
            int cards_to_every_player = l_cards.Count / players.Length;
            foreach (var item in players)
            {
                for (int i = 0; i < cards_to_every_player; i++)
                    item.AddCards(RemoveCard());
            }
        }

        // without using
        // להחזרת קלף על פי שמו indexer
        public Card this[string card_name]
        {
            get
            {
                foreach (var item in l_cards)
                {
                    if (card_name == item.CardName)
                        return item;
                }
                return null;
            }
        }

        //without using
        //פונקציה למיון החבילה
        public void Sorting()
        {
            l_cards.Sort();
        }

        //פונקציה להוספת קלף לחבילה
        public List<Card> AddCard(Card c)
        {
            l_cards.Add(c);
            return l_cards;
        }

        //פונקציה להסרת קלף מהחבילה
        public Card RemoveCard()
        {
            Card card_for_removing = l_cards.First();
            l_cards.Remove(card_for_removing);
            return card_for_removing;
        }
    }
}
