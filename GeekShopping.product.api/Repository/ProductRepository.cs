using AutoMapper;
using GeekShopping.product.api.Data.ValueObjects;
using GeekShopping.product.api.Models;
using GeekShopping.product.api.Models.context;
using GeekShopping.ProductAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.product.api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper  _mapper;

        public ProductRepository(
            MySqlContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product? product = 
                await _context.Products.Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product? product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product? product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Product? product =
                   await _context.Products.Where(x => x.Id == id)
                   .FirstOrDefaultAsync();

                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                
            }
        }

    }
}
