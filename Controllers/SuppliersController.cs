using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisComWebApi.Models;
using SisComWebApi.Services;
using SisComWebApi.Services.Exceptions;

namespace SisComWebApi.Controllers
{
    [Route("v1/supplier")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Supplier>>> Get([FromServices] SupplierService context)
        {
            var suppliers = await context.FindAllAsync();
            return suppliers;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Supplier>> GetById([FromServices] SupplierService context, int id)
        {
            var supplier = await context.FindByIdAsAsync(id);
            return supplier;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Supplier>> Post(
            [FromServices] SupplierService context,
            [FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await context.InsertAsync(supplier);
                return supplier;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Delete([FromServices] SupplierService context, int? id)
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
        public async Task<ActionResult<Supplier>> Edit([FromServices] SupplierService context, int? id, Supplier supplier)
        {
            if (id != supplier.Id) { BadRequest(ModelState); }
            try
            {
                await context.UpdateAsync(supplier);
                return supplier;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
