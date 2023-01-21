using System.ComponentModel.DataAnnotations;

namespace Food.Menu.Service.Entities
{
     public class Category 
    {
         [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}