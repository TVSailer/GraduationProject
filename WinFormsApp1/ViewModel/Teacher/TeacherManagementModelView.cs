using Admin.View.Moduls.Teacher;
using DataAccess.Postgres.Models;
using DataAccess.Postgres.Repository;
using Logica;
using Logica.DI;
using System.Windows.Input;
using WinFormsApp1;
using WinFormsApp1.View;

namespace Admin.ViewModels.Teachers
{
    public class TeacherManagementModelView
    {
        //public override ICommand OnSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public override ICommand OnClearSerch { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TeacherManagementModelView(AdminMainView mainForm, TeacherRepository repository) 
        {

        }
    }
}
