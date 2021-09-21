using System;

namespace Organisation.Domain
{
    public record User(int Id, int CompanyId, string Username, string DisplayName, DateTime CreatedDate, bool IsActive);
}