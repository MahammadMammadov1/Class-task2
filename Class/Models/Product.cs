using System.ComponentModel.DataAnnotations.Schema;

namespace Class.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsAvailable { get; set; }
       
        
        public double SalePrice { get; set; }
        

        public int CatagoryId { get; set; } 

        public Catagory? Catagory { get; set; }

        public List<ProductColor>? ProductColors { get; set; }

        public List<ProductImage>? ProductImages { get; set; }
        [NotMapped]
        public List<IFormFile>? ImageFiles { get; set; }
        [NotMapped]
        public IFormFile? ProductPoster { get; set; }
        [NotMapped]
        public IFormFile? ProductHower { get; set; }
        [NotMapped]
        public List<int>? ProductImageIds { get; set; }
    }
}
