using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    [SerializeField] private GameObject ANALYTICS;
    public AudioSource sound;
    public AudioClip Sonidoboton;
    [SerializeField] public CambioDeDia scriptDia;
    



    void Start()
    {
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");


    }


    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void OpenCinematic()
    {
                        
    }

    public void VolverAJugar()
    {
        PlayerPrefs.SetInt("Dias", 0);
    }

    public void NoRestarAnimales()
    {
        PlayerPrefs.SetInt("Cantidad" + PlayerPrefs.GetString("Slot1"), PlayerPrefs.GetInt("Cantidad" + PlayerPrefs.GetString("Slot1")) + 1);
        PlayerPrefs.SetInt("Cantidad" + PlayerPrefs.GetString("Slot2"), PlayerPrefs.GetInt("Cantidad" + PlayerPrefs.GetString("Slot2")) + 1);
        PlayerPrefs.SetInt("Cantidad" + PlayerPrefs.GetString("Slot3"), PlayerPrefs.GetInt("Cantidad" + PlayerPrefs.GetString("Slot3")) + 1);
    }

    


}





