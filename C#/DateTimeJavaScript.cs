    public static class DateTimeJavaScript
    {
        private static readonly long DatetimeMinTimeTicks =
            (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks;

        public static long ToJavaScriptMilliseconds(this DateTime dt)
        {
            return (long)((dt.ToUniversalTime().Ticks - DatetimeMinTimeTicks) / 10000);
        }

        public static long ToDateTimeMilliseconds(long javascriptTicks)
        {
            return (10000 * javascriptTicks) + DatetimeMinTimeTicks;
        }
                
        public static DateTime ToDateTime(long javascriptTicks)
        {
            return new DateTime(ToDateTimeMilliseconds(javascriptTicks));
        }
    }
