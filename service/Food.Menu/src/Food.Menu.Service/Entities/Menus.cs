using System.ComponentModel.DataAnnotations.Schema;

namespace Food.Menu.Service.Entities
{

    public class Menus :IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
         [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
         public string ProductName { get; set; }
         public string Description { get; set; }
         public string CategoryName{get;set;}
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string ImageUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}