using Npgsql;

namespace Farmacia2.DAO
{
    public static class ConexionBD
    {
        private static string connectionString = "Host=localhost;Port=5432;Database=Farmacia;Username=postgres;Password=12345;";

        public static NpgsqlConnection GetConnection()
        {
            var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}