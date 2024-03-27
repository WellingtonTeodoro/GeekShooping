using GeekShooping.Web.Models;
using GeekShooping.Web.Services.IServices;
using GeekShooping.Web.Utils;

namespace GeekShooping.Web.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _cliente;
    public const string BasePath = "api/v1/product";

    public ProductService(HttpClient cliente)
    {
        _cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
    }

    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
        var response = await _cliente.GetAsync(BasePath);
        return await response.ReadContentAs<List<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
        var response = await _cliente.GetAsync($"{BasePath}/{id}");
        return await response.ReadContentAs<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel productModel)
    {
        var response = await _cliente.PostAsJson(BasePath,productModel);
        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<ProductModel>();
        }
        else
        {
            throw new Exception("Algo de errado ocorreu ao chamar a API.");
        }
        
    }

    public async Task<ProductModel> UpdateProduct(ProductModel productModel)
    {
        var response = await _cliente.PutAsJson(BasePath, productModel);
        if (response.IsSuccessStatusCode)
        {
            return await response.ReadContentAs<ProductModel>();
        }
        else
        {
            throw new Exception("Algo de errado ocorreu ao chamar a API.");
        }
    }

    public async Task<bool> DeleteProductById(long id)
    {
        var response = await _cliente.DeleteAsync($"{BasePath}/id?id={id}");
        if (response.IsSuccessStatusCode)
        { 
            return await response.ReadContentAs<bool>();
        }
        else
        {
            throw new Exception("Algo de errado ocorreu ao chamar a API.");
        }
    }  
}
