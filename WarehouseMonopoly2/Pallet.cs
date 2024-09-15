using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMonopoly2
{
    public class Pallet : Item
    {
        public List<Box> Boxes { get; private set; } = new List<Box>();

        public Pallet(double width, double height, double depth)
            : base(width, height, depth, 30) // вес паллеты по умолчанию 30кг
        { }

        public DateTime? ExpiryDate => Boxes.Any() ? Boxes.Min(b => b.ExpiryDate) : null;
        public override double Weight => Boxes.Sum(b => b.Weight) + 30; // Вес паллеты и коробок
        public override double Volume => base.Volume + Boxes.Sum(b => b.Volume); // Объем паллеты и коробок

        public void AddBox(Box box)
        {
            if (box.Width <= Width && box.Depth <= Depth)
            {
                Boxes.Add(box);
            }
            else
            {
                throw new InvalidOperationException("Коробка превышает размеры паллеты");
            }
        }

        public override string ToString()
        {
            return $"Pallet ID: {ID}, Total Weight: {Weight}, Expiry Date: {ExpiryDate?.ToShortDateString()}, Volume: {Volume}";
        }
    }
}
