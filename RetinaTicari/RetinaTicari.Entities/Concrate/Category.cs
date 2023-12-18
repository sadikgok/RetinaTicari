
using RetinaTicari.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace RetinaTicari.Entities.Concrate 
{
    public class Category : IEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
