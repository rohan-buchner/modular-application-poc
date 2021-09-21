using System;

namespace Organisation.Domain
{
    public record Company(int Id, string Name, DateTime CreatedDate, bool IsActive);
}    