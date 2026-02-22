using Admin.Args;
using CSharpFunctionalExtensions;
using Logica.Interface;

namespace Admin.View;

public abstract class ObjectCard<T> : Panel
    where T : Entity, new()
{
    protected T Entity = null!;

    private bool _isMouseOver;
    private bool _isContextMenuShowing;

    public event EventHandler OnCardClicked = null!;

    protected ObjectCard()
    {
        BorderStyle = BorderStyle.FixedSingle;
        // ReSharper disable once VirtualMemberCallInConstructor
        BackColor = Color.White;
        // ReSharper disable once VirtualMemberCallInConstructor
        Cursor = Cursors.Hand;

        MouseEnter += OnMouseEnterCard;
        MouseLeave += OnMouseLeaveCard;
        MouseClick += OnMouseClickCard;

        ControlAdded += (_, e) => SetupChildControl(e.Control);
    }

    private void OnContextMenuOpening(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        _isContextMenuShowing = true;

        if (sender is not ContextMenuStrip { SourceControl: null }) return;

        _isMouseOver = true;
        BackColor = Color.LightCyan;
    }

    private void OnContextMenuClosed(object? sender, ToolStripDropDownClosedEventArgs e)
    {
        _isContextMenuShowing = false;

        var mousePosition = PointToClient(Cursor.Position);
        if (ClientRectangle.Contains(mousePosition)) return;
        _isMouseOver = false;
        BackColor = Color.White;
    }

    private void OnMouseEnterCard(object? sender, EventArgs e)
    {
        if (_isContextMenuShowing) return;
        _isMouseOver = true;
        BackColor = Color.LightCyan;
    }

    private void OnMouseLeaveCard(object? sender, EventArgs e)
    {
        if (_isContextMenuShowing) return;
        _isMouseOver = false;
        BackColor = Color.White;
    }

    private void OnMouseClickCard(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            OnCardClicked.Invoke(this, EventArgs.Empty);
            OnMouseLeaveCard(sender, e);
        }
        else if (e.Button == MouseButtons.Right)
        {
            if (Parent != null)
            {
                foreach (Control control in Parent.Controls)
                {
                    if (control is ObjectCard<T> card && card != this)
                    {
                        card.ResetHighlight();
                    }
                }
            }

            ContextMenuStrip?.Show(this, e.Location);
        }
    }

    private void SetupChildControl(Control? control)
    {
        control?.MouseEnter += (s, args) =>
        {
            if (_isMouseOver || _isContextMenuShowing) return;
            OnMouseEnterCard(s, args);
        };

        control?.MouseLeave += (s, args) =>
        {
            var pos = PointToClient(Cursor.Position);
            if (ClientRectangle.Contains(pos) || _isContextMenuShowing) return;
            OnMouseLeaveCard(s, args);
        };

        // ReSharper disable once ComplexConditionExpression
        control?.MouseClick += (s, args) =>
        {
            switch (args.Button)
            {
                case MouseButtons.Left when !_isContextMenuShowing:
                    OnCardClicked.Invoke(this, EventArgs.Empty);
                    OnMouseLeaveCard(s, args);
                    break;
                case MouseButtons.Right:
                {
                    if (Parent != null)
                        foreach (Control parentControl in Parent.Controls)
                            if (parentControl is ObjectCard<T> card && card != this)
                                card.ResetHighlight();

                    ContextMenuStrip?.Show(control, args.Location);
                    break;
                }
            }
        };

        control?.Cursor = Cursors.Hand;

        foreach (Control childControl in control?.Controls!)
            SetupChildControl(childControl);
    }

    public void ResetHighlight()
    {
        _isMouseOver = false;
        _isContextMenuShowing = false;
        BackColor = Color.White;
    }

    protected override void OnParentChanged(EventArgs e)
    {
        base.OnParentChanged(e);

        if (Parent != null)
            Parent.MouseClick += (_, args) =>
            {
                var hitControl = Parent.GetChildAtPoint(args.Location);
                if (hitControl is not ObjectCard<T>)
                    ResetHighlight();
            };
    }
    
    public virtual ObjectCard<T> Initialize(T obj)
    {
        Entity = obj;
        var content = Content();
        Size = content.PreferredSize with { Width = content.PreferredSize.Width + 10 };
        Controls.Add(content);

        return this;
    }
    
    public abstract Control Content();

    public ObjectCard<T> OnContextMenu(IButtons<CardClickedToolStripArgs<T>>? buttonsContextMenu)
    {
        if (buttonsContextMenu is null) return this;

        var buttons = buttonsContextMenu.GetButtons(this, new CardClickedToolStripArgs<T>(Entity));

        ContextMenuStrip = new ContextMenuStrip();
        ContextMenuStrip.Opening += OnContextMenuOpening;
        ContextMenuStrip.Closed += OnContextMenuClosed;

        buttons?.ForEach(b => AddToolStrip(b.Text, b.PerformClick, b.Enabled));
        return this;
    }

    public ObjectCard<T> AddToolStrip(string name, Action action, bool enabled = true)
    {
        var toolStrip = new ToolStripMenuItem(name);
        toolStrip.Click += (_, _) => action.Invoke();
        toolStrip.Enabled = enabled;
        ContextMenuStrip?.Items.Add(toolStrip);

        return this;
    }

    public ObjectCard<T> OnClickedCard(IButton<CardClickedArgs<T>>? buttonsContextMenu)
    {
        var button = buttonsContextMenu?.GetButton(this, new CardClickedArgs<T>(Entity));
        OnCardClicked += (_, _) => button?.PerformClick();
        return this;
    }
}