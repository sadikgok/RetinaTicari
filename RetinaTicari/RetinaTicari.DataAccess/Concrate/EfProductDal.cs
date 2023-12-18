using RetinaTicari.Core.DataAccess.EntityFramework;
using RetinaTicari.DataAccess.Abstract;
using RetinaTicari.DataAccess.Concrate;
using RetinaTicari.Entities.Concrate;

namespace Abc.DataAccess.Concrate
{
    /// <summary>
    /// Business katmanı IProductDal üzerinden bu nesne üzerinden iletişim kuracaktır 
    /// </summary>
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
    }
}
