public class FileHelper
    {

        public static void SaveToFile<T>(T item, string filename)
        {
            using (FileStream fs = File.Create($"{filename}.txt"))
            {
                var ser = JsonConvert.SerializeObject(item);

                byte[] info = new UTF8Encoding(true).GetBytes(ser);
                fs.Write(info, 0, info.Length);
            }
        }

        public static void SaveToFiles<T>(List<T> items)
        {
            foreach(var item in items)
            {
                using (FileStream fs = new FileStream($"{item.ToString()}.txt", FileMode.Create))
                {
                    var ser = JsonConvert.SerializeObject(item);

                    byte[] info = new UTF8Encoding(true).GetBytes(ser);
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        public static T ReadFromFile<T>(string fileName)
        {
            using (StreamReader sr = new StreamReader($"{fileName}.txt"))
            {
                var text = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(text);
            }
        }
    }
