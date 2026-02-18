using Admin.Args;
using Admin.ViewModel.Interface;
using CSharpFunctionalExtensions;

public abstract class ObjectCard<T> : Panel
    where T : Entity, new()
{
    protected T entity;

    private bool _isMouseOver;
    private bool _isContextMenuShowing;

    public event EventHandler OnCardClicked;

    public ObjectCard()
    {
        BorderStyle = BorderStyle.FixedSingle;
        BackColor = Color.White;
        Margin = new Padding(5);
        Padding = new Padding(10);
        Size = new Size(400, 150);
        Cursor = Cursors.Hand;

        MouseEnter += OnMouseEnterCard;
        MouseLeave += OnMouseLeaveCard;
        MouseClick += OnMouseClickCard;

        ControlAdded += (s, e) => SetupChildControl(e.Control);
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
        if (!ClientRectangle.Contains(mousePosition))
        {
            _isMouseOver = false;
            BackColor = Color.White;
        }
    }

    private void OnMouseEnterCard(object? sender, EventArgs e)
    {
        if (!_isContextMenuShowing)
        {
            _isMouseOver = true;
            BackColor = Color.LightCyan;
        }
    }

    private void OnMouseLeaveCard(object? sender, EventArgs e)
    {
        if (!_isContextMenuShowing)
        {
            _isMouseOver = false;
            BackColor = Color.White;
        }
    }

    private void OnMouseClickCard(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            OnCardClicked?.Invoke(this, EventArgs.Empty);
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

    private void SetupChildControl(Control control)
    {
        control.MouseEnter += (s, args) =>
        {
            if (_isMouseOver || _isContextMenuShowing) return;
            OnMouseEnterCard(s, args);
        };

        control.MouseLeave += (s, args) =>
        {
            var pos = PointToClient(Cursor.Position);
            if (ClientRectangle.Contains(pos) || _isContextMenuShowing) return;
            OnMouseLeaveCard(s, args);
        };

        control.MouseClick += (s, args) =>
        {
            if (args.Button == MouseButtons.Left && !_isContextMenuShowing)
            {
                OnCardClicked?.Invoke(this, EventArgs.Empty);
                OnMouseLeaveCard(s, args);
            }
            else if (args.Button == MouseButtons.Right)
            {
                if (Parent != null)
                {
                    foreach (Control parentControl in Parent.Controls)
                    {
                        if (parentControl is ObjectCard<T> card && card != this)
                        {
                            card.ResetHighlight();
                        }
                    }
                }

                ContextMenuStrip?.Show(control, args.Location);
            }
        };

        control.Cursor = Cursors.Hand;

        foreach (Control childControl in control.Controls)
        {
            SetupChildControl(childControl);
        }
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
        {
            Parent.MouseClick += (s, args) =>
            {
                var hitControl = Parent.GetChildAtPoint(args.Location);
                if (hitControl is not ObjectCard<T>)
                {
                    ResetHighlight();
                }
            };
        }
    }
    
    public virtual ObjectCard<T> Initialize(T obj)
    {
        entity = obj;
        Controls.Add(Content());

        return this;
    }
    
    public abstract Control Content();

    public ObjectCard<T> OnContextMenu(IButtons<CardClickedToolStripArgs<T>>? buttonsContextMenu)
    {
        var buttons = buttonsContextMenu?.GetButtons(this, new CardClickedToolStripArgs<T>(entity));
        buttons?.ForEach(b => AddToolStrip(b.Text, b.PerformClick, b.Enabled));
        return this;
    }

    public ObjectCard<T> AddToolStrip(string name, Action action, bool enabled = true)
    {
        if (ContextMenuStrip is null)
        {
            ContextMenuStrip = new ContextMenuStrip();
            ContextMenuStrip.Opening += OnContextMenuOpening;
            ContextMenuStrip.Closed += OnContextMenuClosed;
        }
        var toolStrip = new ToolStripMenuItem(name);
        toolStrip.Click += (s, e) => action.Invoke();
        toolStrip.Enabled = enabled;
        ContextMenuStrip.Items.Add(toolStrip);

        return this;
    }

    public ObjectCard<T> OnClickedCard(IButton<CardClickedArgs<T>>? buttonsContextMenu)
    {
        var button = buttonsContextMenu?.GetButton(this, new CardClickedArgs<T>(entity));
        OnCardClicked += (s, e) => button?.PerformClick();
        return this;
    }
}


