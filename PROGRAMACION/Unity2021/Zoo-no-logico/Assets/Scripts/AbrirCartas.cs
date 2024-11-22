using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCartas : MonoBehaviour {

    [SerializeField] private GameObject ANALYTICS;
    
    public GameObject CartaInfo;
    public GameObject Sombreado;
    public GameObject CartaBoton;


	// Use this for initialization
	void Start () 
    {
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void Abrir()
    {
        PlayerPrefs.SetInt("cartasLeidasTotales", PlayerPrefs.GetInt("cartasLeidasTotales") + 1);
        ANALYTICS.SendMessage("cartas_abiertas");
        CartaInfo.SetActive(true);
        CartaBoton.SetActive(true);
        Sombreado.SetActive(true);
    }


    public void Cerrar()
    {
        CartaInfo.SetActive(false);
        CartaBoton.SetActive(false);
        Sombreado.SetActive(false);
    }
}
