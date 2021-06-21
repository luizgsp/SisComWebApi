using Microsoft.EntityFrameworkCore;
using SisComWebApi.Data;
using SisComWebApi.Models;
using SisComWebApi.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public bool GenerateExcel(string template, string target, string camposAdicionais)
        {

            try
            {

                SpreadsheetDocument spreadsheetTarget = SpreadsheetDocument.Open(target, false);
                SpreadsheetDocument spreadsheetTemplate = SpreadsheetDocument.Open(template, false);

                IEnumerable<JToken> list = DeserializeObjects(camposAdicionais);

                foreach (var item in list)
                {
                    string name = ((JProperty)item).Name;
                    string value = ((JValue)((JProperty)item).Value).Value?.ToString();

                    using (spreadsheetTemplate)
                    {
                        WorkbookPart workbookPart = spreadsheetTemplate.WorkbookPart;
                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                        
                        foreach (Row r in sheetData.Elements<Row>())
                        {
                            foreach (Cell c in r.Elements<Cell>())
                            {
                                string text = c.CellValue.Text;
                                if (text.Contains("##" + name + "##"))
                                    c.CellValue.Text = value;
                            }
                        }
                        
                    }
                    spreadsheetTarget = spreadsheetTemplate;
                }
            }
            catch
            {
                throw;
            }
        }

        private IEnumerable<JToken> DeserializeObjects(string json)
        {
            try
            {
                Object obj = JsonConvert.DeserializeObject(json);
                JObject jObject = (JObject)obj;
                return jObject.Children();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
