using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

//bu component'i _navbar üzerinde kullandık.
namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {   
        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        // private readonly RepositoryContext _context;
        //bu şekilde DI yapmak sakıncalı. servis üzerinden işlem yapmak gerek. örneğin veritabanında 100 ürün var, 20 tanesi satışta değilse, 100 ürünü de sayar ve 100 olarak gösterir. Logic'e bağlı olması için servis üzerinden hareket edilmelidir.

        // public ProductSummary(RepositoryContext context)
        // {
        //     _context = context;
        // }

        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
            // return _context.Products.Count().ToString();
        }
    }
}