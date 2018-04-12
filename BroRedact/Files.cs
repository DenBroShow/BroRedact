using System.IO;
using System.Text;

namespace BroRedact
{
    class Files
    {
        private static string file;
        private static string filestring;
        private static string newstring;
        private static int symbolstotal;
        public static void LoadFile(string path)
        {
            file = path;
            filestring = File.ReadAllText(path, Encoding.GetEncoding(1251));
            newstring = filestring;
        }

        public static string GetFileName()
        {
            return file;
        }

        public static string GetFileContent()
        {
            return filestring;
        }

        public static void NewString(string str)
        {
            newstring = str;
            symbolstotal = newstring.Length;
        }

        public static bool AreEqual()
        {
            return filestring != newstring;
        }

        public static void Save()
        {
            File.WriteAllText(file, newstring, Encoding.GetEncoding(1251));
        }

        public static int GetSymbols()
        {
            return symbolstotal;
        }
    }
}
