using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpRecompensa : MonoBehaviour
{
    public GameObject PopUp1;
    public GameObject PopUp2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Recompensa()
    {
        PopUp1.SetActive(false);
        PopUp2.SetActive(true);
    }
}
