namespace EnumFlagDemo
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetFlags<T>(this T value)
            where T : Enum
        {
            var result = Enum.GetValues(value.GetType())
                             .Cast<T>()
                             .Where(enumItem => value.HasFlag(enumItem));

            return result;
        }
    }
}