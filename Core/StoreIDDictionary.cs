using System.Collections.Generic;

namespace Core
{
    public static class StoreIdDictionary
    {
        public static Dictionary<char, string> Types = new Dictionary<char, string>
        {
            { 'A', "Clothes" },
            { 'B', "Food" },
            { 'C', "Materials" },
            { 'D', "Medicine" },
            { 'E', "Electronics" },
            { 'F', "Other" }
        };

        public static Dictionary<char, string> ActivityDays = new Dictionary<char, string>
        {
            { 'A', "All week" },
            { 'B', "Sunday - Friday" },
            { 'C', "Sunday - Thursday" },
            { 'D', "Other" }
        };
    }
}