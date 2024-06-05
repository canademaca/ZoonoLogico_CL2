using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObstaculo : MonoBehaviour
{

    float velocidad = 4f;
    public Rigidbody2D rbd2;
    bool Izquierda = true;
    public Transform Apoint;
    public Transform Bpoint;


    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Izquierda == true)
        {
            rbd2.velocity = new Vector2(-velocidad, rbd2.velocity.y);
        }

    }

}
