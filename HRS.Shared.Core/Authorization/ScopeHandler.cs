using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace HRS.Shared.Core.Authorization;

public class ScopeHandler : AuthorizationHandler<ScopeRequirement>
{
  protected override Task HandleRequirementAsync(
      AuthorizationHandlerContext context,
      ScopeRequirement requirement)
  {
    var scopeClaim = context.User.FindFirst(c =>
        c.Type == "scope" &&
        c.Issuer == requirement.Issuer);

    if (scopeClaim == null)
      return Task.CompletedTask;

    var scopes = scopeClaim.Value.Split(' ');

    if (scopes.Any(s =>
            s == requirement.Scope))
      context.Succeed(requirement);

    return Task.CompletedTask;
  }
}
