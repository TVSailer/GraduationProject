using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;

namespace Admin.View.Moduls.UIModel
{
    public class SerchModule<TEntity> : IUIModel
        where TEntity : Entity
    {
        private readonly SerchManagment<TEntity> context;
        private readonly List<FieldInfoSerchAttribute> fieldInfos;

        public SerchModule(SerchManagment<TEntity> context)
        {
            this.context = context;

            var fieldInfos = context.GetType().GetAttributes<FieldInfoSerchAttribute>();

            if (fieldInfos != null)
                this.fieldInfos = fieldInfos;
        }

        public Control CreateControl()
            => new Panel()
            .With(t => t.BorderStyle = BorderStyle.FixedSingle)
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.Controls.Add(
                FactoryElements.TableLayoutPanel()
                .With(t => fieldInfos
                    .ForEach(fi => t
                        .StartNewRowTableAbsolute(60)
                        .ControlAddIsColumnAbsolute(FactoryElements.Label_11($"{fi.Text}: "), 140)
                        .ControlAddIsColumnPercent(FactoryElements.TextBox("")
                            .With(tb => tb.DataBindings.Add(new Binding(nameof(tb.Text), context, fi.NameProperty, false, DataSourceUpdateMode.OnPropertyChanged))), 10)
                        .EndTabel()))
                .ControlAddIsRowsPercent()
                .StartNewRowTableAbsolute(80)
                    .ControlAddIsColumnPercent(FactoryElements.Button("Поиск", context, nameof(context.OnSerch)), 50)
                    .ControlAddIsColumnPercent(FactoryElements.Button("Очистить поиск", context, nameof(context.OnClearSerch)), 50)
                .EndTabel()));
    }
}

//.EndTabel()
//.StartNewRowTableAbsolute(60)
//    .ControlAddIsColumnAbsolute(FactoryElements.Label_11("Категория: "), 140)
//    .ControlAddIsColumnPercent(FactoryElements.ComboBox()
//        .With(cb => cb.DataBindings.Add(new Binding("DataSource", context, "Categorys")))
//        .With(cb => cb.SelectedIndexChanged += (s, e) => context.Category = cb.SelectedItem.ToString()), 10)