using System.ComponentModel.DataAnnotations;

namespace GeekShooping.Web.Models;

public class ProductModel
{
    public long Id { get; set; }
    [Required(ErrorMessage = "O campo Name é obrigatório.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O campo Price é obrigatório.")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "O campo Description é obrigatório.")]
    public string Description { get; set; }
    [Required(ErrorMessage = "O campo CategoryName é obrigatório.")]
    public string CategoryName { get; set; }
    [Required(ErrorMessage = "O campo ImageUrl é obrigatório.")]
    public string ImageUrl { get; set; }
}
