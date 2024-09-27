using Microsoft.AspNetCore.Http;
using ProjectManagement.Application.Interfaces.Security;
using System.Security.Claims;

namespace ProjectManagement.Infrastructure.Security;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId => new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);

    public Guid TenentId
    {
        get
        {
            if (_httpContextAccessor.HttpContext?.Request.Headers.ContainsKey("TenentId") == true)
            {
                return new Guid(_httpContextAccessor.HttpContext?.Request.Headers["TenentId"]);
            }
            else if (_httpContextAccessor.HttpContext?.User?.FindFirstValue("TenentId") != null)
                return new Guid(_httpContextAccessor.HttpContext?.User?.FindFirstValue("TenentId") ?? string.Empty);
            else
            {
                return Guid.Empty;
            }
        }
    }

    public DateTimeOffset CurrentUserTime
    {
        get
        {
            if (_httpContextAccessor.HttpContext?.Request.Headers.ContainsKey("Userdate") == true)
            {
                string x = _httpContextAccessor.HttpContext?.Request.Headers["Userdate"].ToString();
                DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(x);
                return dateTimeOffset;
            }           
            else
            {
                return DateTimeOffset.Now;
            }
        }
    }

    public string DateFormat
    {
        get
        {
            string dateFormat = "MM/dd/yyyy";

            if (_httpContextAccessor.HttpContext?.User?.FindFirstValue("DateFormat") == "")
                return dateFormat;
            string value = _httpContextAccessor.HttpContext?.User?.FindFirstValue("DateFormat") ?? dateFormat;
            return value;

        }
    }
}
