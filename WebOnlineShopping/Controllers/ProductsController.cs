using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOnlineShopping.Models;

namespace WebOnlineShopping.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MinimartDBContext _context;
        public ProductsController (MinimartDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(x=>x.Cat).FirstOrDefault(x =>x.ProductId == id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
