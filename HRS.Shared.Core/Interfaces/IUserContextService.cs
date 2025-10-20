using System.Threading.Tasks;
using HRS.Shared.Core.Dtos;

namespace HRS.Shared.Core.Interfaces;
#nullable enable

public interface IUserContextService
{
    int GetUserId();
    int GetStoreId();
    string? GetEmail();
    Task<UserResponseDto> GetUserAsync();
}