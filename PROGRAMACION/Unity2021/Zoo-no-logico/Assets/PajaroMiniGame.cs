using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PajaroMiniGame : MonoBehaviour
{

    float velocidad = 3.3f;
    public Rigidbody2D rbd2;
    bool Izquierda = true;
    public Transform Apoint;
    public Transform Bpoint;
    public GameObject Perdiste;
    public GameObject Animal;
    public BoxCollider2D Collider;

    [SerializeField] public MovimientoCampo player3;


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
            rbd2.velocity = new Vector2(velocidad, rbd2.velocity.y);
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Caida")
        {
            Destroy(Animal);
            Perdiste.SetActive(true);
            player3.estado = MovimientoCampo.GameState.Muerto;
        }
    }
}

