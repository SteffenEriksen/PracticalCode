   public abstract class EnumClassUtils<TClass> where TClass : class
    {
        public static TEnum Parse<TEnum>(string value) where TEnum : struct, TClass
        {
            var status = value.ToLower();

            foreach (var st in Enum.GetValues(typeof(TEnum)))
            {
                if (status.Equals(st.ToString().ToLower()))
                {
                    return (TEnum)st;
                }
            }
            return new TEnum(); //NotFound
        }
    }

    public class EnumUtils : EnumClassUtils<Enum>
    {
    }
    
    
    //Usage 
    // Ignores case when finding enum 
    // Has the first on the list as default if not found in enum
    var carEnum = EnumUtils.Parse<Car>("ferrari");
    
    
    public enum Car
    {
        Undefined,
        Ferrari,
        Porsche,
        BMW,
        Mercedes,
        Fiat
    }
