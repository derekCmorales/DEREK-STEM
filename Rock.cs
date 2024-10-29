public class Rock : Cancion
{
    public string Tipo { get; set; }
    public Rock(string titulo, string artista, string duracion, string tipoRock, string path)
       : base(titulo, artista, duracion, path)
    {
        Tipo = tipoRock;
    }
}