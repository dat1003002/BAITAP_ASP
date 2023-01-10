using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace WebApp_MVC.Data
{
    [Table ("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength (50)]

        public string Name { get; set; }
        [StringLength (500)]

        public string Description { get; set; }

        public int Price { get; set; }
        
        public DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }

       /* [ForeignKey("CategoryId")]*/

        public virtual Category Category { get; set; }
         public string AvatarUrl { get; set; }
    }
}
