using System.Collections.Generic;
using HotChocolate;
using Organisation.Domain;

namespace Organisations.Api.Graphql.Api
{
    public class Query
    {
        public IEnumerable<User> GetUsers([Service] UserRepository repository) =>
            repository.GetUsers();

        public User GetUser(int id, [Service] UserRepository repository) => 
            repository.GetUser(id);
        
        public IEnumerable<Company> GetCompanies([Service] CompanyRepository repository) =>
            repository.GetCompanies();

        public Company GetCompany(int id, [Service] CompanyRepository repository) => 
            repository.GetCompany(id);
        
        public IEnumerable<User> GetEmployees(int companyId, [Service] UserRepository repository) => 
            repository.GetCompanyUsers(companyId);
    }
}