public class Pop : Cancion
{
    public string Tipo { get; set; }
    public Pop(string titulo, string artista, string duracion, string tipoPop, string path)
       : base(titulo, artista, duracion, path)
    {
        Tipo = tipoPop;
    }
}