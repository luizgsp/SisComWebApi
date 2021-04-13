using SisComWebApi.Data;
using SisComWebApi.Models;
using SisComWebApi.Services.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SisComWebApi.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> FindAllAsync()
        {
            return await _context.Customers
                .ToListAsync();
        }

        public async Task<Customer> FindByIdAsAsync(int id)
        {
            return await _context.Customers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public async Task InsertAsync(Customer obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Customers.FindAsync(id);
                _context.Customers.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }

        }

        public async Task UpdateAsync(Customer obj)
        {
            bool hasAny = await _context.Customers.AnyAsync(x => x.Id == obj.Id);
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
