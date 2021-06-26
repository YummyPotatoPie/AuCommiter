using System;

namespace AuCommiter
{
    internal class InputStream
    {
        private readonly string stream;
        public int Position { get; private set; } = 0;

        public InputStream(string stream) => this.stream = stream;

        public static void Croak(string message) => throw new Exception(message);

        public bool Eof() => Position == stream.Length;

        public char Peek() => stream[Position];

        public char Next()
        {
            Position++;
            if (Eof())
            {
                return (char)3;
            }

            return stream[Position];
        }
    }
}
