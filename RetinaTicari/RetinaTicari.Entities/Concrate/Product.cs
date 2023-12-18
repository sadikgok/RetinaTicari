using RetinaTicari.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace RetinaTicari.Entities.Concrate
{
    public class Product : IEntity
    {
        [Key]
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; } 

    }
}
