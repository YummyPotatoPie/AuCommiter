using System.Collections.Generic;
using System.Text;

namespace AuCommiter
{
    internal static class ArgsParser
    {
        public static Dictionary<string, string> Parse(string argsStream)
        {
            InputStream stream = new(argsStream);
            Dictionary<string, string> options = new();

            Dictionary<string, string> option;
            while ((option = ReadNext(ref stream)) != null)
            {
                foreach (string key in option.Keys)
                {
                    options.Add(key, option[key]);
                }
            }

            return options;
        }

        private static Dictionary<string, string> ReadNext(ref InputStream stream)
        {
            if (stream.Eof())
            {
                return null;
            }
            else if (stream.Peek() == '-')
            {
                stream.Next();
                string key = ReadKey(ref stream);
                string value = "";
                if (!stream.Eof() && stream.Peek() == '=')
                {
                    stream.Next();
                    value = ReadValue(ref stream);
                }
                else
                {
                    InputStream.Croak("Argument error at position: " + (stream.Position + 1));
                }

                Dictionary<string, string> option = new();
                option.Add(key, value);
                return option;
            }
            else if (char.IsWhiteSpace(stream.Peek()))
            {
                SkipWhiteSpace(ref stream);
                ReadNext(ref stream);
            }
            else
            {
                InputStream.Croak("Argument error at position: " + (stream.Position + 1));
            }
            return null;
        }

        private static void SkipWhiteSpace(ref InputStream stream)
        {
            while (!stream.Eof() && char.IsWhiteSpace(stream.Peek()))
            {
                stream.Next();
            }
        }

        private static string ReadKey(ref InputStream stream)
        {
            StringBuilder key = new();
            while (!stream.Eof() && stream.Peek() != '=' && !char.IsWhiteSpace(stream.Peek()))
            {
                key.Append(stream.Peek());
                stream.Next();
            }
            return key.ToString();
        }

        private static string ReadValue(ref InputStream stream)
        {
            StringBuilder value = new();
            while (!stream.Eof() && stream.Peek() != '-' && !char.IsWhiteSpace(stream.Peek()))
            {
                value.Append(stream.Peek());
                stream.Next();
            }
            return value.ToString();
        }
    }
}
