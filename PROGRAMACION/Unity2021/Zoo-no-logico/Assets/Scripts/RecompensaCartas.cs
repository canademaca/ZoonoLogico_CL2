using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecompensaCartas : MonoBehaviour
{
    // Referencias a los botones en el Inspector
    public GameObject buttonCarpincho;
    public GameObject buttonMonedas250;
    public GameObject buttonMonedas2000;
    public GameObject buttonMonedas4000;
    public GameObject buttonCocodrilo;
    public GameObject buttonSerpiente;

    // Referencia para almacenar qué recompensas se han reclamado
    private bool[] recompensasReclamadas;

    void Start()
    {
        // Inicializar la lista de recompensas reclamadas
        recompensasReclamadas = new bool[6];
        // Cargar el estado de cada recompensa desde PlayerPrefs
        for (int i = 0; i < recompensasReclamadas.Length; i++)
        {
            recompensasReclamadas[i] = PlayerPrefs.GetInt("RecompensaReclamada_" + i, 0) == 1;
        }

        // Actualizar la visibilidad y la interactividad de los botones al iniciar
        ActualizarEstadoBotones();
    }

    // Función para actualizar la visibilidad e interactividad de los botones
    void ActualizarEstadoBotones()
    {
        ConfigurarBoton(buttonCarpincho, !recompensasReclamadas[0]);
        ConfigurarBoton(buttonMonedas250, !recompensasReclamadas[1]);
        ConfigurarBoton(buttonMonedas2000, !recompensasReclamadas[2]);
        ConfigurarBoton(buttonMonedas4000, !recompensasReclamadas[3]);
        ConfigurarBoton(buttonCocodrilo, !recompensasReclamadas[4]);
        ConfigurarBoton(buttonSerpiente, !recompensasReclamadas[5]);
    }

    // Método para configurar el estado del botón usando CanvasGroup
    void ConfigurarBoton(GameObject boton, bool activo)
    {
        if (boton != null)
        {
            CanvasGroup canvasGroup = boton.GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                // Si no tiene CanvasGroup, lo añadimos
                canvasGroup = boton.AddComponent<CanvasGroup>();
            }

            canvasGroup.alpha = activo ? 1f : 0.5f;  // Opacidad 1 si activo, 0.5 si no
            canvasGroup.interactable = activo;       // Activo solo si es interactuable
            canvasGroup.blocksRaycasts = activo;     // Bloquea rayos solo si está activo
        }
    }

    // Método general para reclamar recompensas
    void ReclamarRecompensa(System.Action recompensa, GameObject boton, int indiceRecompensa)
    {
        if (boton == null) return;
        
        CanvasGroup canvasGroup = boton.GetComponent<CanvasGroup>();
        if (canvasGroup != null && !canvasGroup.interactable) return; // No permite reclamar si el botón ya está desactivado

        // Aplicar la recompensa
        recompensa?.Invoke();

        // Marcar la recompensa como reclamada
        recompensasReclamadas[indiceRecompensa] = true;
        PlayerPrefs.SetInt("RecompensaReclamada_" + indiceRecompensa, 1);

        // Actualizar estado para prevenir clics múltiples
        ActualizarEstadoBotones();
    }

    // Función específica para reclamar la recompensa de Carpincho
    public void ReclamarCarpincho()
    {
        ReclamarRecompensa(() =>
        {
            PlayerPrefs.SetInt("CantidadCarpincho", PlayerPrefs.GetInt("CantidadCarpincho") + 1);
        }, buttonCarpincho, 0);
    }

    // Función específica para reclamar monedas (250)
    public void ReclamarMonedas250()
    {
        ReclamarRecompensa(() =>
        {
            PlayerPrefs.SetInt("Moneditas", PlayerPrefs.GetInt("Moneditas") + 250);
        }, buttonMonedas250, 1);
    }

    // Función específica para reclamar monedas (2000)
    public void ReclamarMonedas2000()
    {
        ReclamarRecompensa(() =>
        {
            PlayerPrefs.SetInt("Moneditas", PlayerPrefs.GetInt("Moneditas") + 2000);
        }, buttonMonedas2000, 2);
    }
     
    // Función específica para reclamar monedas (4000)
    public void ReclamarMonedas4000()
    {
        ReclamarRecompensa(() =>
        {
            PlayerPrefs.SetInt("Moneditas", PlayerPrefs.GetInt("Moneditas") + 4000);
        }, buttonMonedas4000, 3);
    }

    // Función específica para reclamar la recompensa de Cocodrilo
    public void ReclamarCocodrilo()
    {
        ReclamarRecompensa(() =>
        {
            PlayerPrefs.SetInt("CantidadCocodrilo", PlayerPrefs.GetInt("CantidadCocodrilo") + 1);
        }, buttonCocodrilo, 4);
    }

    // Función específica para reclamar la recompensa de Serpiente
    public void ReclamarSerpiente()
    {
        ReclamarRecompensa(() =>
        {
            PlayerPrefs.SetInt("CantidadSerpiente", PlayerPrefs.GetInt("CantidadSerpiente") + 1);
        }, buttonSerpiente, 5);
    }
}
