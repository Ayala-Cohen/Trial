using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryEx
{
    enum E_color {Red ,Black}
    class Card : IComparable
    {
        E_color color;
        int number;

        //מעטפת למאפיין צבע הקלף
        public E_color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        //מעטפת למאפיין המספר המופיע על הקלף 
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value >= 2 && value <= 14)
                    number = value;
            }
        }

        //מעטפת להחזרת שם הקלף
        public string CardName
        {
            get
            {
                if (number <= 10)
                    return number.ToString() +" " + Color;
                else
                    switch(number)
                    {
                        case 11:
                            return "Jack " + Color;
                        case 12:
                            return "Queen " + Color;
                        case 13:
                            return "King " + Color;
                        case 14:
                            return "Ace " + Color;
                    }
                return null;
            }
        }

        //בנאי המקבל נתונים ומציב אותם בשדות
        public Card(E_color color, int number)
        {
            Color = color;
            Number = number;
        }

        // ToString פונקציה לדריסת ה  
        public override string ToString()
        {
            return CardName;
        }

        //פונקציה להשוואה בין שני קלפים
        public int CompareTo(object obj)
        {
            return number - ((Card)obj).number;
        } 
    }
}
