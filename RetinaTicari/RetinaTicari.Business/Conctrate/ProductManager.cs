using RetinaTicari.Business.Abstract;
using RetinaTicari.DataAccess.Abstract;
using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.Business.Conctrate
{
    public class ProductManager : IProductServise
    {
        /// <summary>
        /// Solid D katmanına göre üst katman alt katmanı new-leyemez.
        /// Dependency Incejection servisi sınıfın ihtiyaç duyduğu farklı sınıfı consructor vasıtası ile çağırabiliriz
        /// ProductManageri newleyerek çağırdığım zaman bana bir ProductDal ver. 
        /// yani burada aslında Entitiy framework'ü çağırıyoruz. EfEntityRepositoryBase classını çağırıyoruz.
        /// </summary>
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId || categoryId == 0);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
