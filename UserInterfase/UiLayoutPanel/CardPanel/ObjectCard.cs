using System.Drawing;
using System.Windows.Forms;
using ExtensionFunc;
using UserInterface.Info;
using UserInterface.UiLayoutPanel.ButtonPanel;
using UserInterface.UiLayoutPanel.CardPanel.Args;

namespace UserInterface.UiLayoutPanel.CardPanel;

public abstract class ObjectCard<T> : Panel
{
    protected T Entity;

    private bool _isMouseOver;
    private bool _isContextMenuShowing;

    public event EventHandler OnCardClicked = null!;

    protected ObjectCard()
    {
        BorderStyle = BorderStyle.FixedSingle;
        BackColor = Color.White;
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
                foreach (Control control in Parent.Controls)
                    if (control is ObjectCard<T> card && card != this)
                        card.ResetHighlight();

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

        control?.MouseClick += (s, args) => MouseClicked(control, args, s);

        control?.Cursor = Cursors.Hand;

        foreach (Control childControl in control?.Controls!)
            SetupChildControl(childControl);
    }

    private void MouseClicked(Control? control, MouseEventArgs args, object? s)
    {
        if (args.Button == MouseButtons.Left && !_isContextMenuShowing)
        {
            OnCardClicked.Invoke(this, EventArgs.Empty);
            OnMouseLeaveCard(s, args);
        }
        else if (args.Button == MouseButtons.Right)
        {
            if (Parent != null)
                foreach (Control parentControl in Parent.Controls)
                    if (parentControl is ObjectCard<T> card && card != this)
                        card.ResetHighlight();

            ContextMenuStrip?.Show(control, args.Location);
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
            Parent.MouseClick += (_, args) =>
            {
                var hitControl = Parent.GetChildAtPoint(args.Location);
                if (hitControl is not ObjectCard<T>)
                    ResetHighlight();
            };
    }
    
    public ObjectCard<T> Initialize(object send, T entity)
    {
        Entity = entity;
        Controls.Add(Content());

        return this;
    }
    
    public abstract Control Content();

    public ObjectCard<T> OnContextMenu(IToolStrip<T>? buttonsContextMenu)
    {
        if (buttonsContextMenu is null) return this;

        var buttons = buttonsContextMenu.GetToolStrip(new CardClickedToolStripArgs<T>(Entity));

        ContextMenuStrip = new ContextMenuStrip();
        ContextMenuStrip.Opening += OnContextMenuOpening;
        ContextMenuStrip.Closed += OnContextMenuClosed;

        buttons.ForEach(AddToolStrip);
        return this;
    }
    
    private void AddToolStrip(InfoToolStrip button)
    {
        var toolStrip = new ToolStripMenuItem(button.Text);
        toolStrip.Click += (_, _) => button.OnClick();
        ContextMenuStrip?.Items.Add(toolStrip);
    }

    public ObjectCard<T> OnClickedCard(IClicked<T>? buttonsContextMenu)
    {
        var button = buttonsContextMenu?.GetButton(new CardClickedArgs<T>(Entity));
        OnCardClicked += (_, _) => button?.OnClick();
        return this;
    }
} 