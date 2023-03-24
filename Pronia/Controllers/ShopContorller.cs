using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia.DAL;
using Pronia.Entities;

namespace Pronia.Controllers
{
    public class ShopContorller:Controller
    {
        readonly ProniaDbContext _context;

        public ShopContorller(ProniaDbContext context)
        {
            _context = context;
        }
        public IActionResult Detail(int id)
        {
            Plant? plant = _context.Plants.
                Include(b => b.PlantDeliveryInformation).
                Include(b => b.PlantCategories).ThenInclude(b => b.Category).
                Include(b => b.PlantTags).ThenInclude(b => b.Tag).
                Include(b => b.PlantImages).
                SingleOrDefault(b => b.Id == id);
            return View(plant);
        }
    }
}
