using System.IO;

namespace MonsterTradingCardGame.HTTP
{
    internal class HttpResponse
    {
        private readonly StreamTracer _logger;

        public HttpResponse(StreamWriter writer)
        {
            _logger = new StreamTracer(writer);
        }

        public void SendResponse(string statusCode, string responseBody)
        {
            _logger.LogLine(statusCode);
            _logger.LogLine("Content-Type: text/html; charset=utf-8");
            _logger.LogEmptyLine();
            _logger.LogLine(responseBody);
        }
    }
}
