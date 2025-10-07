public class ZoomableControl : UserControl
{
    protected float CurrentZoom { get; set; } = 1.0f;
    protected float ZoomStep { get; set; } = 0.1f;
    protected float MinZoom { get; set; } = 0.5f;
    protected float MaxZoom { get; set; } = 3.0f;

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        if (Control.ModifierKeys == Keys.Control) // Ctrl + колесико
        {
            // Определяем направление масштабирования
            float zoomFactor = e.Delta > 0 ? ZoomStep : -ZoomStep;
            ChangeZoom(zoomFactor);

            // Предотвращаем прокрутку родительского контейнера
            ((HandledMouseEventArgs)e).Handled = true;
        }

        base.OnMouseWheel(e);
    }

    protected virtual void ChangeZoom(float zoomFactor)
    {
        float newZoom = CurrentZoom + zoomFactor;
        newZoom = Math.Max(MinZoom, Math.Min(MaxZoom, newZoom));

        if (newZoom != CurrentZoom)
        {
            CurrentZoom = newZoom;
            ApplyZoom();
        }
    }

    protected virtual void ApplyZoom()
    {
        // Переопределить в производных классах
    }
}


