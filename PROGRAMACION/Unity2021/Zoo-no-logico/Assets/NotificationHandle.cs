using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NotificationHandle : MonoBehaviour
{

    public int Monedas;
    public GameObject notif;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < GameObject.FindGameObjectsWithTag("TextoMonedas").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("TextoMonedas")[i].GetComponent<Text>().text = Monedas.ToString();
        }
        Monedas = PlayerPrefs.GetInt("Moneditas");

        print(PlayerPrefs.GetInt("DineroNeg"));

        if (Monedas < 0 && PlayerPrefs.GetInt("DineroNeg") == 0)
        {
            PlayerPrefs.SetInt("DineroNeg", 1);
            notif.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
