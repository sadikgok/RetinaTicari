using RetinaTicari.Core.DataAccess.EntityFramework;
using RetinaTicari.DataAccess.Abstract;
using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.DataAccess.Concrate 
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
