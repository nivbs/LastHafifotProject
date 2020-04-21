using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Core;

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
    }
}
