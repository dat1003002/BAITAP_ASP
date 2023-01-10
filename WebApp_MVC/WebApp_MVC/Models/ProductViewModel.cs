namespace WebApp_MVC.Models
{
    public class ProductViewModel
    {
        public List<ProductResponse> Products { get; set; }
        public List<CategoryResponse> Categories { get; set; }
        public ProductRequest ProductRequest { get; set; }
    }
}
