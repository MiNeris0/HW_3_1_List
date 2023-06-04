namespace HW_3_1_List
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var village = new City() { Name = "Village", Population = 1 };
            var cityCollection = new CustomCollection<City>();
            cityCollection.Add(new City() { Name = "Lviv", Population = 800});
            cityCollection.Add(new City() { Name = "Kyiv", Population = 4000 });
            cityCollection.Add(new City() { Name = "Drohobych", Population = 65 });
            cityCollection.Add(village);

            var array = new City[2]
            {
                new City() { Name = "Boryslav", Population = 33 },
                new City() { Name = "Rivne", Population = 201 }
            };

            cityCollection.AddRange(array);
            cityCollection.RemoveAt(1);
            cityCollection.Remove(village);

            cityCollection.Sort();

            foreach (var city in cityCollection)
            {                
                    Console.WriteLine(city.ToString());
            }
        }
    }
}