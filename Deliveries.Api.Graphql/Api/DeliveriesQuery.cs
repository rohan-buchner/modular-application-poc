using System.Collections.Generic;
using Deliveries.Core.Domain;
using HotChocolate;

namespace Deliveries.Api.Graphql.Api
{
    [GraphQLDescription("Deliveries Queries")]
    public class DeliveriesQuery
    {
        [GraphQLDescription("Get The Deliveries")]
        public IEnumerable<Delivery> GetDeliveries([Service] DeliveriesRepository repository) =>
            repository.GetDeliveries();
    }
}