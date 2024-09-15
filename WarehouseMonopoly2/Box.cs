using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMonopoly2
{
    public class Box : Item
    {
        public DateTime? ExpiryDate { get; private set; }
        public DateTime? ProductionDate { get; private set; }

        public Box(double width, double height, double depth, double weight, DateTime? expiryDate = null, DateTime? productionDate = null)
            : base(width, height, depth, weight)
        {
            if (expiryDate.HasValue)
            {
                ExpiryDate = expiryDate;
            }
            else if (productionDate.HasValue)
            {
                ProductionDate = productionDate;
                ExpiryDate = ProductionDate?.AddDays(100);
            }
        }

        public override string ToString()
        {
            return $"Box ID: {ID}, Volume: {Volume}, Weight: {Weight}, Expiry Date: {ExpiryDate?.ToShortDateString()}";
        }
    }
}
