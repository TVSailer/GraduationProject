
using System.ComponentModel;
using System.Reflection;

namespace Admin.ViewModels.Lesson
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<T>(this T val) where T : Enum
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        
        public static string[]? ToDescriptionsString<T>(this T val) where T : Type
        {
            return val
               .GetFields()
               .Select(p => p.GetCustomAttribute<DescriptionAttribute>())
               .Where(a => a != null)
               .Select(a => a.Description)
               .ToArray();
        }
    }
}