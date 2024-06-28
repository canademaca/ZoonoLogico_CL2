using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aceptar_tutorial ()
    {
        PlayerPrefs.SetInt("tutorialSeguidos",PlayerPrefs.GetInt("tutorialSeguidos")+1);
    }

    public void abrir_tutorial()
    {
        PlayerPrefs.SetInt("tutorialesAbiertos", PlayerPrefs.GetInt("tutorialesAbiertos") + 1);
    }

    public void salir_tutorial()
    {
        PlayerPrefs.SetInt("tutorialesrechazados", PlayerPrefs.GetInt("tutorialesrechazados") + 1);
    }
}
