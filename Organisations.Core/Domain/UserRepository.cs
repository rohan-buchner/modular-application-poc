using System;
using System.Collections.Generic;
using System.Linq;

namespace Organisation.Domain
{
    public class UserRepository
    {
        private readonly Dictionary<int, User> _users;

        public UserRepository()
        {
            _users = new User[]
            {
                new User(1, 1, "ron_swanson", "Ron Swanson", new DateTime(2021, 01, 01), true),
                new User(2, 1, "april_ludgate", "April Ludgate", new DateTime(2021, 01, 01), true),
                new User(3, 1, "leslie_knoppe", "Laslie Knoppe", new DateTime(2021, 01, 01), true),
                new User(4, 1, "andy_dwyer", "Andy Dwyer", new DateTime(2021, 01, 01), true),
                new User(5, 1, "ben_wyatt", "Benn Wyatt", new DateTime(2021, 01, 01), true),
                new User(6, 1, "ann_perkins", "Ann Perkins", new DateTime(2021, 01, 01), true),
                new User(7, 2, "jean_ralphio_saperstein", "Jean-Ralphio Saperstein", new DateTime(2021, 01, 01), true),
                new User(8, 1, "jerry_gergich", "Jerry Gergich", new DateTime(2021, 01, 01), true),
                new User(9, 1, "tom_haverford", "Tom Haverford", new DateTime(2021, 01, 01), true),
                new User(10, 1, "chris_treager", "Chris Treager", new DateTime(2021, 01, 01), true),
            }.ToDictionary(t => t.Id);
        }

        public IEnumerable<User> GetCompanyUsers(int companyId) =>
            _users.Where(o => o.Value.CompanyId == companyId).Select(o => o.Value);

        public User GetUser(int id) => _users[id];

        public IEnumerable<User> GetUsers() => _users.Values;
    }
}