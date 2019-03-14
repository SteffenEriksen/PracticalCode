
// Example for dictionary
var lookup = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);

// Example for List
var list = new List<string> { "tESt" };
Console.WriteLine(list.Contains("test", StringComparer.InvariantCultureIgnoreCase));

// Example for string
Console.WriteLine("tEst".Equals("test", StringComparison.InvariantCultureIgnoreCase));
