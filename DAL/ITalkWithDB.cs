using System;
using System.Collections.Generic;
using Core;

namespace DAL
{
    public interface ITalkWithDB
    {
        IEnumerable<ExpandPurchase> GetPurchasesByCondition(string condition);
        IEnumerable<ExpandPurchase> GetFirstPurchasesByLimit(int count = 1000);
    }
}
