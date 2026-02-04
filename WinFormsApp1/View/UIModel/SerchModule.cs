using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;
using Logica.UILayerPanel;

namespace Admin.View.Moduls.UIModel
{
    public class SerchModule<TEntity>(SerchEntity<TEntity> context) : IUIModel
        where TEntity : Entity, new()
    {
        private readonly List<FieldInfoUiAttribute> fieldInfos = context.GetType().GetAttributes<FieldInfoUiAttribute>();

        public Control CreateControl()
            => new Panel()
            .With(t => t.BorderStyle = BorderStyle.FixedSingle)
            .With(p => p.Dock = DockStyle.Fill)
            .With(p => p.Controls.Add(
                Layout.CreateColumn()
                .With(t => fieldInfos
                    .ForEach(fi => t
                        .Row(60, SizeType.Absolute)
                            .Column(300, SizeType.Absolute).ContentEnd(FactoryElements.Label_11($"{fi.LabelText}: "))
                            .Column(10).ContentEnd(fi.GetContol(context))
                        .End()))
                .Row().ContentEnd(new EmptyPanel())
                .Row(60, SizeType.Absolute).ContentEnd(FactoryElements.Button("Очистить поиск", context, nameof(context.OnClearSerch)))
                .Build()));
    }
}
