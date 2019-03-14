
using System;
using System.IO;
using System.Xml.Serialization;

public class SerializeHelper
{
	public static void Example()
	{
		var car = new Car { Name = "Ferrari", Id = 911 };

        var ser = SerializeEventMessageContent(car);
        Console.WriteLine($"serialised: '{ser}'");

        Console.WriteLine();

        var obj = DeserializeEventMessageContent<Car>(ser);
        Console.WriteLine($"car name: {obj.Name}'");
	}

    private static string SerializeEventMessageContent<T>(T objectToSerialize) where T : class, new()
    {
        using (StringWriter textWriter = new StringWriter())
        {
            new XmlSerializer(typeof(T), "input text to match serialised content").Serialize(textWriter, objectToSerialize);
            return textWriter.ToString();
        }
    }
    private static T DeserializeEventMessageContent<T>(string xml) where T : class, new()
    {
        using (TextReader reader = new StringReader(xml))
        {
            return (T)new XmlSerializer(typeof(T), "input text to match serialised content").Deserialize(reader);
        }
    }


	public class Car
	{
		public int Id { get; set; }
		public string Color { get; set; }
		public string Name { get; set; }
	}
}
