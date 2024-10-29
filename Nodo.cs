public class Nodo<Cancion>
{
    public Cancion Valor { get; set; }
    public Nodo<Cancion> Siguiente { get; set; }

    public Nodo(Cancion valor)
    {
        Valor = valor;
        Siguiente = null;
    }

}