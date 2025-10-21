using System;
using System.Collections.Generic;

namespace HRS.Shared.Core.Dtos;
#nullable enable

public class PackageItemResponseDto
{
    public string ItemId { get; set; } = string.Empty;
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

public class PackageRateResponseDto
{
    public string Id { get; set; } = string.Empty;
    public int MinDays { get; set; }
    public decimal DailyRate { get; set; }
    public bool IsActive { get; set; }
}

public class PackageResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string StoreId { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }

    public List<PackageItemResponseDto>? Items { get; set; }
    public List<PackageRateResponseDto>? Rates { get; set; }
}