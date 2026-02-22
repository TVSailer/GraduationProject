using Admin.View.Moduls.UIModel;
using Admin.ViewModel.Interface;
using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica.UILayerPanel;

namespace Admin.View.UIModel
{
    public sealed class SearchPanel<TEntity, TField> : Panel
        where TEntity : Entity, new()
        where TField : PropertyChange, IFieldData
    {
        private readonly List<FieldInfoUiAttribute> fieldInfos;
        public readonly SearchEntity<TEntity, TField> Context;

        public SearchPanel(SearchEntity<TEntity, TField> context)
        {
            Context = context;
            fieldInfos = context.Field.GetType().GetAttributes<FieldInfoUiAttribute>();

            BorderStyle = BorderStyle.FixedSingle;
            Dock = DockStyle.Fill;

            Initialize();
        }

        private void Initialize()
            => Controls.Add(
                LayoutPanel.CreateColumn()
                .With(t => fieldInfos
                    .ForEach(fi => t
                        .Row(60, SizeType.Absolute)
                            .Column(300, SizeType.Absolute).ContentEnd(FactoryElements.Label_11($"{fi.LabelText}: "))
                            .Column(10).ContentEnd(fi.GetControl(Context.Field))
                        .End()))
                .Row().ContentEnd(new EmptyPanel())
                .Row(60, SizeType.Absolute).ContentEnd(FactoryElements.Button("Очистить поиск", Context, nameof(Context.OnClearSearch)))
                .Build());
    }
}
