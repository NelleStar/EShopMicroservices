namespace Catalog.API.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException() : base("Category Not Found")
        {

        }
    }
}
