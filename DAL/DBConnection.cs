using MySql.Data.MySqlClient;
using Core.Configurations;

namespace DAL
{
    public static class DBConnection
    {
        public static MySqlConnection GetMySqlConnection(string server, string dataBase, string dbUserName, string dbPassword)
            => new MySqlConnection($"Server={server};Database={dataBase};Uid={dbUserName};Pwd={dbPassword}");
    }
}
