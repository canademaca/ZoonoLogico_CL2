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
           ganarCinematica.SetActive(true);
       }
       else if (estadoJuego == "Perder")
       {
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

           ActivarCinematica();
       }
   }

   void Awake()
    {PlayerPrefs.SetInt("EventoCartas", 1);}
}