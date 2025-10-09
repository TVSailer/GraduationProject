public static class MenuStripExtensions
{
    public static ToolStripMenuItem FindMenuItem(this MenuStrip menuStrip, string text)
        => menuStrip.Items.OfType<ToolStripMenuItem>()
            .FirstOrDefault(item => item.Text == text);

    public static bool ContainsMenuItem(this MenuStrip menuStrip, string text)
        => menuStrip.Items.OfType<ToolStripMenuItem>()
            .Any(item => item.Text == text);

    public static void RemoveMenuItem(this MenuStrip menuStrip, string text)
        => menuStrip.Items.Remove(menuStrip.Items.OfType<ToolStripMenuItem>()
            .FirstOrDefault(item => item.Text == text));
}
