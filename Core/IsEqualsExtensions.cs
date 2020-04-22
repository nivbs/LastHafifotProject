using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class IsEqualsExtensions
    {
        public static bool IsEquals(this string value, string otherValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            return value == otherValue;
        }

        public static bool IsEquals(this DateTime dateTime, DateTime otherDateTime)
        {
            if (dateTime == null)
            {
                return true;
            }

            return dateTime == otherDateTime;
        }

        public static bool IsEquals(this float number, float otherNumber)
        {
            if (number == 0)
            {
                return true;
            }

            return number == otherNumber;
        }

        public static bool IsEquals(this int number, int otherNumber)
        {
            if (number == 0)
            {
                return true;
            }

            return number == otherNumber;
        }
    }
}
