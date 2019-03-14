    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.Text;

    public class SerializeHelper
    {
        public static void Example()
        {
            var car = new Car { Name = "Ferrari", Id = 911 };

            var ser = Serialize(car);
            Console.WriteLine($"serialised: '{ser}'");

            Console.WriteLine();

            var obj = Deserialize<Car>(ser);
            Console.WriteLine($"car name: {obj.Name}'");
        }

        public static string SerializeList<T>(List<T> list) where T : class, new()
        {
            var sb = new StringBuilder();
            foreach (var objectToSerialize in list)
            {
                sb.Append(Environment.NewLine + Serialize(objectToSerialize));
            }
            return sb.ToString();
        }

        private static string Serialize<T>(T objectToSerialize) where T : class, new()
        {
            using (var textWriter = new Utf8StringWriter())
            {
                new XmlSerializer(typeof(T)).Serialize(textWriter, objectToSerialize);
                return textWriter.ToString();
            }
        }
        private static T Deserialize<T>(string xml) where T : class, new()
        {
            using (var reader = new StringReader(xml))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
            }
        }

        public sealed class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }

        public class Car
        {
            public int Id { get; set; }
            public string Color { get; set; }
            public string Name { get; set; }
        }
    }