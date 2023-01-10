using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
	public interface IProductService
	{
        List<ProductResponse> GetListByCatID(int id);
		void Delete(int id);
        ProductResponse Get(int id);
        List<ProductResponse> GetList();
        void Insert(ProductViewModel viewModel);
        void Update(ProductViewModel viewModel);
        
    }
}