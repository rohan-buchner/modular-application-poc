using System;
using System.Collections.Generic;
using System.Linq;

namespace Organisations.Core.Domain
{
    public class CompanyRepository
    {
        private readonly Dictionary<int, Company> _companies;

        public CompanyRepository()
        {
            _companies = new Company[]
            {
                new Company(1, "Dundir Mifflin", new DateTime(2021, 01, 01), true),
                new Company(2, "Entertainment720", new DateTime(2021, 01, 01), true),
            }.ToDictionary(t => t.Id);
        }

        public Company GetCompany(int id) => _companies[id];

        public IEnumerable<Company> GetCompanies() => _companies.Values;
    }
}