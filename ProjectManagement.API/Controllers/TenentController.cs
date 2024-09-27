using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Common;
using ProjectManagement.API.Controllers.Base;
using ProjectManagement.Application.Interfaces.Services;
using ProjectManagement.Domain.Entities;


namespace ProjectManagement.API.Controllers;

public class TenentController : BaseController
{
    private readonly ITenentService _tenentService;
    public TenentController(ITenentService tenentService)
    {
        _tenentService = tenentService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tenant>> Get(Guid id)
    {
        var result = await _tenentService.Get(id);
        return new CustomResult<Tenant>(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tenant>>> GetAll()
    {
        var result = await _tenentService.GetAll();
        return new CustomResult<IEnumerable<Tenant>>(result);
    }

    [HttpPost]
    public async Task<IActionResult> Save(Tenant tenant)
    {
        await _tenentService.Save(tenant);
        return new CustomResult<string>("Saved Successfully");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tenentService.Delete(id);
        return new CustomResult<string>("Deleted Successfully");
    }
}
