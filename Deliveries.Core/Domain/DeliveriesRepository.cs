using System;
using System.Collections.Generic;
using System.Linq;

namespace Deliveries.Core.Domain
{
    public class DeliveriesRepository
    {
        private readonly Dictionary<int, Delivery> _delivery;

        public DeliveriesRepository()
        {
            _delivery = new Delivery[]
            {
                new Delivery(1, "Nandos", "", new DateTime(2021, 01, 01), true),
                new Delivery(2, "KFC", "", new DateTime(2021, 01, 01), true),
            }.ToDictionary(t => t.Id);
        }

        public Delivery GetDelivery(int id) => _delivery[id];

        public IEnumerable<Delivery> GetDeliveries() => _delivery.Values;
    }
}