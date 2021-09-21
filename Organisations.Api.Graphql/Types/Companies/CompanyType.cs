using HotChocolate.Types;
using Organisations.Core.Domain;

namespace Organisations.Api.Graphql.Types.Companies
{
    public class CompanyType : ObjectType<Company>
    {
        protected override void Configure(IObjectTypeDescriptor<Company> descriptor)
        {
            descriptor.Description("Represents all the companies in the system");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the company / organisation.");

            descriptor
                .Field(p => p.Name)
                .Description("Represents the name company / organisation.");
            
            descriptor
                .Field(p => p.CreatedDate)
                .Description("Represents the created date of this record");
            
            descriptor
                .Field(p => p.IsActive)
                .Description("Indicated if this entity is active or not");
        }
    }
}