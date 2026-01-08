namespace Admin.View.ViewForm
{
    public interface IViewForm
    {
        public Form InitializeComponents();
    }
    
    public interface IViewFormV2
    {
        public Form InitializeComponents(object data);
    }
}