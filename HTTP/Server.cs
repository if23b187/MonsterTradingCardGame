using System.Net;
using System.Net.Sockets;

namespace MonsterTradingCardGame.HTTP
{
    internal class HttpServer
    {
        private readonly TcpListener _tcpListener;
        private readonly UserRequestHandler _userRequestHandler;

        public HttpServer(UserRequestHandler userRequestHandler, int port = 10001)
        {
            _userRequestHandler = userRequestHandler;
            _tcpListener = new TcpListener(IPAddress.Loopback, port);
        }

        public void Start()
        {
            _tcpListener.Start();
            Console.WriteLine($"Server running at http://localhost:{((IPEndPoint)_tcpListener.LocalEndpoint).Port}/");
            Console.WriteLine("Waiting for connections...\n");

            while (true)
            {
                using var tcpClient = _tcpListener.AcceptTcpClient();
                using var reader = new StreamReader(tcpClient.GetStream());
                using var writer = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };

                string? requestLine = reader.ReadLine();
                if (string.IsNullOrEmpty(requestLine)) continue;

                Console.WriteLine($"Received request: {requestLine}");
                var httpRequest = new HttpRequest(requestLine, reader);
                var httpResponse = new HttpResponse(writer);

                _userRequestHandler.ProcessRequest(httpRequest, httpResponse);

                Console.WriteLine("Request handled.\n");
            }
        }
    }
}
