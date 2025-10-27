namespace Logica.Extension
{
    public static class ControlExtension
    {
        public static T Do<T>(this T control, Action<T> action) where T : Control
        {
            action?.Invoke(control);
            return control;
        }
        
        public static T TryDo<T>(this T control, Action<T> action, bool isTry) where T : Control
        {
            if (isTry) control.Do(action);
            return control;
        }
    }
}
