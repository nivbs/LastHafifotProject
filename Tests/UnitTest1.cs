using System;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
            {
            //{   
            //        MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;Database=hafifot;Uid=root;Pwd=root");
            //        mySqlConnection.Open();
            //        var command = mySqlConnection.CreateCommand();
            //        command.CommandType = System.Data.CommandType.Text;
            //        command.CommandText = "SELECT * FROM hafifot.purchases LIMIT 0, 1000";
            //        MySqlDataReader mySqlDataReader = command.ExecuteReader();
            //    string something = "";
            //        while (mySqlDataReader.Read())
            //        {
            //            for (int i = 0; i < mySqlDataReader.FieldCount; i++)
            //            {
            //                something+=mySqlDataReader.GetValue(i).ToString() + "\n";
            //            }
            //        }
            //        mySqlConnection.Close();

            //        List<ExpandPurchase> purchases = new List<ExpandPurchase>();
            //    MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;Database=hafifot;Uid=root;Pwd=root");
            //    mySqlConnection.Open();
            //        var command = mySqlConnection.CreateCommand();
            //    command.CommandType = System.Data.CommandType.Text;
            //        command.CommandText = "SELECT * FROM hafifot.purchases LIMIT 0, 1000";
            //        MySqlDataReader mySqlDataReader = command.ExecuteReader();
            //        // something = "";
            //        while (mySqlDataReader.Read())
            //        {
            //            purchases.Add(new ExpandPurchase(mySqlDataReader["id"].ToString(), mySqlDataReader["store_type"].ToString(), mySqlDataReader["store_id"].ToString(),
            //                mySqlDataReader["activity_days"].ToString(), mySqlDataReader["credit_card"].ToString(), DateTime.Parse(mySqlDataReader["purchase_date"].ToString()),
            //                DateTime.Parse(mySqlDataReader["insertion_date"].ToString()), float.Parse(mySqlDataReader["total_price"].ToString()), int.Parse(mySqlDataReader["installments"].ToString()),
            //                float.Parse(mySqlDataReader["price_per_installment"].ToString()), (mySqlDataReader["is_valid"].ToString() == "0"), mySqlDataReader["why invalid"].ToString()));
            //        }
            //mySqlConnection.Close();

            PurchaseInQueue purchaseInQueue = new PurchaseInQueue();

}
    }
}
