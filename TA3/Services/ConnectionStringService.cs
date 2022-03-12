namespace TA3.Services
{
    public class ConnectionStringService
    {
        // /!\ You should never hardcode your connection strings or any kind of credentials /!\
        // However that's what we are doing here to keep the exercise simple
        // TODO: Replace those values as explained in the instructions slides
        private const string host = "abul.db.elephantsql.com";
        private const string db = "tuxmcyzl";
        private const string user = "tuxmcyzl";
        private const string passwd = "CnAdBuOJoMyt6W86TTM-B0gidejqd9ey";
        private const string port = "5432";

        public static string GetConnectionString()
        {
            return $"Server={host};Database={db};User Id={user};Password={passwd};Port={port}";
        }
    }
}