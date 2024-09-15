using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMonopoly2
{
    public class Item
    {
        public Guid ID { get; private set; } = Guid.NewGuid();
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public virtual double Weight { get; set; }

        public virtual double Volume => Width * Height * Depth;

        public Item(double width, double height, double depth, double weight)
        {
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
        }
    }
}
