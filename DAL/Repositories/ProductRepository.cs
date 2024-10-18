using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<int> GetActiveProductCountAsync()
        {
            return await _context.Products.CountAsync(p => p.IsActive == true);
        }

        public async Task<List<Product>> GetAllActiveProductsAsync(int positoin)
        {
            return await _context.Products
                                 .OrderBy(p => p.Name)
                                 .Where(p => p.IsActive == true)
                                 .Skip(positoin * 10)
                                 .Take(10)
                                 .ToListAsync();
            //.Where(p => p.IsActive == true)
            }

        public async Task<List<Product>> GetAllProductsAsync(int position)
        {
            return await _context.Products
                                 .OrderBy(p => p.Name)
                                 .Skip(position * 10)
                                 .Take(10)
                                 .ToListAsync();
        }

        public async Task<Product> GetProductById(Guid Id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == Id);
        }

        public async Task<int> GetProductCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {

            var retProduct = await _context.Products.FindAsync(product.ProductId);

            if (retProduct == null)
            {
                return;
            }
            retProduct.Description = product.Description;
            retProduct.Name = product.Name;
            retProduct.IsActive = product.IsActive;

            await _context.SaveChangesAsync();
            

        }
    }
}
