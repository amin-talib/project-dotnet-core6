
using System.ComponentModel.DataAnnotations;

namespace Food.Menu.Service.Dtos
{
    public record MenusDto(Guid MenuId,string Name,string ProductName,string Description,string CategoryName,decimal Price,decimal Quantity,string ImageUrl,DateTimeOffset CreatedDate);

    public record CreateMenusDto([Required] string Name,string ProductName,string Description,string CategoryName,[Range(0,1000)] decimal Price,[Range(0,1000)] decimal Quantity,string ImageUrl);

    public record UpdateMenusDto([Required] string Name,string ProductName,string Description,string CategoryName,[Range(0,1000)] decimal Price,[Range(0,1000)] decimal Quantity,string ImageUrl);
}




