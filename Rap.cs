public class Rap : Cancion
{
    public string Tipo { get; set; }
    public Rap(string titulo, string artista, string duracion, string tipoRap, string path)
       : base(titulo, artista, duracion, path)
    {
        Tipo = tipoRap;
    }
}