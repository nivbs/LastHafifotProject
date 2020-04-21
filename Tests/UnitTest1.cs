using System;
using System.Diagnostics;
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
                MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;Database=hafifot;Uid=root;Pwd=root");
                mySqlConnection.Open();
                var command = mySqlConnection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM hafifot.purchases LIMIT 0, 1000";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
            string something = "";
                while (mySqlDataReader.Read())
                {
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        something+=mySqlDataReader.GetValue(i).ToString() + "\n";
                    }
                }
                mySqlConnection.Close();
           
        }
    }
}
