using System;

namespace Organisations.Core.Events
{
    public class UserDeleted
    {
        public Guid UserId { get; set; }
    }
}