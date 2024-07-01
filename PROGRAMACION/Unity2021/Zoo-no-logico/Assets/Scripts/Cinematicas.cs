using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematicas : MonoBehaviour
{
  
    [SerializeField] public GameObject continuar;
    [SerializeField] public GameObject ganar;
    [SerializeField] public GameObject perder;
    [SerializeField] public GameObject fondo;

    [SerializeField] public GameObject C01;
    [SerializeField] public GameObject C02;
    [SerializeField] public GameObject C03;
    [SerializeField] public GameObject C04;
    [SerializeField] public GameObject C05;
    [SerializeField] public GameObject C06;
    [SerializeField] public GameObject GOOD_END;
    [SerializeField] public GameObject BAD_END;

    


    // Start is called before the first frame update 

    void Start()
    {
        
    }

    void Awake()
    {
        switch (PlayerPrefs.GetString("Cinematica"))
        {
            case "C01":
                C01.SetActive(true);
               
                break;
            case "C02":
                C02.SetActive(true);
                
                break;
            case "C03":
                C03.SetActive(true);
                
                break;
            case "C04":
                C04.SetActive(true);
                
                break;
            case "C05":
                C05.SetActive(true);
                
                break;
            case "C06":
                C06.SetActive(true);
                
                break;
            case "GOOD_END":
                GOOD_END.SetActive(true);
                
                break;
            case "BAD_END":
                BAD_END.SetActive(true);
                
                break;


            default:
                print("Cinematica no existe");
                break;
        }
        
        PlayerPrefs.SetInt("EventoCartas", 1);
       
    }


    // Update is called once per frame
    void Update()
    {
        
    } 

   
    

    
}
