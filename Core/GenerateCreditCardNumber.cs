using System;
using System.Linq;
using System.Threading;
using CreditCardValidator;

namespace Core
{
    public static class GenerateCreditCardNumber
    {
        public static string GetRandomMasterCardFakeCCNumber()
            => CreditCardFactory.RandomCardNumber(CardIssuer.MasterCard);
    }
}