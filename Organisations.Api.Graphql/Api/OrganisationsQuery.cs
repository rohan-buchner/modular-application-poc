using System.Collections.Generic;
using HotChocolate;
using Organisations.Core.Domain;

namespace Organisations.Api.Graphql.Api
{
    [GraphQLDescription("Organisations Queries")]
    public class OrganisationsQuery
    {
        [GraphQLDescription("Get the users")]
        public IEnumerable<User> GetUsers([Service] UserRepository repository) =>
            repository.GetUsers();
        
        [GraphQLDescription("Get a user")]
        public User GetUser(int id, [Service] UserRepository repository) => 
            repository.GetUser(id);
        
        [GraphQLDescription("Get the companies")]
        public IEnumerable<Company> GetCompanies([Service] CompanyRepository repository) =>
            repository.GetCompanies();
        
        [GraphQLDescription("Get a companies")]
        public Company GetCompany(int id, [Service] CompanyRepository repository) => 
            repository.GetCompany(id);
        
        [GraphQLDescription("Get employees")]
        public IEnumerable<User> GetEmployees(int companyId, [Service] UserRepository repository) => 
            repository.GetCompanyUsers(companyId);
    }
}