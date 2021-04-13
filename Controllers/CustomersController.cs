using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisComWebApi.Data;
using SisComWebApi.Models;

namespace SisComWebApi.Controllers
{
    [Route("v1/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Supplier>>> Get([FromServices] DataContext context)
        {
            var suppliers = await context.Suppliers.ToListAsync();
            return suppliers;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Supplier>> GetById([FromServices] DataContext context, int id)
        {
            var suppliers = await context.Suppliers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return suppliers;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Supplier>> Post(
            [FromServices] DataContext context,
            [FromBody] Supplier model)
        {
            if (ModelState.IsValid)
            {
                context.Suppliers.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
