using System.Text.Json;
using anime;

HttpClient client = new HttpClient();

var url = "https://api.jikan.moe/v4/anime?q=naruto";

try
{
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();

    AnimeResponse animeResponse = JsonSerializer.Deserialize<AnimeResponse>(responseBody);

    foreach (var anime in animeResponse.Data.Take(10)) // Si quiero toda la api simplemente elimino el take
    {
        Console.WriteLine($"{anime.Title}");
        Console.WriteLine($"Episodes: {anime.Episodes}");
        Console.WriteLine($"Rating: {anime.Rating}");
        Console.WriteLine($"Score: {anime.Score}");
        Console.WriteLine($"Year: {anime.Year}");
        Console.WriteLine($"Synopsis: {anime.Synopsis}\n");
        Console.WriteLine("--------------------------------------\n");
    }

    string textoAGuardar = JsonSerializer.Serialize(animeResponse); // Convierte un objeto de C# → en un string JSON.

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

    GuardarArchivoTexto("Naruto.json", textoAGuardar);
}
catch (HttpRequestException e)
{
    Console.WriteLine($"Error en la solicitud HTTP: {e.Message}");
}