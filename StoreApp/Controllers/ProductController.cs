using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
// using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        //Dependency Injection Pattern'i
        // private readonly RepositoryContext _context;

        //repository manager üzerinden almasın
        // private readonly IRepositoryManager _manager;
        // public ProductController(IRepositoryManager manager)
        // {
        //     _manager = manager;
        // }

        // public ProductController(RepositoryContext context)
        // {
        //     _context = context;
        // }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name="id")] int id)
        {
            //inversion of control
            // Product product = _context.Products.First(p => p.ProductId.Equals(id));
            // return View(product);

            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }

        // public IEnumerable<Product> Index()
        // {
            //Dependency Injection yok dikkat et!
            // var context = new RepositoryContext(
            //     new DbContextOptionsBuilder<RepositoryContext>()
            //     .UseSqlite("Data Source = C:\\Users\\ozmen\\GitHub\\BTK-ASP-NET-CORE-MVC\\Store\\ProductDb.db")
            //     .Options);

            // return context.Products;

            //Örnek bir veri döndürdük, denemek için.
            // return new List<Product>
            // {
            //     new Product(){ProductId=1, ProductName="Computer", Price=5}
            // };
        // }
    }
}