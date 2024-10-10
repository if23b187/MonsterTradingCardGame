using MonsterTradingCardGame.HTTP;

namespace MonsterTradingCardGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userDatabase = new Dictionary<string, User>();

            var userRequestHandler = new UserRequestHandler(userDatabase);
            var httpServer = new HttpServer(userRequestHandler);

            httpServer.Start();
        }
    }
}
