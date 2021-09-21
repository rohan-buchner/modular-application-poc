using System;

namespace Organisations.Core.Domain
{
    public record Company(int Id, string Name, DateTime CreatedDate, bool IsActive);
}    