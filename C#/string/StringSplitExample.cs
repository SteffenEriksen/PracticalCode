

var str = "some-test-string";

var split = str.Split(new[] { "test" }, StringSplitOptions.None);

foreach(var item in split)
{
    Console.WriteLine(item);
}

//Should print:
// "some-"
// "-string"
