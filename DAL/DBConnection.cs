using MySql.Data.MySqlClient;
using Core.Configurations;

namespace DAL
{
    public static class DBConnection
    {
        public static MySqlConnection MySqlConnection = new MySqlConnection($"Server={Configurations.DBServer};Database={Configurations.Database}" +
            $";Uid={Configurations.DBUserName};Pwd={Configurations.DBPassword}");
    }
}
