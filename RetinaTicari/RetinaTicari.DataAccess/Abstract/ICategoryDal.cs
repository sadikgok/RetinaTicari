using RetinaTicari.Core.DataAccess;
using RetinaTicari.Entities.Concrate;

namespace RetinaTicari.DataAccess.Abstract 
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //custom operations you can write custom operations here (store proc or linq questions)
    }
}
