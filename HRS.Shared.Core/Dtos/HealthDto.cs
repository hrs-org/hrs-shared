using System;

namespace HRS.Shared.Core.Dtos;

public class HealthCheckDto
{
    public required string Status { get; set; }
    public required DateTime Timestamp { get; set; }
    public required string Environment { get; set; }
}