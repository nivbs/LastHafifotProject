using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class StoreID
    {
        public char StoreType { get; set; }
        public char OpeningDays { get; set; }
        public int StoreIdNumbers { get; set; }

        public StoreID(char storeType, char openingDays, int storeIdNumbers)
        {
            StoreType = storeType;
            OpeningDays = openingDays;
            StoreIdNumbers = storeIdNumbers;
        }

        public StoreID()
        {
        }
    }
}
