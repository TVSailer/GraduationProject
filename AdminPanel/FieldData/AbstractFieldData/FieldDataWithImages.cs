using Admin.FieldData.AbstractFieldData;
using CSharpFunctionalExtensions;
using DataAccess.PostgreSQL.Models.Imgs;
using UserInterface.GenericEntity;
using UserInterface.Interface;

namespace Admin.ViewModel.AbstractFieldData;

public abstract class FieldDataWithImages<TImg, TEntity> : FieldData<TEntity>, IDataWithImgUi
    where TEntity : Entity, new()
    where TImg : ImgEntity, new()
{
    protected List<TImg> ImagesData
    {
        get => RepositoryImgEntity.GetData().Select(i => new TImg {Url = i}).ToList();
        set => RepositoryImgEntity.SetData(value.Select(i => i.Url).ToArray());
    }

    public RepositoryImgEntity RepositoryImgEntity { get; set; } = new();
}