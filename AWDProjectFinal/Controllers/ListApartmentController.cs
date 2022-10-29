using AWDProjectFinal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWDProjectFinal.Controllers
{
    public class ListApartmentController : Controller
    {
        private readonly AWDProjectFinalContext _context;
        public ListApartmentController(AWDProjectFinalContext context) { 
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            var apartment = await _context.ApartmentModels.ToListAsync();
            return View(apartment);
        }
    }
}
