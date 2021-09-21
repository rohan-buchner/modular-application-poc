using Deliveries.Api.Graphql.Api;
using Deliveries.Api.Graphql.Types.Delivery;
using Deliveries.Core;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Deliveries.Api.Graphql
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapDeliveriesEndpoint(this IEndpointRouteBuilder endpoints,
            string path = "/graphql", string schema = null)
        {
            schema ??= new DeliveriesModuleDefinition().ModuleName;
            endpoints.MapGraphQL(path, schema);
            return endpoints;
        }

        public static IRequestExecutorBuilder MapDeliveriesQueries(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddQueryType<Query>()
                .AddMutationType<Mutations>()
                .AddType<DeliveryType>();
        }
    }
}