using GeekShooping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShooping.ProductAPI.Model;

[Table("product")]
public class Product : BaseEntity
{
    [Column("name")]
    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Column("price")]
    [Required]
    [Range(1.0,100000.0)]
    public decimal Price { get; set; }
     
    [Column("description")]
    [Required]
    [StringLength(250)]
    public string Description { get; set; }
     
    [Column("category_name")]
    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }
     
    [Column("image_url")]
    [Required]
    [StringLength(300)]
    public string ImageUrl { get; set; }
}
