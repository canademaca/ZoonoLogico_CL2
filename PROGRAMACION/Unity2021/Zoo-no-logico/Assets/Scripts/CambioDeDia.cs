using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CambioDeDia : MonoBehaviour 
{

    public int Monedas;
    public GameObject notif;
    public Text textoTurno;
    public int numTurno;
    public GameObject Pantalla;
    public GameObject PantallaPostEvento;
    public GameObject PantallaPerder;
    public GameObject PantallaGanar;
    public GameObject PantallaAnimalFallecido;
    public int Popularidad;
    public GameObject PopularidadBarra;
    private string[] listaAnimales = new string[] { "Carpincho", "Cocodrilo", "Arana", "Ave", "Serpiente", "Zorro", "Murcielago" };
    private string tempGO;
    public int CinematicaNumero;
    private int diasDesdeUltimaCinematica = 0;

    public GameObject aranaDesbloqueada;
    public GameObject aveDesbloqueada;
    public GameObject serpienteDesbloqueada;

    public float speed = 10.0f;

    [SerializeField] private GameObject ANALYTICS;
    [SerializeField] private TextAsset Cruzas;

    [System.Serializable]
    public class Cruza
    {
        public string id;
        public int popularidad;
    }
    [System.Serializable]
    public class CruzaList
    {
        public Cruza[] cruza;
    }

    public CruzaList myCruzaList = new CruzaList();

    [SerializeField] private Saciedad saciedadCtrl;

    void Start() {
        textoTurno = GameObject.FindGameObjectWithTag("TextoDias").GetComponent<Text>();
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");

        // Reiniciar días desde la última cinemática solo en nueva partida
        if (PlayerPrefs.GetInt("Dias") == 0) {
            PlayerPrefs.SetInt("CinematicaNumero", 0);
            diasDesdeUltimaCinematica = 0;
        }
    }

    void Update() {
        numTurno = PlayerPrefs.GetInt("Dias");
        textoTurno.text = "DIA: " + numTurno.ToString();
        Popularidad = PlayerPrefs.GetInt("Popularidad");

        // Desbloqueo de animales basado en popularidad
        if (Popularidad > 25 && PlayerPrefs.GetInt("aranaDesbloqueada") == 0)
        {
            PlayerPrefs.SetInt("aranaDesbloqueada", 1);
            PlayerPrefs.SetInt("CantidadArana", PlayerPrefs.GetInt("CantidadArana") + 1);
            aranaDesbloqueada.SetActive(true);
            StartCoroutine(DestruirObjeto(aranaDesbloqueada));
        }
        if (Popularidad > 30 && PlayerPrefs.GetInt("aveDesbloqueada") == 0)
        {
            PlayerPrefs.SetInt("aveDesbloqueada", 1);
            PlayerPrefs.SetInt("CantidadAve", PlayerPrefs.GetInt("CantidadAve") + 1);
            StartCoroutine(DestruirObjeto(aveDesbloqueada));
        }
        if (Popularidad > 35 && PlayerPrefs.GetInt("serpienteDesbloqueada") == 0)
        {
            PlayerPrefs.SetInt("serpienteDesbloqueada", 1);
            PlayerPrefs.SetInt("CantidadSerpiente", PlayerPrefs.GetInt("CantidadSerpiente") + 1);
            StartCoroutine(DestruirObjeto(serpienteDesbloqueada));
        }
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("TextoMonedas").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("TextoMonedas")[i].GetComponent<Text>().text = Monedas.ToString();
        }
        Monedas = PlayerPrefs.GetInt("Moneditas");

        PlayerPrefs.SetString("Slot1", "");
        PlayerPrefs.SetString("Slot2", "");
        PlayerPrefs.SetString("Slot3", "");
    }

    public void NotificacionStasis()
    {
        print(PlayerPrefs.GetInt("DineroNeg"));

        if (Monedas < 0 && PlayerPrefs.GetInt("DineroNeg") == 0)
        {
            PlayerPrefs.SetInt("DineroNeg", 1);
            notif.SetActive(true);
        }
    }

    public void DesactivarNoti()
    {
        notif.SetActive(false);
    }

    public void Minijuego(int SceneID)
    {
        print(PlayerPrefs.GetInt("Minigame"));

        if (Monedas < 1000 && PlayerPrefs.GetInt("Minigame") == 0)
        {
            SceneManager.LoadScene(SceneID);
            PlayerPrefs.SetInt("Minigame", 1);
        }
    }

    public void Pasar()
    {
        Minijuego(17);

        if (!PantallaPostEvento)
        {
            numTurno++;
            textoTurno.text = "DIA: " + numTurno.ToString();
            Pantalla.SetActive(false);
            PlayerPrefs.SetInt("Dias", numTurno);
            PopularidadBarra.SetActive(true);
            PlayerPrefs.SetInt("EventoCartas", 1);

            diasDesdeUltimaCinematica++;
        }
        else
        {
            Pantalla.SetActive(false);
            PlayerPrefs.SetInt("ImpuestoXDiasSinCruzas", PlayerPrefs.GetInt("ImpuestoXDiasSinCruzas"));
        }

        // Verifica si pasaron dos días desde la última cinemática
        if (diasDesdeUltimaCinematica >= 2)
        {
            CinematicaNumero = PlayerPrefs.GetInt("CinematicaNumero");
            CinematicaNumero += 1;
            PlayerPrefs.SetInt("CinematicaNumero", CinematicaNumero);
            PlayerPrefs.SetString("Cinematica", "C0" + CinematicaNumero);
            SceneManager.LoadScene(75);
            diasDesdeUltimaCinematica = 0; // Resetea el contador
        }
    }

    public void CerrarPantallaAnimalFallecido()
    {
        PantallaAnimalFallecido.SetActive(false);
    }

    public void AbrirPantalla()
    {
        int Random1 = new System.Random().Next(0, 20);
        int Random2 = new System.Random().Next(0, 20);
        int Random3 = new System.Random().Next(1, 13);

        // Mezcla de lista de animales
        for (int i = 0; i < listaAnimales.Length; i++)
        {
            int rnd = Random.Range(0, listaAnimales.Length);
            tempGO = listaAnimales[rnd];
            listaAnimales[rnd] = listaAnimales[i];
            listaAnimales[i] = tempGO;
        }

        // Asignación de animales a la tienda
        PlayerPrefs.SetString("animal1Tienda", listaAnimales[0]);
        PlayerPrefs.SetString("animal2Tienda", listaAnimales[1]);
        PlayerPrefs.SetString("animal3Tienda", listaAnimales[2]);
        PlayerPrefs.SetString("animal4Tienda", listaAnimales[3]);
        PlayerPrefs.SetString("animal5Tienda", listaAnimales[4]);
        PlayerPrefs.SetString("animal6Tienda", listaAnimales[5]);
        PlayerPrefs.SetString("animal7Tienda", listaAnimales[6]);

        PlayerPrefs.SetInt("comentarioRandom1", Random1);
        PlayerPrefs.SetInt("comentarioRandom2", Random2);
        PlayerPrefs.SetInt("avatarRandom", Random3);

        PlayerPrefs.SetInt("ImpuestoXDiasSinCruzas", PlayerPrefs.GetInt("ImpuestoXDiasSinCruzas") + 1);

        if (Popularidad >= 100 && PlayerPrefs.GetInt("Ganaste") == 0)
        {
            PlayerPrefs.SetString("Cinematica", "GOOD_END");
            PlayerPrefs.SetString("EstadoJuego", "Ganar");
            SceneManager.LoadScene(75);
            PlayerPrefs.SetInt("Ganaste", 1);
            PlayerPrefs.SetInt("ActivadorCalificacion", 1);
            
            ANALYTICS.SendMessage("ganar");
        }
        else if (Popularidad <= 0 && PlayerPrefs.GetInt("Ganaste") == 0)
        {
            PlayerPrefs.SetString("Cinematica", "BAD_END");
            PlayerPrefs.SetString("EstadoJuego", "Perder");
            SceneManager.LoadScene(75);
            ANALYTICS.SendMessage("game_over");
        }
        else 
        {
            Pantalla.SetActive(true);
            PopularidadBarra.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Ganaste") == 1)
        {
            PlayerPrefs.SetInt("CantidadCarpincho", 99);
            PlayerPrefs.SetInt("CantidadArana", 99);
            PlayerPrefs.SetInt("CantidadAve", 99);
            PlayerPrefs.SetInt("CantidadZorro", 99);
            PlayerPrefs.SetInt("CantidadCocodrilo", 99);
            PlayerPrefs.SetInt("CantidadSerpiente", 99);
            PlayerPrefs.SetInt("CantidadMurcielago", 99);
            PlayerPrefs.SetInt("Moneditas", 999999999);
        }
    }

    public void OnPantallaPostEvento()
    {
        if (PantallaPostEvento)
        {
            PantallaPostEvento.SetActive(true);
        }
    }

    IEnumerator DestruirObjeto(GameObject objeto)
    {
        objeto.SetActive(true);
        yield return new WaitForSeconds(3);
        objeto.SetActive(false);
        Destroy(objeto);
    }
}