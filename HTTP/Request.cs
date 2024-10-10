using System.IO;

namespace MonsterTradingCardGame.HTTP
{
    internal class HttpRequest
    {
        public string HttpMethod { get; }
        public string UrlPath { get; }
        public int BodyContentLength { get; }
        public string BodyContent { get; } = string.Empty;

        public HttpRequest(string requestLine, StreamReader reader)
        {
            var requestParts = requestLine.Split(' ');
            HttpMethod = requestParts[0];
            UrlPath = requestParts[1];

            BodyContentLength = ExtractContentLength(reader);
            BodyContent = ReadBodyContent(reader, BodyContentLength);
        }

        private int ExtractContentLength(StreamReader reader)
        {
            string? headerLine;
            int contentLength = 0;

            while (!string.IsNullOrEmpty((headerLine = reader.ReadLine())))
            {
                var headerParts = headerLine.Split(':');
                if (headerParts.Length == 2 && headerParts[0].Trim().Equals("Content-Length", StringComparison.OrdinalIgnoreCase))
                {
                    contentLength = int.Parse(headerParts[1].Trim());
                }
            }

            return contentLength;
        }

        private string ReadBodyContent(StreamReader reader, int contentLength)
        {
            if (contentLength <= 0) return string.Empty;

            char[] bodyBuffer = new char[contentLength];
            reader.Read(bodyBuffer, 0, contentLength);
            return new string(bodyBuffer);
        }
    }
}
