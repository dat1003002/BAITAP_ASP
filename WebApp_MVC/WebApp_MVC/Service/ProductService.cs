using WebApp_MVC.Data;
using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<ProductResponse> GetList()
        {
            var rs = _db.Products.Select(e => new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                DateCreated = e.DateCreated,
                Description = e.Description,
                CategoryId = e.CategoryId,
                CategoryName = e.Category.Name,
                AvatarUrl = e.AvatarUrl
                

            }).ToList();
            return rs;
        }
       
        public ProductResponse Get(int id)
        {
            var rs = _db.Products.Where(e => e.Id == id).Select(e => new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                Description = e.Description,
                DateCreated = e.DateCreated,
                CategoryId = e.CategoryId

            }).FirstOrDefault();
            return rs;
        }

        public void Insert(ProductViewModel ViewModel)
        {
            var product = new Product
            {
                Name = ViewModel.ProductRequest.Name,
                Price = ViewModel.ProductRequest.Price,
                Description = ViewModel.ProductRequest.Description,
                DateCreated = ViewModel.ProductRequest.DateCreated,
                CategoryId = ViewModel.ProductRequest.CategoryId,
                AvatarUrl = ViewModel.ProductRequest.AvatarUrl,
            };
            _db.Products.Add(product);
            _db.SaveChanges();
        }



        public void Delete(int id)
        {
            var rs = _db.Products.Where(e => e.Id == id).FirstOrDefault();
            if (rs != null)
            {
                _db.Products.Remove(rs);
                _db.SaveChanges();
            }
        }





        public void Update(ProductViewModel viewModel)
        {

           
            var obj = _db.Products.Where(e => e.Id == viewModel.ProductRequest.Id).FirstOrDefault();
            //check is changed Avatar

            if (viewModel.ProductRequest.AvatarUrl !=null  )
            {
                obj.AvatarUrl = viewModel.ProductRequest.AvatarUrl;
                
            }
            if (obj != null)
            {
                obj.Name = viewModel.ProductRequest.Name;
                obj.Price = viewModel.ProductRequest.Price;
                obj.Description = viewModel.ProductRequest.Description;
                obj.DateCreated = viewModel.ProductRequest.DateCreated;
                obj.CategoryId = viewModel.ProductRequest.CategoryId;
               
            }
            _db.Products.Update(obj);
            _db.SaveChanges();

        }

        public List<ProductResponse> GetListByCatID(int id)
        {

            var rs = _db.Products.Where(e => e.CategoryId == id).Select(e => new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                Description = e.Description,
                DateCreated = e.DateCreated,
                CategoryId = e.CategoryId,
                CategoryName = e.Category.Name,
                AvatarUrl = e.AvatarUrl
            }).ToList();
            return rs;
        }
    }
}
