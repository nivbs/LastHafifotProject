using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class Class1
    {
    public void bla()
    {
        MySqlConnection mySqlConnection = new MySqlConnection("Server=localhost;Database=hafifot;Uid=root;Pwd=root");
        mySqlConnection.Open();
        var command = mySqlConnection.CreateCommand();
        command.CommandType = System.Data.CommandType.Text;
        command.CommandText = "SELECT * FROM hafifot.purchases LIMIT 0, 1000";
        MySqlDataReader mySqlDataReader = command.ExecuteReader();
        while(mySqlDataReader.Read())
        {
            for (int i = 0; i < mySqlDataReader.FieldCount; i++)
            {
                Debug.WriteLine(mySqlDataReader.GetValue(i).ToString());
            }
        }
        mySqlConnection.Close();
    }
    }
}
