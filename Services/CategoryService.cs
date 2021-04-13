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
    public class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Categories
                .ToListAsync();
        }

        public async Task<Category> FindByIdAsAsync(int id)
        {
            return await _context.Categories
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task InsertAsync(Category obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Category obj)
        {
            bool hasAny = await _context.Categories.AnyAsync(x => x.Id == obj.Id);
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
