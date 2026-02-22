using Admin.Args;
using Admin.DI;
using Admin.View;
using DataAccess.Postgres.Models;
using Logica.Interface;
using Logica.UI;

namespace Admin.ViewModel.Model.Teacher.Buttons;

public class TeacherManagmentButton(ControlView controlView) : 
    IButtons<ViewButtonClickArgs<TeacherManagment>>,
    IButtons<CardClickedToolStripArgs<TeacherEntity>>, 
    IButton<CardClickedArgs<TeacherEntity>>
{
    public List<CustomButton> GetButtons(object? data, CardClickedToolStripArgs<TeacherEntity> eventToolStripArgs)
        => [];

    public List<CustomButton> GetButtons(object? data, ViewButtonClickArgs<TeacherManagment> eventArgs)
        => [
            new CustomButton("Назад")
                .CommandClick(() => controlView.Exit()),
            new CustomButton("Добавить")
                .CommandClick(() => controlView.LoadView<TeacherAddingFieldData>()),
        ];

    public CustomButton? GetButton(object? send, CardClickedArgs<TeacherEntity> eventArgs)
        => new CustomButton()
            .CommandClick(() => controlView.LoadView<TeacherDetailsFieldData, TeacherEntity>(eventArgs.Entity));
}