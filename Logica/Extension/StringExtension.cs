namespace Logica
{
    public static class StringExtension
    {
        public static bool DateMatchingTheInterval(this string date, string start, string end)
        {
            if (!DateTime.TryParse(date, out DateTime resultData))
                return false;
            
            if (!DateTime.TryParse(start, out DateTime resultStartData))
                return false;
            
            if (!DateTime.TryParse(end, out DateTime resultEndData))
                return false;

            return resultData >= resultStartData && resultData <= resultEndData;
        }
    }
}
