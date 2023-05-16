

using System.Text.Json;

string test = "[\"387320d0-6e54-49c3-a1c4-63be5b9e951d\",\"07982c4d-1309-4d41-b933-12e5c2e1a52b\"]";

List<Guid> result;

result = JsonSerializer.Deserialize<List<Guid>>(test);


Console.WriteLine($"{string.Join(",",result)}");
Console.ReadLine();


string serializedResult = JsonSerializer.Serialize(result);

Console.WriteLine(serializedResult);
Console.ReadLine();




