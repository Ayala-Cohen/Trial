using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEx
{
    class Player
    {
        string name;
        Queue<Card> cards_of_player;


        //מעטפת למאפיין שם השחקן
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //without using
        //מעטפת למאפיין קלפי השחקן
        public Queue<Card> Cards_of_player
        {
            get
            {
                return cards_of_player;
            }
            set
            {
                cards_of_player = value;
            }
        }

        //בנאי המקבל נתונים ומציבם בשדות
        public Player(string name)
        {
            Name = name;
            cards_of_player = new Queue<Card>();
        }

        //פונקציה להוספת קלפ(ים) לאוסף קלפי השחקן
        public void AddCards(params Card [] c)
        {
            foreach (var item in c)
            {
                cards_of_player.Enqueue(item);
            }
        }

        //without using
        //פונקציה להצגת שם השחקן, מספר קלפיו ושמותיהם
        public override string ToString()
        {
            string str = "";
            foreach (var item in cards_of_player)
            {
                str += item + "\n";
            }
            return $"{name} : cards number: {cards_of_player.Count}\n" + str;
        }

        //פונקציה לבדיקת הפסד השחקן
        public bool CheckLosing()
        {
            return cards_of_player.Count == 0;
        }

        //פונקציה לשליפת הקלף הראשון בערימת קלפי השחקן
        public Card First()
        {
            return cards_of_player.Dequeue();
        }
    }
}
