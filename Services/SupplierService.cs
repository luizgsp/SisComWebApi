using SisComWebApi.Data;
using SisComWebApi.Models;
using SisComWebApi.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SisComWebApi.Services
{
    public class SupplierService
    {
        private readonly DataContext _context;

        public SupplierService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> FindAllAsync()
        {
            return await _context.Suppliers
                .ToListAsync();
        }

        public async Task<Supplier> FindByIdAsAsync(int id)
        {
            return await _context.Suppliers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task InsertAsync(Supplier obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Suppliers.FindAsync(id);
                _context.Suppliers.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Supplier obj)
        {
            bool hasAny = await _context.Suppliers.AnyAsync(x => x.Id == obj.Id);
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
