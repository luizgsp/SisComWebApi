using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisComWebApi.Models;
using SisComWebApi.Services;
using SisComWebApi.Services.Exceptions;

namespace SisComWebApi.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get([FromServices] CategoryService context)
        {
            var categories = await context.FindAllAsync();
            return categories;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById([FromServices] CategoryService context, int id)
        {
            var category = await context.FindByIdAsAsync(id);
            return category;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] CategoryService context,
            [FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                await context.InsertAsync(category);
                return category;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Delete([FromServices] CategoryService context, int? id)
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
        public async Task<ActionResult<Category>> Edit([FromServices] CategoryService context, int? id, Category category)
        {
            if (id != category.Id) { BadRequest(ModelState); }
            try
            {
                await context.UpdateAsync(category);
                return category;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}