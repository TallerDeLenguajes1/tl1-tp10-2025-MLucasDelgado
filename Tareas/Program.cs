using System.Text.Json;
using EstructuraTarea;

HttpClient client = new HttpClient();
var url = "https://jsonplaceholder.typicode.com/todos/";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode(); // me da un status code

string responseBody = await response.Content.ReadAsStringAsync();
List<Tarea> PropsTarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

var tareasPendientes = new List<Tarea>();
var tareasCompletadas = new List<Tarea>();

foreach (var prop in PropsTarea)
{
    if (prop.Completed)
        tareasCompletadas.Add(prop);
    else
        tareasPendientes.Add(prop);
}

Console.WriteLine("\nTAREAS PENDIENTES:");
foreach (var tarea in tareasPendientes)
{
    Console.WriteLine($"UserId: {tarea.UserId} - Id: {tarea.Id} - Title: {tarea.Title}");
}

Console.WriteLine("\nTAREAS REALIZADAS:");
foreach (var tarea in tareasCompletadas)
{
    Console.WriteLine($"UserId: {tarea.UserId} - Id: {tarea.Id} - Title: {tarea.Title}");
}

string textoAGuardar = JsonSerializer.Serialize(PropsTarea);

void GuardarArchivoTexto(string nombreArchivo, string datos)
{
    using (var archivo = new FileStream(nombreArchivo, FileMode.Create))
    {
        using (var strWriter = new StreamWriter(archivo)) // StreamWriter sirve para escribir texto dentro del FileStream
        {
            strWriter.Write(datos);
        }
    }
}

GuardarArchivoTexto("tareas.json", textoAGuardar);
