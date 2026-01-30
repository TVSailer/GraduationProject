using Admin.View.Moduls.UIModel;
using CSharpFunctionalExtensions;

public abstract class ObjectCard<T> : Panel
    where T : Entity
{
    protected T entity;
    protected int _objectId;

    private bool _isMouseOver = false;

    public event EventHandler OnCardClicked;

    public ObjectCard()
    {
        InitializeCard();
    }

    protected virtual void InitializeCard()
    {
        BorderStyle = BorderStyle.FixedSingle;
        BackColor = Color.White;
        Margin = new Padding(5);
        Padding = new Padding(10);
        Size = new Size(400, 150);
        Cursor = Cursors.Hand;

        MouseEnter += OnMouseEnterCard;
        MouseLeave += OnMouseLeaveCard;
        Click += OnClickCard;
        ControlAdded += (s, e) => SetupChildControl(e.Control);
    }

    private void OnMouseEnterCard(object sender, EventArgs e)
        => this
            .With(t => t._isMouseOver = true)
            .With(t => t.BackColor = Color.LightCyan);

    private void OnMouseLeaveCard(object sender, EventArgs e)
        => this
            .With(t => t._isMouseOver = false)
            .With(t => t.BackColor = Color.White);

    private void OnClickCard(object sender, EventArgs e)
        => this
            .With(t => t.OnCardClicked?.Invoke(this, EventArgs.Empty))
            .With(t => t.OnMouseLeaveCard(sender, e));

    private void SetupChildControl(Control control)
        => control
            .With(c => c.MouseEnter += (s, args) =>
                c.If(!_isMouseOver, c => OnMouseEnterCard(s, args)))
            .With(c => c.MouseLeave += (s, args) =>
                PointToClient(Cursor.Position)
                .If(pos => !ClientRectangle.Contains(pos),
                    pos => OnMouseLeaveCard(s, args)))
            .With(c => c.Click += OnClickCard)
            .With(c => c.Cursor = Cursors.Hand)
            .With(c => c.Controls.AsEnumerable().ForEach(SetupChildControl));

    public virtual ObjectCard<T> Initialize(T obj)
    {
        entity = obj;
        Controls.Add(Content());

        return this;
    }

    public ObjectCard<T> CreateCard(T entity)
    {
        var type = GetType();
        var card = type.GetConstructor([])!.Invoke([]);

        return (ObjectCard<T>)type.GetMethod("Initialize")!.Invoke(card, [entity])! ?? throw new ArgumentNullException();
    }
    public abstract Control Content();

}
