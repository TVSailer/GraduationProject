using Admin.ViewModel.Managment;
using Admin.ViewModels.Lesson;
using CSharpFunctionalExtensions;
using Logica;

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
                FactoryElements.TableLayoutPanel()
                .With(t => fieldInfos
                    .ForEach(fi => t
                        .StartNewRowTableAbsolute(60)
                        .ControlAddIsColumnAbsolute(FactoryElements.Label_11($"{fi.LabelText}: "), 300)
                        .ControlAddIsColumnPercent(fi.GetContol(context), 10)
                        .EndTabel()))
                .ControlAddIsRowsPercent()
                .StartNewRowTableAbsolute(80)
                    .ControlAddIsColumnPercent(FactoryElements.Button("Очистить поиск", context, nameof(context.OnClearSerch)))
                .EndTabel()));
    }
}
