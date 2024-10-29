using NAudio.Wave;
using System;
using System.Threading;

ListaReproduccion lista = new ListaReproduccion();
bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("Derek'Stem");
    Console.WriteLine("1. Agregar canción");
    Console.WriteLine("2. Reproducir lista");
    Console.WriteLine("3. Mostrar canciones");
    Console.WriteLine("4. Eliminar cancións");
    Console.WriteLine("5. MEnu de canciones");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine()!;

    switch (opcion)
    {
        case "1":
            AgregarCancion(lista);
            break;
        case "2":
            Console.WriteLine("== Listas de musica ==");
            Console.WriteLine("1. Reproducir lista de Rock");
            Console.WriteLine("2. Reproducir lista de Pop");
            Console.WriteLine("3. Reproducir lista de Rap");
            Console.WriteLine("4. Reproducir lista General");
            Console.WriteLine("5. Regresar al menu principal ");
            Console.Write("Seleccione una opción: ");
            string opcionLista = Console.ReadLine();
            switch (opcionLista)
            {
                case "1":
                    lista.ReproducirListaRock();
                    break;
                case "2":
                    lista.ReproducirListaPop();
                    break;
                case "3":
                    lista.ReproducirListaRap();
                    break;
                case "4":
                    lista.ReproducirListaGeneral();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            break;

        case "3":
            MostrarCanciones(lista);
            break;
        case "4":
            EliminarCancion(lista);
            break;
        case "5":
            ControlarReproduccion(lista);
            break;
        case "6":
            salir = true;
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    if (!salir)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

void AgregarCancion(ListaReproduccion lista)
{
    Console.WriteLine("=== Agregar Canción ===");
    Console.WriteLine("Seleccione el género:");
    Console.WriteLine("1. Rock");
    Console.WriteLine("2. Pop");
    Console.WriteLine("3. Rap");

    string genero = Console.ReadLine()!;

    Console.Write("Título: ");
    string titulo = Console.ReadLine()!;
    Console.Write("Artista: ");
    string artista = Console.ReadLine();
    Console.Write("Duración (segundos): ");
    string duracion = Console.ReadLine()!;
    Console.Write("Ruta del archivo: ");
    string rutaArchivo = Console.ReadLine();

    Cancion cancion;

    switch (genero)
    {
        case "1":
            Console.Write("Tipo de Rock");
            string tipoRock = "Rock";
            cancion = new Rock(titulo, artista, duracion, tipoRock, rutaArchivo);
            lista.CancionesRock.Agregar((Rock)cancion);
            break;
        case "2":
            Console.Write("Tipo de Pop ");
            string tipoPop = "Pop";
            cancion = new Pop(titulo, artista, duracion, tipoPop, rutaArchivo);
            lista.CancionesPop.Agregar((Pop)cancion);
            break;
        case "3":
            Console.Write("Tipo de Rap: ");
            string tipoRap = "Rap";
            cancion = new Rap(titulo, artista, duracion, tipoRap, rutaArchivo);
            lista.CancionesRap.Agregar((Rap)cancion);
            break;
        default:
            Console.WriteLine("Género no válido");
            return;
    }

    lista.Canciones.Agregar(cancion);
    Console.WriteLine("Canción agregada exitosamente!");
}

void MostrarCanciones(ListaReproduccion lista)
{
    Console.WriteLine("=== Lista de Canciones ===");
    lista.Canciones.Imprimir();
}

void EliminarCancion(ListaReproduccion lista)
{
    Console.WriteLine("=== Eliminar Canción ===");
    Console.Write("Título de la canción a eliminar: ");
    string titulo = Console.ReadLine();
    Console.Write("Artista: ");
    string artista = Console.ReadLine();

    Cancion cancionAEliminar = new Cancion(titulo, artista, "", "");
    lista.Canciones.Eliminar(cancionAEliminar);
    lista.CancionesRock.Eliminar(new Rock(titulo, artista, "", "", ""));
    lista.CancionesPop.Eliminar(new Pop(titulo, artista, "", "", ""));
    lista.CancionesRap.Eliminar(new Rap(titulo, artista, "", "", ""));
    Console.WriteLine("Canción eliminada exitosamente!");
}
static void ControlarReproduccion(ListaReproduccion lista)
{
    bool salirControl = false;

    while (!salirControl)
    {
        Console.Clear();
        Console.WriteLine("=== Control de Reproducción ===");
        Console.WriteLine("1. Pausar");
        Console.WriteLine("2. Reanudar");
        Console.WriteLine("3. Siguiente canción");
        Console.WriteLine("4. Canción anterior");
        Console.WriteLine("5. Volver al menú principal");
        Console.Write("Seleccione una opción: ");

        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                lista.Pausar();
                break;
            case "2":
                lista.Reanudar();
                break;
            case "3":
                lista.SiguienteCancion();
                break;
            case "4":
                lista.CancionAnterior();
                break;
            case "5":
                salirControl = true;
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }

        if (!salirControl)
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}