using System.ComponentModel;

namespace Domain.Extension
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T val) where T : System.Enum
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static T FromDescriptionString<T>(this string description) where T : System.Enum
        {
            if (description == null)
                throw new ArgumentNullException(nameof(description));

            foreach (T value in System.Enum.GetValues(typeof(T)))
            {
                var field = typeof(T).GetField(value.ToString());
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0 && attributes[0].Description == description)
                    return value;
            }

            throw new ArgumentException($"No enum value with description '{description}' found in {typeof(T).Name}");
        }
    }
}