using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LabBook.Commons
{
    public static class CommonFunction
    {
        public static void WriteWindowsData(this List<double> list, string fileName)
        {
            string target = @"\Dane";
            string path = Directory.GetCurrentDirectory() + target;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = string.Concat(path, @"\", fileName, ".xml");
            File.Delete(path);

            var serializer = new XmlSerializer(typeof(List<double>));
            using (var stream = File.OpenWrite(path))
            {
                serializer.Serialize(stream, list);
                stream.Flush();
            }
        }

        public static List<double> LoadWindowsData(string fileName)
        {
            List<double> windowsData = new List<double>();
            var serializer = new XmlSerializer(typeof(List<double>));

            string path = Directory.GetCurrentDirectory();
            path = string.Concat(path, @"\Dane\", fileName, ".xml");
            if (!File.Exists(path))
                return windowsData;

            using (var stream = File.OpenRead(path))
            {
                try
                {
                    var list = (List<double>)(serializer.Deserialize(stream));
                    windowsData.Clear();
                    windowsData.AddRange(list);
                    stream.Close();
                }
                catch
                {
                    windowsData = new List<double>();
                }
            }

            return windowsData;
        }

        public static double? DBNullToDoubleConv(object number)
        {
            return number.Equals(DBNull.Value) ? null : (double?)Convert.ToDouble(number);
        }

        public static string DBNullToStringConv(object text)
        {
            return text.Equals(DBNull.Value) ? null : text.ToString();
        }

        public static object NullToDBNullConv(double? input)
        {
            return input == null ? DBNull.Value : (object)input;
        }

    }
}
