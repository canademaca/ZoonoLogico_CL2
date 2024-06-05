using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecompensaCartas : MonoBehaviour
{

    public GameObject button;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public int reclamado;

    // Start is called before the first frame update
    void Start()
    {

        reclamado = PlayerPrefs.GetInt("RecompensaCartas");
    }

    // Update is called once per frame
    void Update()
    {
        switch (reclamado)
        {
            case 1:
                button.SetActive(false);
                break;

            case 2:
                button.SetActive(false);
                button2.SetActive(false);
                break;

            case 3:
                button.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                break;

            case 4:
                button.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(false);
                break;

            case 5:
                button.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(false);
                button5.SetActive(false);
                break;

            case 6:
                button.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(false);
                button5.SetActive(false);
                button6.SetActive(false);
                break;

        }
    }

    public void ReclamarCarpincho()
    {
        PlayerPrefs.SetInt("CantidadCarpincho", PlayerPrefs.GetInt("CantidadCarpincho") + 1);
        reclamado++;
        PlayerPrefs.SetInt("RecompensaCartas", reclamado);
    }

    public void ReclamarMonedas(int monedas)
    {
        PlayerPrefs.SetInt("Moneditas", PlayerPrefs.GetInt("Moneditas") + monedas);
        reclamado++;
        PlayerPrefs.SetInt("RecompensaCartas", reclamado);
    }

    public void ReclamarCocodrilo()
    {
        PlayerPrefs.SetInt("CantidadCocodrilo", PlayerPrefs.GetInt("CantidadCocodrilo") + 1);
        reclamado++;
        PlayerPrefs.SetInt("RecompensaCartas", reclamado);
    }

    public void ReclamarSerpiente()
    {
        PlayerPrefs.SetInt("CantidadSerpiente", PlayerPrefs.GetInt("CantidadSerpiente") + 1);
        reclamado++;
        PlayerPrefs.SetInt("RecompensaCartas", reclamado);
    }
}
