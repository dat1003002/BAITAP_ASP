using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;
using WebApp_MVC.Service;

namespace WebApp_MVC.Controllers
{
    public class ProductController : Controller

    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly    IWebHostEnvironment _whostEnvironment;

        public ProductController
            (
           IWebHostEnvironment hostEnvironment,
            IProductService productService ,
            ICategoryService categoryService)
            
        {
            _productService = productService;
            _categoryService = categoryService;
            _whostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var model = new ProductViewModel();
            model.Categories = _categoryService.GetList();
            model.Products = _productService.GetList();
            return View(model);
        }
       public IActionResult LoadProduct(int id)
        {
             var model = new ProductViewModel();
            model.Categories = _categoryService.GetList();
            model.Products = _productService.GetListByCatID(id);
            return PartialView("_ListProduct",model);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(ProductViewModel viewModel)
        {
            if (viewModel.ProductRequest.Avatar !=null)
            {
                
                var filename = Guid.NewGuid().ToString() + ".png";
              var  path = Path.Combine(_whostEnvironment.WebRootPath, "image",filename
                  );

              var stream = System.IO.File.Create(path);
                viewModel.ProductRequest.Avatar.CopyTo(stream);
                stream.Close();
                viewModel.ProductRequest.AvatarUrl = Path.Combine("image", filename);

            }
            _productService.Insert(viewModel);
            return RedirectToAction("Index");
            

            
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel viewModel)
        {
            if (viewModel.ProductRequest.Avatar != null)
            {

                var filename = Guid.NewGuid().ToString() + ".png";
                var path = Path.Combine(_whostEnvironment.WebRootPath, "image", filename
                    );

                var stream = System.IO.File.Create(path);
                viewModel.ProductRequest.Avatar.CopyTo(stream);
                stream.Close();
                viewModel.ProductRequest.AvatarUrl = Path.Combine("image", filename);

            }
            _productService.Update(viewModel);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            var rs = _productService.GetList();
            return RedirectToAction("Index");

        }


    }
    }
