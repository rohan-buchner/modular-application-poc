using System;

namespace Organisations.Core.Events
{
    public class AccountDeleted
    {
        public Guid AccountId { get; set; }
    }
}