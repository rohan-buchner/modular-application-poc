using HotChocolate.Types;
using Organisation.Domain;

namespace Organisations.Api.Graphql.Types.Users
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents all the users in the system");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the user.");

            descriptor
                .Field(p => p.Username)
                .Description("Represents the username of this entity.");
            
            descriptor
                .Field(p => p.DisplayName)
                .Description("Represents the display name of this entity.");
            
            descriptor
                .Field(p => p.CreatedDate)
                .Description("Represents the created date of this record");
            
            descriptor
                .Field(p => p.IsActive)
                .Description("Indicated if this entity is active of not");
        }

        private class Resolvers
        {

        }
    }
}