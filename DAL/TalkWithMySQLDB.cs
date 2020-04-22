using Core;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class TalkWithMySQLDB : ITalkWithDB
    { 
        public IEnumerable<ExpandPurchase> GetPurchasesByCondition(string condition)
        {
            try
            {
                List<ExpandPurchase> purchases = new List<ExpandPurchase>();
                DBConnection.MySqlConnection.Open();
                var command = DBConnection.MySqlConnection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM hafifot.purchases WHERE {condition}";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    purchases.Add(mySqlDataReader.GetExpandPurchaseFromRow());
                }
                return purchases;
            }
            finally
            {
                DBConnection.MySqlConnection.Close();
            }
        }

        public IEnumerable<ExpandPurchase> GetFirstPurchasesByLimit(int count = 1000)
        {
            try
            {
                List<ExpandPurchase> purchases = new List<ExpandPurchase>();
                DBConnection.MySqlConnection.Open();
                var command = DBConnection.MySqlConnection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM hafifot.purchases LIMIT 0,{count}";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                purchases.Add(mySqlDataReader.GetExpandPurchaseFromRow());
            }
            return purchases;
            }
            finally
            {
                DBConnection.MySqlConnection.Close();
            }
        }

        public IEnumerable<ExpandPurchase> GetAllPurchases()
        {
            try
            {
                List<ExpandPurchase> purchases = new List<ExpandPurchase>();
                DBConnection.MySqlConnection.Open();
                var command = DBConnection.MySqlConnection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM hafifot.purchases";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    purchases.Add(mySqlDataReader.GetExpandPurchaseFromRow());
                }
                return purchases;
            }
            finally
            {
                DBConnection.MySqlConnection.Close();
            }
        }

        public IEnumerable<ExpandPurchase> GetProchasesByPurchaseDetails(PurchaseInQueue purchaseInQueue)
        {
            string whereQuery = "";
            bool isNeedAnd = false;
            if(!string.IsNullOrEmpty(purchaseInQueue.CreditCardNumber))
            {
                whereQuery += $"credit_card = '{purchaseInQueue.CreditCardNumber}'";
                isNeedAnd = true;
            }
            if(!string.IsNullOrEmpty(purchaseInQueue.Installments))
            {
                if (isNeedAnd)
                {
                    whereQuery += " AND ";
                }
                
                if (purchaseInQueue.Installments == "FULL")
                {
                    whereQuery += "installments = 1";
                }
                else
                {
                    whereQuery += $"installments = {purchaseInQueue.Installments}";
                }
                isNeedAnd = true;
            }
            if (purchaseInQueue.TotalPrice != 0)
            {
                if (isNeedAnd)
                {
                    whereQuery += " AND ";
                }

                whereQuery += $"total_price = '{purchaseInQueue.TotalPrice}'";
                isNeedAnd = true;
            }
            if(purchaseInQueue.PurchaseDate != null)
            {
                if(isNeedAnd)
                {
                    whereQuery += " AND ";
                }

                whereQuery += $"purchase_date = '{purchaseInQueue.PurchaseDate.ToString("yyy-MM-dd")}'";
                isNeedAnd = true;
            }
            if(!char.IsWhiteSpace(purchaseInQueue.StoreID.ActivityDays))
            {
                if(isNeedAnd)
                {
                    whereQuery += " AND ";
                }

                whereQuery += $"activity_days = '{StoreIdDictionary.ActivityDays[purchaseInQueue.StoreID.ActivityDays]}'";
                isNeedAnd = true;
            }
            if (!char.IsWhiteSpace(purchaseInQueue.StoreID.StoreType))
            {
                if (isNeedAnd)
                {
                    whereQuery += " AND ";
                }

                whereQuery += $"store_type = '{StoreIdDictionary.Types[purchaseInQueue.StoreID.StoreType]}'";
                isNeedAnd = true;
            }
            if (purchaseInQueue.StoreID.StoreIdNumbers != 0)
            {
                if (isNeedAnd)
                {
                    whereQuery += " AND ";
                }

                whereQuery += $"store_id = '{purchaseInQueue.StoreID.StoreIdNumbers}'";
            }

            return GetPurchasesByCondition(whereQuery);
        }

        public ExpandPurchase GetLastInsertPurchase()
        {
            try
            {
                DBConnection.MySqlConnection.Open();
                var command = DBConnection.MySqlConnection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM hafifot.purchases ORDER BY insertion_date DESC";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                if(mySqlDataReader.Read())
                {
                    return mySqlDataReader.GetExpandPurchaseFromRow();
                }

                return null;
            }
            finally
            {
                DBConnection.MySqlConnection.Close();
            }
        }

        public void CleanDB()
        {
            try
            {
                DBConnection.MySqlConnection.Open();
                var command = DBConnection.MySqlConnection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"DELETE FROM hafifot.purchases";
                command.ExecuteNonQuery();
            }
            finally
            {
                DBConnection.MySqlConnection.Close();
            }
        }

        public void InsertPurchaseToDB(ExpandPurchase expandPurchase)
        {
            try
            {
                DBConnection.MySqlConnection.Open();
                var command = DBConnection.MySqlConnection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                string isValid;
                if(expandPurchase.IsValid)
                {
                    isValid = "1";
                }
                else
                {
                    isValid = "0";
                }
                command.CommandText = $"INSERT hafifot.purchases VALUES('{expandPurchase.PurchaseId}', '{expandPurchase.StoreType}', '{expandPurchase.StoreId}', '{expandPurchase.ActivityDays}'" +
                    $", '{expandPurchase.CreditCard}', '{expandPurchase.PurchaseDate.ToString("yyy-MM-dd")}', '{expandPurchase.InsertionDate.ToString("yyy-MM-dd")}', {expandPurchase.TotalPrice}," +
                    $"{expandPurchase.Installments}, {expandPurchase.PricePerInstallments}, {isValid}, {expandPurchase.WhyInvalid})";
                command.ExecuteNonQuery();
            }
            finally
            {
                DBConnection.MySqlConnection.Close();
            }
        }
    }
}