using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColisionBat : MonoBehaviour
{
    public Rigidbody2D rbd2;
    public GameObject Perdiste;
    public GameObject Animal;
    [SerializeField] public MovimientoCocodrilo player;
    [SerializeField] public Movimiento player1;
    [SerializeField] public MovimientoCiudad player2;
    [SerializeField] public MovimientoCampo player3;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.tag == "AnimalCapturado")
        {
            Destroy(Animal);
            Perdiste.SetActive(true);
            player.estado = MovimientoCocodrilo.GameState.Muerto;
            player1.estado = Movimiento.GameState.Muerto;
            player2.estado = MovimientoCiudad.GameState.Muerto;
            player3.estado = MovimientoCampo.GameState.Muerto;
        }
    }




}
