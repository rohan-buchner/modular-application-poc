using System;

namespace Deliveries.Core.Domain
{
    public record Delivery(int Id, string Name, string Description, DateTime CreatedDate, bool IsActive);
}    