using RetinaTicari.Business.Abstract;
using RetinaTicari.DataAccess.Abstract;
using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.Business.Conctrate 
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
           return _categoryDal.GetList();
        }
    }
}
