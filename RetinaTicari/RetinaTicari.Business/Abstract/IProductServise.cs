using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.Business.Abstract
{
    public interface IProductServise
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
        Product GetById(int productId);
    }
}
