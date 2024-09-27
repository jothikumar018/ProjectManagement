using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Common;
using ProjectManagement.API.Controllers.Base;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Domain.Entities;


namespace ProjectManagement.API.Controllers;

public class CustomerController : BaseController
{
    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> Get(Guid id)
    {
        var result = await _customerService.Get(id);
        return new CustomResult<Customer>(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetAll()
    {
        var result = await _customerService.GetAll();
        return new CustomResult<IEnumerable<Customer>>(result);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Customer customer)
    {
        await _customerService.Save(customer);
        return new CustomResult<string>("Saved Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _customerService.Delete(id);
        return new CustomResult<string>("Delete Successfully");
    }

}
