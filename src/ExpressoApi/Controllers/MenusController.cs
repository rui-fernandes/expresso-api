namespace ExpressoApi.Controllers
{
    using System.Linq;
    using ExpressoApi.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly ExpressoDbContext expressoDbContext;

        public MenusController(ExpressoDbContext expressoDbContext)
        {
            this.expressoDbContext = expressoDbContext;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var menus = this.expressoDbContext.Menus
                .Include("SubMenus");

            return this.Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenu(int id)
        {
            var menu = this.expressoDbContext.Menus
                .Include("SubMenus")
                .FirstOrDefault(m => m.Id == id);

            if (menu == null)
            {
                return this.NotFound();
            }

            return this.Ok(menu);
        }
    }
}
