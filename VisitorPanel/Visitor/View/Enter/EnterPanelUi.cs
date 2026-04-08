using UserInterface.LayoutPanel;
using UserInterface.LayoutPanel.Extension;
using UserInterface.View;
using Visitor.ViewModel.Enter;

namespace Visitor.View.Enter;

public class EnterPanelView(EnterPanelViewModel viewModel) : Forma<EnterPanelViewModel>
{
    public override void Initialize()
    {
        Size = new Size(width: 500, height: 250);
    }

    public override IBuilder ControlUi(BuilderLayoutPanel builderLayoutPanel)
    => builderLayoutPanel.Column()
            .RowAbsolute(40)
                .Column(10).Content().Label("Логин").End()
                .Column(40).Content().TextBox("Введите логин").Binding(viewModel, nameof(viewModel.Login)).End()
                .Column(30, SizeType.Absolute).End()
            .End()
            .RowAbsolute(40)
                .Column(10).Content().Label("Пароль").End()
                .Column(40).Content().TextBox("Введите пароль").UseSystemPasswordChar().Binding(viewModel, nameof(viewModel.Password)).End()
                .Column(30, SizeType.Absolute).End()
            .End()
            .Row().End()
            .RowAbsolute(50)
                .Column(50)
                .End()
                .Column(25).Content()
                    .Button("Вход")
                    .Command(viewModel.Enter)
                .End()
                .Column(25).Content()
                    .Button("Выход")
                    .Command(viewModel.Exit)
                .End()
            .End();
}