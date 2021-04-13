using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SisComWebApi.Models;
using SisComWebApi.Data;
using SisComWebApi.Services;
using SisComWebApi.Services.Exceptions;

namespace SisComWebApi.Controllers
{
    [Route("v1/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices]ProductService context)
        {
            var products =  await context.FindAllAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] ProductService context, int id)
        {
            var products = await context.FindByIdAsAsync(id);
            return products;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] ProductService context, int id)
        {
            var products = await context.FindByCategoryAsync(id);
            return products;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post(
            [FromServices] ProductService context,
            [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                await context.InsertAsync(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Delete([FromServices] ProductService context, int? id)
        {
            try
            {
                if (id == null) { return false; }
                var obj = await context.FindByIdAsAsync(id.Value);
                if (obj == null) { return false; }
                await context.RemoveAsync(id.Value);
                return true;
            }
            catch (IntegrityException)
            {
                return false;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Edit([FromServices] ProductService context, int? id, Product product)
        {
            if(id != product.Id) { return false; }
            try
            {
                await context.UpdateAsync(product);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
