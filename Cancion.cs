public class Cancion
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Duracion { get; set; }
    public string path { get; set; }

    public Cancion(string titulo, string artista, string duracion, string path = "")
    {
        Titulo = titulo;
        Artista = artista;
        Duracion = duracion;
        path = path;
    }
}