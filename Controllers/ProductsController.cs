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
            var products =  context.FindAll();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] ProductService context, int id)
        {
            var products = context.FindById(id);
            return products;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] ProductService context, int id)
        {
            var products = context.FindByCategory(id);
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
                context.Insert(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool Delete([FromServices] ProductService context, int? id)
        {
            if (id == null) { return false;  }
            var obj = context.FindById(id.Value);
            if (obj == null) { return false; }
            context.Remove(id.Value);
            return true;

        }
    }
}
