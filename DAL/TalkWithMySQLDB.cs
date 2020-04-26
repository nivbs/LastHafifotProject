using Core;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Core.Configurations;

namespace DAL
{
    public class TalkWithMySQLDB : ITalkWithDB
    { 
        public MySqlConnection MySqlConnection { get; set; }

        public TalkWithMySQLDB()
        {
            MySqlConnection = DBConnection.GetMySqlConnection(Configurations.DBServer, Configurations.Database, Configurations.DBUserName, Configurations.DBPassword);
        }

        private MySqlCommand GetCommand(string query)
        {
            var command = MySqlConnection.CreateCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
            
            return command;
        }

        public IEnumerable<ExpandPurchase> GetPurchasesByCondition(string condition)
        {
            try
            {
                List<ExpandPurchase> purchases = new List<ExpandPurchase>();
                MySqlConnection.Open();
                MySqlDataReader mySqlDataReader = GetCommand(Queries.GetPurchasesByCondition(condition)).ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    purchases.Add(mySqlDataReader.GetExpandPurchaseFromRow());
                }
                return purchases;
            }
            finally
            {
                MySqlConnection.Close();
            }
        }

        public IEnumerable<ExpandPurchase> GetFirstPurchasesByLimit(int count = 1000)
        {
            try
            {
                List<ExpandPurchase> purchases = new List<ExpandPurchase>();
                MySqlConnection.Open();
                MySqlDataReader mySqlDataReader = GetCommand(Queries.GetPurchasesByLimit(count)).ExecuteReader();
            while (mySqlDataReader.Read())
            {
                purchases.Add(mySqlDataReader.GetExpandPurchaseFromRow());
            }
            return purchases;
            }
            finally
            {
                MySqlConnection.Close();
            }
        }

        public IEnumerable<ExpandPurchase> GetAllPurchases()
        {
            try
            {
                List<ExpandPurchase> purchases = new List<ExpandPurchase>();
                MySqlConnection.Open();
                MySqlDataReader mySqlDataReader = GetCommand(Queries.GetAllPurchases).ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    purchases.Add(mySqlDataReader.GetExpandPurchaseFromRow());
                }
                return purchases;
            }
            finally
            {
                MySqlConnection.Close();
            }
        }

        public IEnumerable<ExpandPurchase> GetProchasesByPurchaseDetails(PurchaseInQueue purchaseInQueue)
            => GetPurchasesByCondition(Queries.GetPurchaseByPurchaseDetails(purchaseInQueue));
        

        public ExpandPurchase GetLastInsertPurchase()
        {
            try
            {
                MySqlConnection.Open();
                MySqlDataReader mySqlDataReader = GetCommand(Queries.GetAllPurchasesByOrderInsertionDate).ExecuteReader();
                if(mySqlDataReader.Read())
                {
                    return mySqlDataReader.GetExpandPurchaseFromRow();
                }

                return null;
            }
            finally
            {
                MySqlConnection.Close();
            }
        }

        public void CleanDB()
        {
            try
            {
                MySqlConnection.Open();
                GetCommand(Queries.DeleteAllPurchases).ExecuteNonQuery();
            }
            finally
            {
                MySqlConnection.Close();
            }
        }

        public void InsertPurchaseToDB(ExpandPurchase expandPurchase)
        {
            try
            {
                MySqlConnection.Open();
                GetCommand(Queries.InsertPurchase(expandPurchase)).ExecuteNonQuery();
            }
            finally
            {
                MySqlConnection.Close();
            }
        }
    }
}