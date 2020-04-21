using MySql.Data.MySqlClient;

namespace DAL
{
    public static class DBConnection
    {
        public static MySqlConnection MySqlConnection = new MySqlConnection("Server=localhost;Database=hafifot;Uid=root;Pwd=root");
    }
}
