using System;
using Microsoft.AspNetCore.Authorization;

namespace HRS.Shared.Core.Authorization;

public class ScopeRequirement : IAuthorizationRequirement
{
  public string Scope { get; set; }
  public string Issuer { get; set; }

  public ScopeRequirement(string scope, string issuer)
  {
    Scope = scope ?? throw new ArgumentNullException(nameof(scope));
    Issuer = $"https://{issuer}/";
  }
}
