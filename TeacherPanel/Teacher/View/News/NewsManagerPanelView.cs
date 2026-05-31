using Domain.Entitys;
using Teacher.ViewModel.News;
using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;

namespace Teacher.View.News;

public class NewsManagerPanelView(NewsManagerPanelViewModel viewModel) : UiView<NewsManagerPanelViewModel>
{
    public override IBuilder CreateUi(BuilderLayoutPanel builderLayoutPanel)
        => builderLayoutPanel.Column()
            .Row().Content()
                .CardTableLayoutPanel<NewsEntity, NewsCard>()
                .Initialize(viewModel.News)
                .Binding(viewModel, nameof(viewModel.News))
            .End()
            .RowAbsolute(80)
                .Column().Content()
                    .Button("Назад")
                    .Command(viewModel.Exit)
                .End().
                Column().Content()
                    .Button("Обновить")
                    .Command(viewModel.Update)
                .End()
                .Column().Content()
                    .Button("Предыдущие")
                    .Command(viewModel.Previous)
                .End()
                .Column().Content()
                    .Button("Следующие")
                    .Command(viewModel.Next)
                .End()
            .End();
}