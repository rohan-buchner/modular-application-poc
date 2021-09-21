using HotChocolate.Types;

namespace Deliveries.Api.Graphql.Types.Delivery
{
    public class DeliveryType : ObjectType<Core.Domain.Delivery>
    {
        protected override void Configure(IObjectTypeDescriptor<Core.Domain.Delivery> descriptor)
        {
            descriptor.Description("Represents all the companies in the system");

            descriptor
                .Field(p => p.Id)
                .Description("Represents the unique ID for the delivery.");

            descriptor
                .Field(p => p.Name)
                .Description("Represents the delivery name.");
            
            descriptor
                .Field(p => p.Description)
                .Description("Represents the delivery description.");
            
            descriptor
                .Field(p => p.CreatedDate)
                .Description("Represents the created date of this record");
            
            descriptor
                .Field(p => p.IsActive)
                .Description("Indicated if this entity is active or not");
        }

        private class Resolvers
        {

        }
    }
}