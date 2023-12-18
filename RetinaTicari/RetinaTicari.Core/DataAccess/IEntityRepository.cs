using RetinaTicari.Core.Entities;
using System.Linq.Expressions;

namespace RetinaTicari.Core.DataAccess
{
    /// <summary>
    /// IEntityRepository Generic olacağı için T yani Generic Constrain kısıtları koyabiliriz.
    /// IEntityden implement edilecek ve T: class olabilir ve newlenebilir.
    /// Abstract classlar ile Interfaceler newlenenemezler. new() yazmamızın nedeni bunların yazımını engellemek
    /// </summary>
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        /// <summary>
        /// GetList Metodunu kullanırken Expression verirsem o Expression göre bana listeyi getir mesela CategoryId'ye göre
        /// Ama Expression vermezsem tüm listeyi bana döndür..
        /// </summary>
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
