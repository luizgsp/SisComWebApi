using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisComWebApi.Models;
using SisComWebApi.Services;
using SisComWebApi.Services.Exceptions;

namespace SisComWebApi.Controllers
{
    [Route("v1/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Customer>>> Get([FromServices] CustomerService context)
        {
            var customers = await context.FindAllAsync();
            return customers;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> GetById([FromServices] CustomerService context, int id)
        {
            var customer = await context.FindByIdAsAsync(id);
            return customer;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Customer>> Post(
            [FromServices] CustomerService context,
            [FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await context.InsertAsync(customer);
                return customer;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<bool> Delete([FromServices] CustomerService context, int? id)
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
        public async Task<ActionResult<Customer>> Edit([FromServices] CustomerService context, int? id, Customer customer)
        {
            if (id != customer.Id) { BadRequest(ModelState); }
            try
            {
                await context.UpdateAsync(customer);
                return customer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
