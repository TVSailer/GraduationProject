using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.News.Buttons;

public class NewsManagmentButton(ControlView controlView) : 
    IButtons<ViewButtonClickArgs<NewsManagment>>,
    IButtons<CardClickedToolStripArgs<NewsEntity>>, 
    IButton<CardClickedArgs<NewsEntity>>
{
    public List<CustomButton> GetButtons(object? data, CardClickedToolStripArgs<NewsEntity> eventToolStripArgs)
        => [
        ];

    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<NewsManagment> eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить")
                .CommandClick(() => controlView.LoadView<NewsAddingFieldData>()),
        ];

    public CustomButton? GetButton(object? send, CardClickedArgs<NewsEntity> eventArgs)
        => new CustomButton()
            .CommandClick(() => controlView.LoadView<NewsDetailsFieldData, NewsEntity>(eventArgs.Entity));
}