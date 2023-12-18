using RetinaTicari.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RetinaTicari.Core.DataAccess.EntityFramework 
{
    /// <summary>
    /// Entity Frameworkda sorgu yazabilmek için iki şeye ihtiyaç vardır
    /// Birisi nesne TEntity yani diğeride Context
    /// Hangi nesne ve hangi context ile çalışacağım bilgisini almam gerekiyor
    /// where TEntity : class, IEntity, new().....kısıtlarımız.
    /// where TContext : DbContext, new ().....kısıtlarımız.
    /// 
    /// using ifadesi, IDisposable arayüzünü uygulamış nesnelerin kullanımını kolaylaştırmak için kullanılır. 
    /// Bu ifade, bir kaynağı kullandıktan sonra otomatik olarak Dispose() yöntemini çağırarak kaynakları serbest bırakır. 
    /// Bu sayede using ifadesi, kaynakların gereksiz yere uzun süre kullanılmasını önler ve 
    /// programın kaynakları doğru şekilde serbest bırakmasını sağlar.
    /// 
    /// Bir nesnenin new anahtar kelimesiyle oluşturulabilmesi, o nesnenin bellekte yeni bir örneğinin oluşturulmasını ifade eder.
    /// Yani, bir sınıfın örneği yaratılabilir ve bu örnek üzerinden sınıfın özellikleri ve yöntemleri kullanılabilir hale gelir.
    /// Bu durum, sınıfın bir örneğinin oluşturulduğu anlamına gelir.
    /// 
    /// Hayır, sadece referans tipleri değil, aynı zamanda değer tipleri de new anahtar kelimesiyle oluşturulabilir. Ancak, bu durum değer tipleri için farklı bir anlam taşır. 
    /// No, not only reference types but also value types can be created with the new keyword. However, this has a different meaning for value types.
    /// Referans tipleri, bellekte bir nesnenin adresini tutar ve new anahtar kelimesiyle bir örneği oluşturulur.Örneğin, sınıflar, diziler ve arayüzler referans tiplerine örnek olarak verilebilir. 
    /// Reference types hold the address of an object in memory and an instance of it is created with the new keyword. For example, classes, arrays, and interfaces are examples of reference types.
    /// </summary>
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        /// <summary>
        /// parametre yoksa tümünü parametre varsa parametreli kısmını gönder.
        /// if there is no parameter send it all, if there are parameters send the part with parameters
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {

            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
