using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.View.Moduls.UIModel
{
    public class ButtonModule<TEntity, TViewModel> : IUIModel<TEntity, TViewModel>
        where TEntity : Entity
        where TViewModel : IViewModele<TEntity>
    {

    }
}
