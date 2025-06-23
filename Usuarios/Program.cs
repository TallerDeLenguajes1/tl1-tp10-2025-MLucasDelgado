using System.Text.Json;
using usuarios;

class Program
{
    // static significa que existe una sola instancia de este objeto para toda la aplicación.
    // readonly significa que la variable no puede ser reasignada después de creada.
    static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        var url = "https://jsonplaceholder.typicode.com/users/";

        try
        {
            var propsUsuarios = new List<Usuario>();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync(); // me trae todo el contenido
            List<Usuario> Usuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody); // Deserialize convierte un texto JSON → a un objeto de C#.

            // Take(5) → Te da los primeros 5.
            // TakeLast(5) → Te da los últimos 5.
            foreach (var usuario in Usuarios.Take(5))
            {
                Console.WriteLine($"- Name: {usuario.Name} \n- Email: {usuario.Email} \n- Address: {usuario.Address.Street}, {usuario.Address.Suite}, {usuario.Address.City}, {usuario.Address.Zipcode}\n");
            }

            string textoAGuardar = JsonSerializer.Serialize(Usuarios); // Convierte un objeto de C# → en un string JSON.

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

            GuardarArchivoTexto("usuarios.json", textoAGuardar);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error en la solicitud: {e.Message}");
        }
    }
}