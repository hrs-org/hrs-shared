using System.Threading.Tasks;
using HRS.Shared.Core.Dtos.User;

namespace HRS.Shared.Core.Interfaces;
#nullable enable

public interface IUserContextService
{
    int GetUserId();
    string? GetEmail();
    Task<UserResponseDto> GetUserAsync();
}