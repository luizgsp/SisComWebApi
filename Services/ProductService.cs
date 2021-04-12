﻿using Microsoft.EntityFrameworkCore;
using SisComWebApi.Data;
using SisComWebApi.Models;
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

        public List<Product> FindAll()
        {
            return _context.Products
                .Include(x => x.Category)
                .ToList();
        }

        public Product FindById(int id)
        {
            return _context.Products
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .FirstOrDefault(x => x.Id == id); ;
        }

        public List<Product> FindByCategory(int id)
        {
            return _context.Products
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .Where(x => x.CategoriaId == id)
                    .ToList();
            
        }

        public void Insert(Product obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
