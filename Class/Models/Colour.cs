namespace Class.Models
{
    public class Colour : BaseEntity
    {
        public string  Name { get; set; }
        public List<ProductColor>? ProductColors {  get; set; } 
    }
}
