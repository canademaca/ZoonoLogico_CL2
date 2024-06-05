using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimientoCampo : MonoBehaviour
{

    private float velocidad = 3.8f;
    private float salto = 12;
    private bool PuedeSaltar;
    private bool PuedeAgachar;
    private float horizontal;
    private float vertical;
    private bool isFacingRight = false;
   

    int Monedas = 0;

    public GameObject Collectable01;
    public GameObject Collectable02;
    public GameObject Collectable03;
    public GameObject Collectable04;
    public GameObject Animal;
    public GameObject Ganaste;
    public GameObject Perdiste;
    



    public enum GameState { Vivo, Muerto, Revivir, Daño }

    public RawImage fondo;
    public float velocidadfondo;

    public RawImage nubes;
    public float velnubes;

    public GameState estado;
    public Animator animpl;


    [SerializeField] Rigidbody2D rb2d;
    public SpriteRenderer spritepl;
    public BoxCollider2D Collider;
    public Vector2 StandingHeight;
    public Vector2 CrouchingHeight;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spritepl = GetComponent<SpriteRenderer>();
        StandingHeight = Collider.size;

        estado = GameState.Vivo;

        animpl.SetBool("Idle", false);
        animpl.SetBool("Correr", false);
        animpl.SetBool("Salto", false);
        animpl.SetBool("Muerte", false);
        animpl.SetBool("Crouch", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == GameState.Vivo)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0)
            {

                float velocidadFinal = velocidadfondo * Time.deltaTime * horizontal;
                fondo.uvRect = new Rect(fondo.uvRect.x + velocidadFinal, 0f, 1f, 1f);

                float velFinal = velnubes * Time.deltaTime * horizontal;
                nubes.uvRect = new Rect(nubes.uvRect.x + velFinal, 0f, 1f, 1f);

            }

            if (horizontal != 0 && vertical == 0)
            {
                animpl.SetBool("Correr", true);
            }

            else
            {
                animpl.SetBool("Correr", false);
                animpl.SetBool("Idle", true);

            }

            if (Input.GetKey("d"))
            {
                rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
                spritepl.flipX = false;
                animpl.SetBool("Idle", false);

            }




            if (Input.GetKey("a"))
            {
                rb2d.velocity = new Vector2(-velocidad, rb2d.velocity.y);
                spritepl.flipX = true;
                animpl.SetBool("Idle", false);


            }



            if (Input.GetKey("w") && PuedeSaltar)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, salto);
                PuedeSaltar = false;
            }



            if (vertical != 0 && animpl.GetBool("Crouch") == false)
            {
                animpl.SetBool("Salto", true);
            }

            else
            {

                animpl.SetBool("Salto", false);

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                animpl.SetBool("Crouch", true);
                Collider.size = CrouchingHeight;

                if (vertical < 0)
                {
                    animpl.SetBool("Salto", false);
                }
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                animpl.SetBool("Crouch", false);
                Collider.size = StandingHeight;
            }


        }

        if (estado == GameState.Muerto)
        {
            Destroy(spritepl);

        }
        
    }

    void MuerteTrue()
    {
        estado = GameState.Daño;
    }

    void MuerteFalse()
    {

        animpl.SetBool("Muerte", false);
        estado = GameState.Vivo;
    }

    private void FlipSp()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataformas")
        {
            PuedeSaltar = true;
            animpl.SetBool("Muerte", false);
        }




        if (collision.gameObject.tag == "Caida")
        {
            Destroy(Animal);
            Perdiste.SetActive(true);
            estado = GameState.Muerto;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Plataformas" || estado == GameState.Vivo)
        {
            PuedeSaltar = false;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            animpl.SetBool("Muerte", true);            
            //muerteanim();

        }

        else
        {
            animpl.SetBool("Muerte", false);
        }
        if (collision.gameObject.tag == "AnimalCapturado")
        {
            Destroy(Animal);
            Ganaste.SetActive(true);
            estado = GameState.Muerto;
        }
        if (collision.gameObject.tag == "Collectable01")
        {
            Monedas++;
            Destroy(Collectable01);
        }
        if (collision.gameObject.tag == "Collectable02")
        {
            Monedas++;
            Destroy(Collectable02);
        }
        if (collision.gameObject.tag == "Collectable03")
        {
            Monedas++;
            Destroy(Collectable03);
        }
        if (collision.gameObject.tag == "Collectable04")
        {
            Monedas++;
            Destroy(Collectable04);
        }

    }

    private IEnumerator muerteanim()
    {
        animpl.SetBool("Muerte", true);
        yield return new WaitForSeconds(0.2f);
        animpl.SetBool("Muerte", false);

    }





}