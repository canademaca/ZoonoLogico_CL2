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

   void Start()
   {
       estadoJuego = PlayerPrefs.GetString("EstadoJuego", "Normal");
       indiceCinematica = PlayerPrefs.GetInt("IndiceCinematica", 0);

       ActivarCinematica();
   }

   void ActivarCinematica()
{
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
    }
    if (estadoJuego == "Ganar" && ganarCinematica != null)
        {
         ganarCinematica.SetActive(true);
        }
        else if (estadoJuego == "Ganar" && ganarCinematica == null)
        {
         Debug.LogError("El objeto ganarCinematica no está asignado o es nulo.");
        }
}

public void MostrarSiguienteCinematica()
{
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

        ActivarCinematica();
    }
 } }