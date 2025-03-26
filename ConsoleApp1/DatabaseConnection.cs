using MySql.Data.MySqlClient;

static class DatabaseConnection
{
    public static MySqlConnection GetDatabaseConnection()
    {
        return new MySqlConnection(
            "Server=127.0.0.1;Port=3306;user=user;password=mark;" +
            "database=loanrecords;Allow User Variables=true;");
    }
}