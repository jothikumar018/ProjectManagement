using Microsoft.AspNetCore.Authentication;
using ProjectManagement.Domain.Entities;
using System.Security.Claims;

namespace ProjectManagement.Infrastructure.Security;

public class CustomClaimsTransformation : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        ClaimsIdentity claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(nameof(User.TenentId), Guid.NewGuid().ToString()));
        claimsIdentity.AddClaim(new Claim("DateFormat", "MM/dd/yyyy"));

        principal.AddIdentity(claimsIdentity);
        return Task.FromResult(principal);
    }


}
