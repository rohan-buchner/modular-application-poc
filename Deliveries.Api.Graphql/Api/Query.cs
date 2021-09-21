using System.Collections.Generic;
using Deliveries.Core.Domain;
using HotChocolate;

namespace Deliveries.Api.Graphql.Api
{
    public class Query
    {
        public IEnumerable<Core.Domain.Delivery> GetDeliveries([Service] DeliveriesRepository repository) =>
            repository.GetDeliveries();

        public Core.Domain.Delivery GetDelivery(int id, [Service] DeliveriesRepository repository) => 
            repository.GetDelivery(id);
    }
}