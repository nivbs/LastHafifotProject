using System;
using System.Linq;
using System.Threading;

namespace Core
{
    public static class GenerateCreditCardNumber
    {
        private static string[] MASTERCARD_PREFIX_LIST = new[] { "51","52", "53", "54", "55" };

        // the default is  mastercard number
        public static string GetDefaultFakeCCNumber()
            => CreateFakeCCNumber(MASTERCARD_PREFIX_LIST[new Random().Next(MASTERCARD_PREFIX_LIST.Length)], 16);

        private static string CreateFakeCCNumber(string prefix, int length)
        {
            string ccnumber = prefix;

            while (ccnumber.Length < (length - 1))
            {
                double rnd = (new Random().NextDouble() * 1.0f - 0f);

                ccnumber += Math.Floor(rnd * 10);

                //sleep so we get a different seed

                Thread.Sleep(2);
            }


            // reverse number and convert to int
            var reversedCCnumberstring = ccnumber.ToCharArray().Reverse();

            var reversedCCnumberList = reversedCCnumberstring.Select(c => Convert.ToInt32(c.ToString()));

            // calculate sum

            int sum = 0;
            int pos = 0;
            int[] reversedCCnumber = reversedCCnumberList.ToArray();

            while (pos < length - 1)
            {
                int odd = reversedCCnumber[pos] * 2;

                if (odd > 9)
                    odd -= 9;

                sum += odd;

                if (pos != (length - 2))
                    sum += reversedCCnumber[pos + 1];

                pos += 2;
            }

            // calculate check digit
            int checkdigit =
                Convert.ToInt32((Math.Floor((decimal)sum / 10) + 1) * 10 - sum) % 10;

            ccnumber += checkdigit;

            return ccnumber;
        }
    }
}
