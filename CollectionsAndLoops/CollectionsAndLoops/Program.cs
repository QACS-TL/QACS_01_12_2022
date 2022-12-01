
List<string> upcomingCities = new List<string>() { "Paris", "Los Angeles", "Brisbane" };
List<string> olympicCities = new() {"Sydney", "Athens", "Beijing", "London", "Rio", "Tokyo"};

if (!olympicCities.Contains("Paris")){
    olympicCities.AddRange(upcomingCities);
}

//olympicCities.Add("Bognor");
olympicCities.Insert(2, "Bognor");

int bognorIndex = olympicCities.IndexOf("Bognor");
Console.WriteLine("Bognor is at index position {0}", bognorIndex);

string city = olympicCities[1];

olympicCities.Remove("Bognor");
bognorIndex = olympicCities.IndexOf("Bognor");
Console.WriteLine("Bognor is at index position {0}", bognorIndex);

olympicCities.Sort();
foreach(var city in olympicCities)
{
    Console.WriteLine($"{city} ");
}