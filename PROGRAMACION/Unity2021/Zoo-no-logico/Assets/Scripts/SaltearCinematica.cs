using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SaltearCinematica : MonoBehaviour
{
    [SerializeField] private VideoPlayer video;
    [SerializeField] public GameObject script;
    [SerializeField] private GameObject ANALYTICS;
    [SerializeField] public GameObject C01;
    [SerializeField] public GameObject C02;
    [SerializeField] public GameObject C03;
    [SerializeField] public GameObject C04;
    [SerializeField] public GameObject C05;
    [SerializeField] public GameObject C06;
    [SerializeField] public GameObject GOOD_END;
    [SerializeField] public GameObject BAD_END;
    public GameObject videoContainer;

    void Start()
    {
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");
    }

    void Awake()
    {
        switch (PlayerPrefs.GetString("Cinematica"))
        {
            case "C01":
                videoContainer = C01;
                break;
            case "C02":
                
                videoContainer = C02;
                break;
            case "C03":
                
                videoContainer = C03;
                break;
            case "C04":
                
                videoContainer = C04;
                break;
            case "C05":
                
                videoContainer = C05;
                break;
            case "C06":
                
                videoContainer = C06;
                break;
            case "GOOD_END":
                
                videoContainer = GOOD_END;
                break;
            case "BAD_END":
                
                videoContainer = BAD_END;
                break;


            default:
                print("Cinematica no existe");
                break;
        }
        video = videoContainer.GetComponent<VideoPlayer>();
    }

    public void Saltear()
    {
        PlayerPrefs.SetInt("cinematicasSalteadas", PlayerPrefs.GetInt("cinematicasSalteadas") + 1);
        PlayerPrefs.SetString("Cinematica", videoContainer.name);
        ANALYTICS.SendMessage("saltear_cinematica");
        script.SendMessage("onMovieEnd", video);
    }
}
