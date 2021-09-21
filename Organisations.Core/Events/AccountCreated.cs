using System;

namespace Organisations.Core.Events
{
    public class AccountCreated
    {
        public Guid AccountId { get; set; }
    }
}