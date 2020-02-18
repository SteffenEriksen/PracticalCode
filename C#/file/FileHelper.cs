public class FileHelper
{

  public static void SaveToFile<T>(T item, string filename)
  {
    using (FileStream fs = File.Create(filename))
    {
      var ser = JsonConvert.SerializeObject(item);

      WriteEntry(fs, ser);
    }
  }

  public static void SaveToFiles<T>(List<T> items)
  {
    foreach (var item in items)
    {
      using (FileStream fs = new FileStream(item.ToString(), FileMode.Create))
      {
        var ser = JsonConvert.SerializeObject(item);

        WriteEntry(fs, ser);
      }
    }
  }

  public static T ReadFromFile<T>(string fileName)
  {
    using (StreamReader sr = new StreamReader(fileName))
    {
      var text = sr.ReadToEnd();
      return JsonConvert.DeserializeObject<T>(text);
    }
  }

  public static List<Input> ReadCsvFile()
  {
    var result = new List<Input>();
    var lines = File.ReadLines(@"somefile.csv");

    foreach (string line in lines)
    {
      var splittedLine = line.Split(';');

      var firstVal = splittedLine[0];
      var secondVal = splittedLine[1];
      /// etc...

      // Some mapping example
      result.Add(new Input(firstVal, secondVal));
    }

    return result;
  }

  public static DataSet ReadDataSetFromExcel(string filepath)
  {
    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    //open file and returns as Stream
    using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
    {
      using (var reader = ExcelReaderFactory.CreateReader(stream))
      {
        return reader.AsDataSet();
      }
    }
  }

  private static void WriteEntry(FileStream fs, string input)
  {
    byte[] info = new UTF8Encoding(true).GetBytes(input);
    fs.Write(info, 0, info.Length);
  }
}
