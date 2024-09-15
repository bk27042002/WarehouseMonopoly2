using WarehouseMonopoly2;

class Program
{
    static void Main(string[] args)
    {
        // Генерация данных для тестирования
        var pallets = GenerateData();

        // Группировка и сортировка по сроку годности и весу паллет
        var groupedPallets = pallets
            .Where(p => p.ExpiryDate.HasValue)
            .GroupBy(p => p.ExpiryDate)
            .OrderBy(g => g.Key)
            .Select(g => new
            {
                ExpiryDate = g.Key,
                Pallets = g.OrderBy(p => p.Weight)
            });

        Console.WriteLine("Паллеты, сгруппированные по сроку годности, отсортированные по весу:");
        foreach (var group in groupedPallets)
        {
            Console.WriteLine($"\nСрок годности: {group.ExpiryDate?.ToShortDateString()}");
            foreach (var pallet in group.Pallets)
            {
                Console.WriteLine(pallet);
            }
        }

        // 3 паллеты с коробками с наибольшим сроком годности, отсортированные по объему
        var top3Pallets = pallets
            .Where(p => p.Boxes.Any() && p.ExpiryDate.HasValue)
            .OrderByDescending(p => p.ExpiryDate)
            .ThenBy(p => p.Volume)
            .Take(3);

        Console.WriteLine("\nТоп 3 паллеты с наибольшим сроком годности, отсортированные по объему:");
        foreach (var pallet in top3Pallets)
        {
            Console.WriteLine(pallet);
        }
    }

    static List<Pallet> GenerateData()
    {
        var pallets = new List<Pallet>();

        // Создаем несколько коробок с разными параметрами
        var box1 = new Box(1, 1, 1, 10, productionDate: DateTime.Parse("2023-01-01"));
        var box2 = new Box(1.5, 1.5, 1.5, 15, expiryDate: DateTime.Parse("2024-01-01"));
        var box3 = new Box(2, 2, 2, 20, productionDate: DateTime.Parse("2023-02-01"));

        // Создаем паллеты и добавляем коробки
        var pallet1 = new Pallet(3, 2, 2);
        pallet1.AddBox(box1);
        pallet1.AddBox(box2);

        var pallet2 = new Pallet(3, 3, 3);
        pallet2.AddBox(box3);

        pallets.Add(pallet1);
        pallets.Add(pallet2);

        return pallets;
    }
}
