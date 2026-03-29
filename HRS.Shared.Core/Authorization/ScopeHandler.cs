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

public sealed class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
  protected override Task HandleRequirementAsync(
      AuthorizationHandlerContext context,
      PermissionRequirement requirement)
  {
    // Auth0 can emit granular permissions in `permissions` or in space-separated `scope`.
    var permissions = context.User.FindAll("permissions").Select(c => c.Value);
    var hasPermissionClaim = permissions.Any(p => string.Equals(p, requirement.Permission, StringComparison.Ordinal));

    var scopeClaims = context.User.FindAll("scope").Select(c => c.Value);
    var hasScopeClaim = scopeClaims
        .SelectMany(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        .Any(s => string.Equals(s, requirement.Permission, StringComparison.Ordinal));

    if (hasPermissionClaim || hasScopeClaim)
    {
      context.Succeed(requirement);
    }

    return Task.CompletedTask;
  }
}
