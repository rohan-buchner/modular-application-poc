using System;

namespace Organisations.Core.Domain
{
    public record User(int Id, int CompanyId, string Username, string DisplayName, DateTime CreatedDate, bool IsActive);
}