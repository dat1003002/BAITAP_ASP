using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_MVC.Data
{
	[Table("Category")]
	public class Category
	{
		//khóa chính
		[Key]
		public int Id { get; set; }
		[Required]
		//không được phép null
		[StringLength(50)]
		//độ dài	
		public string Name { get; set; }

		public virtual List<Product> Products { get; set; }
	}
}
