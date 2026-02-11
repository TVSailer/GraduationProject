using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel
{
    public class SearchModule<TEntity, TField>(SearchEntity<TEntity, TField> context) : IUIModel
        where TEntity : Entity, new()
        where TField : PropertyChange, IFieldData
    {
        private readonly List<FieldInfoUiAttribute> fieldInfos = context.Field.GetType().GetAttributes<FieldInfoUiAttribute>();
        public readonly SearchEntity<TEntity, TField> Search = context;

        public Control CreateControl()
            => new Panel()
            .With(t => t.BorderStyle = BorderStyle.FixedSingle)
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.Controls.Add(
                LayoutPanel.CreateColumn()
                .With(t => fieldInfos
                    .ForEach(fi => t
                        .Row(60, SizeType.Absolute)
                            .Column(300, SizeType.Absolute).ContentEnd(FactoryElements.Label_11($"{fi.LabelText}: "))
                            .Column(10).ContentEnd(fi.GetControl(Search.Field))
                        .End()))
                .Row().ContentEnd(new EmptyPanel())
                .Row(60, SizeType.Absolute).ContentEnd(FactoryElements.Button("Очистить поиск", Search, nameof(context.OnClearSerch)))
                .Build()));
    }
}
