using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematicas : MonoBehaviour
{
    [SerializeField] public GameObject[] cinematicas; // Arreglo de GameObjects de las cinem�ticas
    [SerializeField] public GameObject ganarCinematica; // Cinem�tica de ganar
    [SerializeField] public GameObject perderCinematica; // Cinem�tica de perder
    [SerializeField] private GameObject ANALYTICS;
    
    private int indiceCinematica;
    private string estadoJuego;
    private bool minijuegoActivo = false; // Indicador para saber si el minijuego est� activo
    private bool todasCinematicasMostradas = false; // Nuevo indicador para saber si todas las cinem�ticas han sido mostradas

    void Start()
    {
        estadoJuego = PlayerPrefs.GetString("EstadoJuego", "Normal");
        indiceCinematica = PlayerPrefs.GetInt("IndiceCinematica", 0);
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");
        // Si ya no hay m�s cinem�ticas, marcamos que todas fueron mostradas
        if (indiceCinematica >= cinematicas.Length)
        {
            todasCinematicasMostradas = true;
        }

        ActivarCinematica();
    }

    void Update()
    {
        // Solo permitimos activar o controlar cinem�ticas si el minijuego no est� activo y hay cinem�ticas disponibles
        if (!minijuegoActivo && !todasCinematicasMostradas)
        {
            // Aqu� puedes manejar la l�gica de las cinem�ticas durante el juego si es necesario
        }
    }

    // M�todo para activar la cinem�tica adecuada seg�n el estado del juego
    void ActivarCinematica()
    {
        if (minijuegoActivo) return; // Si el minijuego est� activo, no activamos cinem�ticas

        if (estadoJuego == "Ganar")
        {
            Debug.Log("Activando cinem�tica de ganar");
            ganarCinematica.SetActive(true);
            ANALYTICS.SendMessage("ganar");
        }
        else if (estadoJuego == "Perder")
        {
            Debug.Log("Activando cinem�tica de perder");
            perderCinematica.SetActive(true);
            ANALYTICS.SendMessage("game_over");
        }
        else if (indiceCinematica >= 0 && indiceCinematica < cinematicas.Length)
        {
            cinematicas[indiceCinematica].SetActive(true);
        }
        else
        {
            Debug.Log("No hay m�s cinem�ticas para mostrar.");
            todasCinematicasMostradas = true; // Marcamos que no hay m�s cinem�ticas
        }
    }

    public void MostrarSiguienteCinematica()
    {
        if (minijuegoActivo || todasCinematicasMostradas) return; // No avanzamos si el minijuego est� activo o si ya no hay m�s cinem�ticas

        if (estadoJuego != "Ganar" && estadoJuego != "Perder")
        {
            if (indiceCinematica < cinematicas.Length)
            {
                cinematicas[indiceCinematica].SetActive(false);
            }

            indiceCinematica++;
            PlayerPrefs.SetInt("IndiceCinematica", indiceCinematica);

            // Guarda el �ndice actualizado para sincronizar con CambioDeDia
            PlayerPrefs.SetInt("CinematicaNumero", indiceCinematica);

            // Activamos la siguiente cinem�tica si a�n hay disponibles
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

    // M�todo que se llama cuando se inicia un minijuego
    public void IniciarMinijuego()
    {
        minijuegoActivo = true;
        PausarCinematicas();
         ANALYTICS.SendMessage("minigame");
    }

    // M�todo que se llama cuando se termina un minijuego
    public void TerminarMinijuego()
    {
        minijuegoActivo = false;

        // Solo reanudamos las cinem�ticas si a�n hay disponibles y no todas fueron mostradas
        if (!todasCinematicasMostradas)
        {
            ActivarCinematica();
        }
    }

    // M�todo para pausar todas las cinem�ticas cuando el minijuego est� activo
    void PausarCinematicas()
    {
        foreach (var cinematica in cinematicas)
        {
            cinematica.SetActive(false); // Desactiva todas las cinem�ticas mientras el minijuego est� activo
        }

        if (ganarCinematica != null) ganarCinematica.SetActive(false);
        if (perderCinematica != null) perderCinematica.SetActive(false);
    }
}
