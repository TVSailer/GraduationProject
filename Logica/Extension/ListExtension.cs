namespace Logica
{
    public static class ListExtension
    {
        public static Action Method { get; set; }

        public static T SearchByParameter<T>(this List<T> list, string attribute) where T : Control
            => list.FirstOrDefault(x => x.Text == attribute);

    }
}
