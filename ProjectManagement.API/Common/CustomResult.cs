using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProjectManagement.Shared.Common;
using System.Net;
using System.Text.Json;

namespace ProjectManagement.API.Common;

public sealed class CustomResult<T> : ActionResult where T : class
{
    private readonly T? _value;

    public CustomResult()
    {

    }

    public CustomResult([ActionResultObjectValue] T? value)
    {
        _value = value;
    }

    public async override Task ExecuteResultAsync(ActionContext context)
    {
        var response = context.HttpContext.Response;
        response.ContentType = "application/json";

        var resultResponse = new ResponseModel<T>
        {
            Success = true,
            StatusCode = (int)HttpStatusCode.OK,
            Response = _value
        };

        response.StatusCode = resultResponse.StatusCode;

        var result = JsonSerializer.Serialize(resultResponse);
        await response.WriteAsync(result);
    }
}
