using NAudio.Wave;
using System;
using System.Threading;
public class ListaReproduccion
{
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFile;
    public ListasEnlasadas<Cancion> Canciones;
    public ListasEnlasadas<Rap> CancionesRap;
    public ListasEnlasadas<Pop> CancionesPop;
    public ListasEnlasadas<Rock> CancionesRock;
    public Nodo<Cancion> nodoActual;

    public ListaReproduccion()
    {
        Canciones = new ListasEnlasadas<Cancion>();
        CancionesRap = new ListasEnlasadas<Rap>();
        CancionesPop = new ListasEnlasadas<Pop>();
        CancionesRock = new ListasEnlasadas<Rock>();
        outputDevice = new WaveOutEvent();
    }

    public void ReproducirCancion(Cancion cancion)
    {
        try
        {
            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Stop();
                audioFile?.Dispose();
            }

            audioFile = new AudioFileReader(cancion.path);
            outputDevice.Init(audioFile);
            outputDevice.Play();
            Console.WriteLine($"Reproduciendo: {cancion.Titulo} - {cancion.Artista}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al reproducir la canción: {ex.Message}");
        }
    }

    public void ReproducirListaGeneral()
    {
        Canciones.ReproducirRecursivamente(ReproducirCancion);
    }

    public void ReproducirListaRap()
    {
        CancionesRap.ReproducirRecursivamente(ReproducirCancion);
    }

    public void ReproducirListaPop()
    {
        CancionesPop.ReproducirRecursivamente(ReproducirCancion);
    }

    public void ReproducirListaRock()
    {
        CancionesRock.ReproducirRecursivamente(ReproducirCancion);
    }


    public void Pausar()
    {
        if (outputDevice.PlaybackState == PlaybackState.Playing)
        {
            outputDevice.Pause();
            Console.WriteLine("Reproducción pausada.");
        }
    }

    public void Reanudar()
    {
        if (outputDevice.PlaybackState == PlaybackState.Paused)
        {
            outputDevice.Play();
            Console.WriteLine("Reproducción reanudada.");
        }
    }
    public void SiguienteCancion()
    {
        if (nodoActual == null)
        {
            nodoActual = Canciones.ObtenerCabeza();
        }
        else
        {
            nodoActual = nodoActual.Siguiente;

        }

        ReproducirCancion(nodoActual.Valor);
        Console.WriteLine($"Reproduciendo: {nodoActual.Valor.Titulo} - {nodoActual.Valor.Artista}");
    }

    public void CancionAnterior()
    {
        if (nodoActual == null)
        {
            nodoActual = Canciones.ObtenerCabeza();
        }
        else
        {
            nodoActual = ObtenerNodoAnterior(nodoActual);
        }

        ReproducirCancion(nodoActual.Valor);
        Console.WriteLine($"Reproduciendo: {nodoActual.Valor.Titulo} - {nodoActual.Valor.Artista}");
    }

    private Nodo<Cancion> ObtenerNodoAnterior(Nodo<Cancion> nodo)
    {
        Nodo<Cancion> actual = Canciones.ObtenerCabeza();
        while (actual.Siguiente != nodo)
        {
            actual = actual.Siguiente;
        }
        return actual;
    }
}