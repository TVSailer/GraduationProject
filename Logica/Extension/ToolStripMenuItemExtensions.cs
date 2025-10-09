using Logica;

public static class ToolStripMenuItemExtensions
{
    public static ToolStripItem FindSubMenuItem(this ToolStripMenuItem toolStripMenuItem, string text)
        => toolStripMenuItem.DropDownItems.OfType<ToolStripDropDownItem>()
                       .FirstOrDefault(item => item.Text == text);
    public static void RemoveSubMenuItem(this ToolStripMenuItem toolStripMenuItem, string text)
        => toolStripMenuItem.DropDownItems.Remove(toolStripMenuItem.DropDownItems.OfType<ToolStripDropDownItem>()
                       .FirstOrDefault(item => item.Text == text));

    public static ToolStripMenuItem Add(this ToolStripMenuItem toolStripMenuItem, params StripMenuItem[] stripMenuItem)
    {
        foreach (var item in stripMenuItem)
        {
            toolStripMenuItem.DropDownItems.Add(item.Name);
            toolStripMenuItem.DropDownItems[^1].Click += (send, e) => item.Action?.Invoke();
        }

        return toolStripMenuItem;
    }

}
