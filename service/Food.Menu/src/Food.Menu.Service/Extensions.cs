using Food.Menu.Service.Dtos;
using Food.Menu.Service.Entities;

namespace Food.Menu.Service
{
    public static class Extensions
    {
        public static MenusDto AsDto(this Menus menu)
        {
            return new MenusDto(menu.Id,menu.Name,menu.ProductName,menu.Description,menu.CategoryName,menu.Price,menu.Quantity,menu.ImageUrl,menu.CreatedDate);
        }
        
    }
}