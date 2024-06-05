using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{

    [SerializeField] private VideoPlayer video;
    [SerializeField] public GameObject continuar;
    [SerializeField] public GameObject ganar;
    [SerializeField] public GameObject perder;
    [SerializeField] public GameObject saltear;
    [SerializeField] public GameObject fondo;

    [SerializeField] public GameObject C01;
    [SerializeField] public GameObject C02;
    [SerializeField] public GameObject C03;
    [SerializeField] public GameObject C04;
    [SerializeField] public GameObject C05;
    [SerializeField] public GameObject C06;
    [SerializeField] public GameObject GOOD_END;
    [SerializeField] public GameObject BAD_END;

    public GameObject videoContainer;
    public float volume;


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
                videoContainer = C01;
                break;
            case "C02":
                C02.SetActive(true);
                videoContainer = C02;
                break;
            case "C03":
                C03.SetActive(true);
                videoContainer = C03;
                break;
            case "C04":
                C04.SetActive(true);
                videoContainer = C04;
                break;
            case "C05":
                C05.SetActive(true);
                videoContainer = C05;
                break;
            case "C06":
                C06.SetActive(true);
                videoContainer = C06;
                break;
            case "GOOD_END":
                GOOD_END.SetActive(true);
                videoContainer = GOOD_END;
                break;
            case "BAD_END":
                BAD_END.SetActive(true);
                videoContainer = BAD_END;
                break;


            default:
                print("Cinematica no existe");
                break;
        }
        video = videoContainer.GetComponent<VideoPlayer>();
        PlayerPrefs.SetInt("EventoCartas", 1);
        volume = PlayerPrefs.GetFloat("VolMusic");
        video.SetDirectAudioVolume(0, volume);
    }


    // Update is called once per frame
    void Update()
    {
        video.loopPointReached += onMovieEnd;
    } 

    public void onMovieEnd(UnityEngine.Video.VideoPlayer vp)
    {
        print("Termino video");
        fondo.SetActive(true);
        video.Stop();
        GameObject.Find(PlayerPrefs.GetString("Cinematica")).SetActive(false);
        saltear.SetActive(false);
        if (PlayerPrefs.GetString("Cinematica") == "GOOD_END")
        {
            ganar.SetActive(true);
        }
        else if(PlayerPrefs.GetString("Cinematica") == "BAD_END")
        {
            perder.SetActive(true);
        }
        else
        {
            continuar.SetActive(true);
        }
    }   

    
}
