using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSonidos : MonoBehaviour
{

    public Slider Music;
    public float VolumenMusic;

    // Use this for initialization
    void Start()
    {

        Music.value = PlayerPrefs.GetFloat("VolMusic");

    }

    // Update is called once per frame
    void Update()
    {

        VolumenMusic = Music.value;

        PlayerPrefs.SetFloat("VolMusic", VolumenMusic);

    }

    //public void Volumen()
    //{
    //    slider.value = 1;
    //}
}
