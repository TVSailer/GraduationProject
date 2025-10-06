namespace Logica;
public static partial class LogicaMessage
{
    public static void MessageOk(object? obj)
    {
        if (obj is string text)
            MessageBox.Show((string)obj, "", MessageBoxButtons.OK);
    }

    public static bool MessageYesNo(object? obj)
    {
        if (obj is string text)
            return MessageBox.Show((string)obj, "", MessageBoxButtons.YesNo) == DialogResult.Yes;

        return false;
    }

}

public static partial class LogicaMessage
{
    // Стили по умолчанию
    private static string _defaultCaption = "Информация";
    private static MessageBoxIcon _defaultIcon = MessageBoxIcon.Information;
    private static MessageBoxDefaultButton _defaultButton = MessageBoxDefaultButton.Button1;

    /// <summary>
    /// Показывает сообщение с кнопкой OK
    /// </summary>
    public static void MessageOk(object? obj, string caption = null, MessageBoxIcon icon = MessageBoxIcon.None)
    {
        if (obj is string text)
        {
            MessageBox.Show(
                text,
                caption ?? _defaultCaption,
                MessageBoxButtons.OK,
                icon == MessageBoxIcon.None ? _defaultIcon : icon
            );
        }
        else if (obj != null)
        {
            MessageBox.Show(
                obj.ToString(),
                caption ?? _defaultCaption,
                MessageBoxButtons.OK,
                icon == MessageBoxIcon.None ? _defaultIcon : icon
            );
        }
    }

    /// <summary>
    /// Показывает сообщение с выбором Да/Нет
    /// </summary>
    public static bool MessageYesNo(object? obj, string caption = null, MessageBoxIcon icon = MessageBoxIcon.Question)
    {
        if (obj is string text)
        {
            return MessageBox.Show(
                text,
                caption ?? _defaultCaption,
                MessageBoxButtons.YesNo,
                icon
            ) == DialogResult.Yes;
        }
        else if (obj != null)
        {
            return MessageBox.Show(
                obj.ToString(),
                caption ?? _defaultCaption,
                MessageBoxButtons.YesNo,
                icon
            ) == DialogResult.Yes;
        }

        return false;
    }

    /// <summary>
    /// Показывает сообщение об ошибке
    /// </summary>
    public static void MessageError(object? obj, string caption = "Ошибка")
    {
        MessageOk(obj, caption, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Показывает предупреждающее сообщение
    /// </summary>
    public static void MessageWarning(object? obj, string caption = "Предупреждение")
    {
        MessageOk(obj, caption, MessageBoxIcon.Warning);
    }

    /// <summary>
    /// Показывает информационное сообщение
    /// </summary>
    public static void MessageInfo(object? obj, string caption = "Информация")
    {
        MessageOk(obj, caption, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Показывает сообщение с вопросом и кнопками Да/Нет/Отмена
    /// </summary>
    public static DialogResult MessageYesNoCancel(object? obj, string caption = "Подтверждение")
    {
        if (obj is string text)
        {
            return MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );
        }
        else if (obj != null)
        {
            return MessageBox.Show(
                obj.ToString(),
                caption,
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );
        }

        return DialogResult.Cancel;
    }

    /// <summary>
    /// Показывает сообщение с кнопками OK/Отмена
    /// </summary>
    public static bool MessageOkCancel(object? obj, string caption = "Подтверждение")
    {
        if (obj is string text)
        {
            return MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            ) == DialogResult.OK;
        }
        else if (obj != null)
        {
            return MessageBox.Show(
                obj.ToString(),
                caption,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            ) == DialogResult.OK;
        }

        return false;
    }

    /// <summary>
    /// Показывает сообщение с исключением (ошибкой)
    /// </summary>
    public static void MessageException(Exception ex, string caption = "Ошибка", bool showDetails = false)
    {
        string message = showDetails ?
            $"{ex.Message}\n\nДетали:\n{ex.StackTrace}" :
            ex.Message;

        MessageError(message, caption);
    }

    /// <summary>
    /// Показывает сообщение о успешной операции
    /// </summary>
    public static void MessageSuccess(object? obj, string caption = "Успешно")
    {
        MessageOk(obj, caption, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Показывает диалог ввода текста
    /// </summary>
    public static string MessageInput(string prompt, string caption = "Ввод", string defaultValue = "")
    {
        Form form = new Form();
        Label label = new Label();
        TextBox textBox = new TextBox();
        Button buttonOk = new Button();
        Button buttonCancel = new Button();

        form.Text = caption;
        label.Text = prompt;
        textBox.Text = defaultValue;

        buttonOk.Text = "OK";
        buttonCancel.Text = "Отмена";
        buttonOk.DialogResult = DialogResult.OK;
        buttonCancel.DialogResult = DialogResult.Cancel;

        label.SetBounds(9, 20, 372, 13);
        textBox.SetBounds(12, 36, 372, 20);
        buttonOk.SetBounds(228, 72, 75, 23);
        buttonCancel.SetBounds(309, 72, 75, 23);

        label.AutoSize = true;
        textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
        buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

        form.ClientSize = new Size(396, 107);
        form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
        form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
        form.FormBorderStyle = FormBorderStyle.FixedDialog;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.MinimizeBox = false;
        form.MaximizeBox = false;
        form.AcceptButton = buttonOk;
        form.CancelButton = buttonCancel;

        DialogResult dialogResult = form.ShowDialog();
        return dialogResult == DialogResult.OK ? textBox.Text : string.Empty;
    }

    /// <summary>
    /// Настройка параметров по умолчанию
    /// </summary>
    public static void SetDefaultOptions(string defaultCaption = null, MessageBoxIcon defaultIcon = MessageBoxIcon.None)
    {
        if (defaultCaption != null)
            _defaultCaption = defaultCaption;

        if (defaultIcon != MessageBoxIcon.None)
            _defaultIcon = defaultIcon;
    }

    /// <summary>
    /// Показывает сообщение с таймаутом (автоматическое закрытие)
    /// </summary>
    public static void MessageOkWithTimeout(object? obj, string caption = null, int timeoutMs = 3000)
    {
        if (obj is string text)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = timeoutMs;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                // Закрываем активное messagebox
                Application.OpenForms
                    .OfType<Form>()
                    .FirstOrDefault(x => x.Text == caption && x.GetType().Name == "MessageBoxForm")
                    ?.Close();
            };

            timer.Start();
            MessageOk(text, caption);
            timer.Stop();
        }
    }
}
