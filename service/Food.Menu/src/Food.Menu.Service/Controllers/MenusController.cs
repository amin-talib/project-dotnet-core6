using Food.Menu.Service.Dtos;
using Food.Menu.Service.Entities;
using Food.Menu.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food.Menu.Service.Controllers
{
    [ApiController]
    [Route("menus")]
    public class MenusController : ControllerBase
    {
       private readonly IRepository<Menus> menusRepository;
       public MenusController(IRepository<Menus> menusRepository)
       {
        this.menusRepository = menusRepository;
       }
        [HttpGet]
        public async Task<IEnumerable<MenusDto>> GetAsync()
        {
            var menus = (await menusRepository.GetAllAsync())
                        .Select(menu =>menu.AsDto());

            return menus;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MenusDto>> GetByIdAsync(Guid id)
        {
            var menu = await menusRepository.GetAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return menu.AsDto();
        }
        [HttpPost]
        public async Task<ActionResult<MenusDto>> PostAsync(CreateMenusDto createMenusDto)
        {
            var menu = new Menus{
               Name = createMenusDto.Name,
               ProductName= createMenusDto.ProductName,
               Description= createMenusDto.Description,
               CategoryName=createMenusDto.CategoryName,
               Price=createMenusDto.Price,
               Quantity=createMenusDto.Quantity,
               ImageUrl=createMenusDto.ImageUrl,
               CreatedDate = DateTimeOffset.UtcNow
            };
            await menusRepository.CreateAsync(menu);
            return CreatedAtAction(nameof(GetByIdAsync),new {id = menu.Id},menu);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id,UpdateMenusDto updateMenusDto)
        {
            var existingMenu = await menusRepository.GetAsync(id);
            if (existingMenu == null)
            {
                return NotFound();
            }
            existingMenu.Name = updateMenusDto.Name;
            existingMenu.ProductName=updateMenusDto.ProductName;
            existingMenu.Description=updateMenusDto.Description;
            existingMenu.CategoryName=updateMenusDto.CategoryName;
            existingMenu.Price=updateMenusDto.Price;
            existingMenu.Quantity=updateMenusDto.Quantity;
            existingMenu.ImageUrl=updateMenusDto.ImageUrl;
            await menusRepository.UpdateAsync(existingMenu);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
             var menu = await menusRepository.GetAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            await menusRepository.RemoveAsync(menu.Id);
             return NoContent();
        }
    }
}