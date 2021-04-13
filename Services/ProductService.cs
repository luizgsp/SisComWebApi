using Microsoft.EntityFrameworkCore;
using SisComWebApi.Data;
using SisComWebApi.Models;
using SisComWebApi.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisComWebApi.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Products
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Product> FindByIdAsAsync(int id)
        {
            return await _context.Products
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task<List<Product>> FindByCategoryAsync(int id)
        {
            return await _context.Products
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .Where(x => x.CategoriaId == id)
                    .ToListAsync();
            
        }

        public async Task InsertAsync(Product obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Products.FindAsync(id);
                _context.Products.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
            
        }

        public async Task UpdateAsync(Product obj)
        {
            bool hasAny = await _context.Products.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
