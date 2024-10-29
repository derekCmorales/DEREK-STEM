public class ListasEnlasadas<T>
{
    private Nodo<T> Cabeza;

    public ListasEnlasadas()
    {
        Cabeza = null;
    }

    public Nodo<T> ObtenerCabeza()
    {
        return Cabeza;
    }

    public void Agregar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
            Cabeza.Siguiente = Cabeza;
        }
        else
        {
            Nodo<T> actual = Cabeza;
            while (actual.Siguiente != Cabeza)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
            nuevoNodo.Siguiente = Cabeza;
        }
    }

    public void Eliminar(T valor)
    {
        if (Cabeza == null) return;

        if (Cabeza.Siguiente == Cabeza && Cabeza.Valor.Equals(valor))
        {
            Cabeza = null;
            return;
        }

        if (Cabeza.Valor.Equals(valor))
        {
            Nodo<T> actual = Cabeza;
            while (actual.Siguiente != Cabeza)
            {
                actual = actual.Siguiente;
            }
            Cabeza = Cabeza.Siguiente;
            actual.Siguiente = Cabeza;
            return;
        }

        Nodo<T> anterior = Cabeza;
        while (anterior.Siguiente != Cabeza && !anterior.Siguiente.Valor.Equals(valor))
        {
            anterior = anterior.Siguiente;
        }

        if (anterior.Siguiente != Cabeza)
        {
            anterior.Siguiente = anterior.Siguiente.Siguiente;
        }
    }

    public void Imprimir()
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo<T> actual = Cabeza;
        do
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Siguiente;
        } while (actual != Cabeza);
    }

    public void Buscar(T valor)
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo<T> actual = Cabeza;
        bool encontrado = false;
        do
        {
            if (actual.Valor.Equals(valor))
            {
                Console.WriteLine("Elemento encontrado:");
                Console.WriteLine(actual.Valor);
                encontrado = true;
                break;
            }
            actual = actual.Siguiente;
        } while (actual != Cabeza);

        if (!encontrado)
        {
            Console.WriteLine("Elemento no encontrado.");
        }
    }

    public void Modificar(T valor)
    {
        if (Cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo<T> actual = Cabeza;
        bool modificado = false;
        do
        {
            if (actual.Valor.Equals(valor))
            {
                actual.Valor = valor;
                Console.WriteLine("Elemento modificado exitosamente.");
                modificado = true;
                break;
            }
            actual = actual.Siguiente;
        } while (actual != Cabeza);

        if (!modificado)
        {
            Console.WriteLine("Elemento no encontrado para modificar.");
        }
    }

    public void ReproducirRecursivamente(Action<T> accionReproducir)
    {
        if (Cabeza == null) return;
        ReproducirNodo(Cabeza, Cabeza, accionReproducir);
    }

    private void ReproducirNodo(Nodo<T> nodoActual, Nodo<T> cabeza, Action<T> accionReproducir)
    {
        if (nodoActual == null || (nodoActual.Siguiente == cabeza && nodoActual != cabeza)) return;

        accionReproducir(nodoActual.Valor);

        if (nodoActual.Siguiente != cabeza)
        {
            ReproducirNodo(nodoActual.Siguiente, cabeza, accionReproducir);
        }
    }

    public bool EstaVacia()
    {
        return Cabeza == null;
    }

    public int Contar()
    {
        if (Cabeza == null) return 0;

        int contador = 0;
        Nodo<T> actual = Cabeza;
        do
        {
            contador++;
            actual = actual.Siguiente;
        } while (actual != Cabeza);

        return contador;
    }
}