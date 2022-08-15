using GeekShoping.Web.Models;
using GeekShoping.Web.Services.IServices;
using GeekShoping.Web.Utils;

namespace GeekShoping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient client;
        public const string path = "api/v1/product";
        public ProductService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await client.GetAsync(path);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> FindById(long id)
        {
            var response = await client.GetAsync($"{path}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> Create(ProductModel model)
        {
            var response = await client.PostAsJson(path, model);
            if (!response.IsSuccessStatusCode) throw new Exception("algo deu errado aqui");
            else return await response.ReadContentAsync<ProductModel>();
        }
        public async Task<ProductModel> Update(ProductModel model)
        {
            var response = await client.PutAsJson(path, model);
            if (!response.IsSuccessStatusCode) throw new Exception("algo deu errado aqui");
            else return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<bool> DeleteById(long id)
        {
            var response = await client.DeleteAsync($"{path}/{id}");
            return await response.ReadContentAsync<bool>();
        }

    }
}
