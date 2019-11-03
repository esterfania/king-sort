using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingSort.Domain
{
    public class King
    {
        public string Name { get; set; }
        public string OrdinalNumber { get; set; }
        public int Number { get; set; }

        public King(string name, string ordinalNumber)
        {
            SetName(name);
            this.OrdinalNumber = ordinalNumber;
            SetNumber(ordinalNumber);
        }

        public King()
        {

        }
        
        public void SetName(string name)
        {
         
            var firstName = name.Split(" ")[0];

            if (!(firstName.Length > 1 && firstName.Length < 20))
            {
                throw new Exception("Name of a king will be a string containing between 1 and 20 characters " + firstName);
            }
            if (!(firstName.Substring(0,1) == firstName.Substring(0, 1).ToUpper()))
            {
                throw new Exception("Actual name will start by an uppercase letter " + firstName);
            }

            if (!(firstName.Substring(1, firstName.Length-1) == firstName.Substring(1, firstName.Length-1).ToLower()))
            {
                throw new Exception("Other character in each actual name will be a lowercase letter " + firstName);
            }
            this.Name = name;
        }

        public void SetNumber(string ordinalNumber)
        {
            var number = RomanToInteger(ordinalNumber);
            if (number > 50)
            {
                throw new Exception("Roman numeral will be representing a number between 1 and 50");
            }
            this.Number = number;
        }

        public string[] GetSortedList(string[] kings)
        {
            var kingsList = new List<King>();

            if (!(kings.Length > 1 && kings.Length < 50))
            {
                throw new Exception("Kings will contain between 1 and 50 elements");
            }

            foreach (var king in kings)
            {
                var obj = new King(king.Split(" ")[0], king.Split(" ")[1]);

                King item = ConvertToNumber(obj);

                kingsList.Add(obj);
            }

            var response = new List<string>();

            var ordenedList = kingsList.OrderBy(x => x.Name).ThenBy(x => x.Number);

            foreach (var item in ordenedList)
            {
                var itemString = item.Name + " " + item.OrdinalNumber;

                response.Add(itemString);
            };

            return response.ToArray();
        }

        private static King ConvertToNumber(King king)
        {

            king.Number = RomanToInteger(king.OrdinalNumber);


            return king;
        }
        private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        public static int RomanToInteger(string roman)
        {
            int number = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    number -= RomanMap[roman[i]];
                }
                else
                {
                    number += RomanMap[roman[i]];
                }
            }
            return number;
        }

    }
}
