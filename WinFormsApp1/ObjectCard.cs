using Logica.Extension;

namespace AdminApp.Controls
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
            ControlAdded += OnControlAdded;
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

        private void OnControlAdded(object sender, ControlEventArgs e)
            => SetupChildControl(e.Control);

        private void SetupChildControl(Control control)
        {
            control.MouseEnter += (s, args) =>
            {
                if (!_isMouseOver) 
                    OnMouseEnterCard(s, args);
            };

            control.MouseLeave += (s, args) =>
            {
                if (!ClientRectangle.Contains(PointToClient(Cursor.Position)))
                    OnMouseLeaveCard(s, args);
            };

            control.Click += OnClickCard;
            control.Cursor = Cursors.Hand;

            foreach (Control child in control.Controls)
                SetupChildControl(child);
        }

        public virtual void CreateContent() { Controls.Add(Content()); }
        
        public virtual Control Content() { return null; }
    }
}
