using System.Text.Json;
using EstructuraTarea;

HttpClient client = new HttpClient();
var url = "https://jsonplaceholder.typicode.com/todos/";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode(); // me da un status code

string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> PropsTarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

foreach (var prop in PropsTarea)
{
    Console.WriteLine($"\nTitle: {prop.Title} - Completed: {prop.Completed}");
}

Console.WriteLine("\nTAREAS PENDIENTES");
foreach (var prop in PropsTarea)
{
    if (!prop.Completed)
    {
        Console.WriteLine($"UserId: {prop.UserId} - Id: {prop.Id}");
    }
}

Console.WriteLine("\nTAREAS REALIZADAS");
foreach (var prop in PropsTarea)
{
    if (prop.Completed)
    {
        Console.WriteLine($"UserId: {prop.UserId} - Id: {prop.Id}");
    }
}

string rutaReporte = Path.Combine(@"C:\Users\Alumno\Desktop\tl1-tp10-2025-MLucasDelgado\Tareas", "tareas.json");
var writer = new StreamWriter(rutaReporte);
string jsonString = JsonSerializer.Serialize(PropsTarea);
writer.WriteLine(jsonString);
writer.Close();



