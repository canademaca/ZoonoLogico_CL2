using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecompensaMiniGame : MonoBehaviour
{
    public Text earnedMoney;
    public GameObject Collectable01;
    public GameObject Collectable02;
    public GameObject Collectable03;
    public GameObject Collectable04;
    public GameObject Collectable05;

    public int Monedas = 4000;

    // Start is called before the first frame update
    void Start()
    {
        earnedMoney = GameObject.FindGameObjectWithTag("earnedMoney").GetComponent<Text>();

        Recompensa();
    }

    // Update is called once per frame
    void Update()
    {
        earnedMoney.text = Monedas.ToString("");
    }


    void Recompensa()
    {
        if (Collectable01 == null)
        {
            Monedas = Monedas + 1000;
        }

        if (Collectable02 == null)
        {
            Monedas = Monedas + 1000;
        }

        if (Collectable03 == null)
        {
            Monedas = Monedas + 1000;
        }

        if (Collectable04 == null)
        {
            Monedas = Monedas + 1000;
        }

        if (Collectable05 == null)
        {
            Monedas = Monedas + 1000;
        }

        PlayerPrefs.SetInt("Moneditas", PlayerPrefs.GetInt("Moneditas") + Monedas);

    }

}

