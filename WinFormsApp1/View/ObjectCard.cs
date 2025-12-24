namespace WinFormsApp1.View
{
    public abstract class ObjectCard : Panel
    {
        protected int _objectId;
        private bool _isMouseOver = false;

        public event EventHandler OnCardClicked;

        public ObjectCard(int id)
        {
            _objectId = id;
            InitializeCard();
        }

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

        public void CreateContent() { Controls.Add(Content()); }
        
        public virtual Control Content() { throw new ArgumentNullException(); }
    }
}
