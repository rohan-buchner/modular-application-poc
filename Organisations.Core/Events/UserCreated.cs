using System;

namespace Organisations.Core.Events
{
    public class UserCreated
    {
        public Guid UserId { get; set; }
    }
}