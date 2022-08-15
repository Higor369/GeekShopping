using GeekShoping.Web.Models;

namespace GeekShoping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> FindById(long id);
        Task<ProductModel> Create(ProductModel model);
        Task<ProductModel> Update(ProductModel model);
        Task<bool> DeleteById(long id);

    }
}
