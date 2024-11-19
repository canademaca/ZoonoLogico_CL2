using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematicas : MonoBehaviour
{
    [SerializeField] public GameObject[] cinematicas; // Arreglo de GameObjects de las cinemáticas
    [SerializeField] public GameObject ganarCinematica; // Cinemática de ganar
    [SerializeField] public GameObject perderCinematica; // Cinemática de perder

    private int indiceCinematica;
    private string estadoJuego;
    private bool minijuegoActivo = false; // Indicador para saber si el minijuego está activo
    private bool todasCinematicasMostradas = false; // Nuevo indicador para saber si todas las cinemáticas han sido mostradas

    void Start()
    {
        estadoJuego = PlayerPrefs.GetString("EstadoJuego", "Normal");
        indiceCinematica = PlayerPrefs.GetInt("IndiceCinematica", 0);

        // Si ya no hay más cinemáticas, marcamos que todas fueron mostradas
        if (indiceCinematica >= cinematicas.Length)
        {
            todasCinematicasMostradas = true;
        }

        ActivarCinematica();
    }

    void Update()
    {
        // Solo permitimos activar o controlar cinemáticas si el minijuego no está activo y hay cinemáticas disponibles
        if (!minijuegoActivo && !todasCinematicasMostradas)
        {
            // Aquí puedes manejar la lógica de las cinemáticas durante el juego si es necesario
        }
    }

    // Método para activar la cinemática adecuada según el estado del juego
    void ActivarCinematica()
    {
        if (minijuegoActivo) return; // Si el minijuego está activo, no activamos cinemáticas

        if (estadoJuego == "Ganar")
        {
            Debug.Log("Activando cinemática de ganar");
            ganarCinematica.SetActive(true);
        }
        else if (estadoJuego == "Perder")
        {
            Debug.Log("Activando cinemática de perder");
            perderCinematica.SetActive(true);
        }
        else if (indiceCinematica >= 0 && indiceCinematica < cinematicas.Length)
        {
            cinematicas[indiceCinematica].SetActive(true);
        }
        else
        {
            Debug.Log("No hay más cinemáticas para mostrar.");
            todasCinematicasMostradas = true; // Marcamos que no hay más cinemáticas
        }
    }

    public void MostrarSiguienteCinematica()
    {
        if (minijuegoActivo || todasCinematicasMostradas) return; // No avanzamos si el minijuego está activo o si ya no hay más cinemáticas

        if (estadoJuego != "Ganar" && estadoJuego != "Perder")
        {
            if (indiceCinematica < cinematicas.Length)
            {
                cinematicas[indiceCinematica].SetActive(false);
            }

            indiceCinematica++;
            PlayerPrefs.SetInt("IndiceCinematica", indiceCinematica);

            // Guarda el índice actualizado para sincronizar con CambioDeDia
            PlayerPrefs.SetInt("CinematicaNumero", indiceCinematica);

            // Activamos la siguiente cinemática si aún hay disponibles
            if (indiceCinematica < cinematicas.Length)
            {
                ActivarCinematica();
            }
            else
            {
                todasCinematicasMostradas = true;
            }
        }
    }

    // Método que se llama cuando se inicia un minijuego
    public void IniciarMinijuego()
    {
        minijuegoActivo = true;
        PausarCinematicas();
    }

    // Método que se llama cuando se termina un minijuego
    public void TerminarMinijuego()
    {
        minijuegoActivo = false;

        // Solo reanudamos las cinemáticas si aún hay disponibles y no todas fueron mostradas
        if (!todasCinematicasMostradas)
        {
            ActivarCinematica();
        }
    }

    // Método para pausar todas las cinemáticas cuando el minijuego está activo
    void PausarCinematicas()
    {
        foreach (var cinematica in cinematicas)
        {
            cinematica.SetActive(false); // Desactiva todas las cinemáticas mientras el minijuego está activo
        }

        if (ganarCinematica != null) ganarCinematica.SetActive(false);
        if (perderCinematica != null) perderCinematica.SetActive(false);
    }
}
