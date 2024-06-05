using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FondoTest : MonoBehaviour
{
    public RawImage fondo;      // Traer RawImage

    public float velocidad;     // velocidad que se modifica desde el inspector


    // Start is called before the first frame update
    void Start()
    {
        fondo = transform.GetChild(0).GetComponent<RawImage>();
        // Busca el Objeto Child del Objeto que tiene este script
        // Después vamos a querer modificar el componente Raw Image

    }

    // Update is called once per frame
    void Update()
    {
        // Creamos una nueva variable de velocidad que va a tener en cuenta la OTRA variable que hicimos * Time.deltaTime
        float velocidadFinal = velocidad * Time.deltaTime;
        fondo.uvRect = new Rect(fondo.uvRect.x + velocidadFinal, 0f, 1f, 1f);   // Modifica el parámetro X del UV Rect del Raw Image

        // Rect basicamente es un rectangulo/cuadrado. Toma 4 valores.

    }
}