using System.ComponentModel.DataAnnotations;
using HRS.Shared.Core.Enums;

namespace HRS.Shared.Core.Dtos;
#nullable enable

public sealed class CreateItemMaintenanceRequestDto
{
    [Required] public required string ItemId { get; set; }
    [Required] public required string RentalOrderId { get; set; }
    public ItemMaintenanceType Type { get; set; }
    public int Quantity { get; set; }
    public string? Remarks { get; set; }
}

public class FixItemMaintenanceRequestDto
{
    [Required] public string Id { get; set; } = string.Empty;
    [Required] public int QuantityFixed { get; set; }
    public string? Remarks { get; set; }
}

public class ItemMaintenanceResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string ItemId { get; set; } = string.Empty;
    public string RentalOrderId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int? QuantityFixed { get; set; }
    public string Remarks { get; set; } = string.Empty;
}
