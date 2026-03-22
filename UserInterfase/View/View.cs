using System.Windows.Forms;
using UserInterface.Interface;
using UserInterface.LayoutPanel;

namespace UserInterface.View;

//public abstract class UiView<T> : UiView
//{
    
//}

//public abstract class UiView<T, TEntity> : UiView<T>
//    where T : IDataUi<TEntity>
//{
//    public new T DataUi { get; set; } = default!;
//}

//public abstract class UiView
//{
//    protected T ViewModel { get => field ?? throw new NullReferenceException(); set; }

//    protected virtual Form InitializeForm(Form form)
//    {
//        return form;
//    }

//    public Form InitializeComponents(Form form)
//    {
//        form.Controls.Clear();
//        InitializeForm(form);
//        form.Controls.Add(CreateUi(new BuilderLayoutPanel()).Build());
//        return form;

//    }

//    protected abstract IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel);
//}
