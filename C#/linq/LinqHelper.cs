
public class LinqHelper
{

    // As a helper method (without Linq)
    public static List<T> Distinct<T>(this List<T> list)
    {
        return (new HashSet<T>(list)).ToList();
    }
}





