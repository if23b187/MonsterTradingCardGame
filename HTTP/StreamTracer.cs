using System.IO;

namespace MonsterTradingCardGame.HTTP
{
    internal class StreamTracer
    {
        private readonly StreamWriter _writer;

        public StreamTracer(StreamWriter writer)
        {
            _writer = writer;
        }

        public void LogLine(string message)
        {
            Console.WriteLine(message);
            _writer.WriteLine(message);
        }

        public void LogEmptyLine()
        {
            Console.WriteLine();
            _writer.WriteLine();
        }
    }
}
