using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Organisation;
using Organisations.Api.Graphql.Api;
using Organisations.Api.Graphql.Types.Companies;
using Organisations.Api.Graphql.Types.Users;

namespace Organisations.Api.Graphql
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapOrderinOrganisationsEndpoint(this IEndpointRouteBuilder endpoints,
            string path = "/graphql", string schema = null)
        {
            schema ??= new OrganisationsModuleDefinition().ModuleName;
            endpoints.MapGraphQL(path, schema);
            return endpoints;
        }

        public static IRequestExecutorBuilder MapOrganisationQueries(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddQueryType<Query>()
                .AddType<CompanyType>()
                .AddType<UserType>();
        }
    }
}