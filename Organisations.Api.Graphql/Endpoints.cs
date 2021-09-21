using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Organisations.Api.Graphql.Api;
using Organisations.Api.Graphql.Types.Companies;
using Organisations.Api.Graphql.Types.Users;
using Organisations.Core;

namespace Organisations.Api.Graphql
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapOrganisationsEndpoint(this IEndpointRouteBuilder endpoints,
            string path = "/graphql", string schema = null)
        {
            schema ??= new OrganisationsModuleDefinition().ModuleName;
            endpoints.MapGraphQL(path, schema);
            return endpoints;
        }

        public static IRequestExecutorBuilder MapOrganisationQueries(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddQueryType<OrganisationsQuery>()   
                .AddType<CompanyType>()
                .AddType<UserType>();
        }
    }
}