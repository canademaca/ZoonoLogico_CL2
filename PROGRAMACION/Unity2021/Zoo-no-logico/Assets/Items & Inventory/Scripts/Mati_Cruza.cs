using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mati_Cruza : MonoBehaviour
{
    public List<string> animales1 = new List<string>();
    public List<Mati_Animales> animales2 = new List<Mati_Animales>();

    public bool HayObjetos = false;
    public Button Boton;

    public Mati_CruzasAnimales[] cruzas;
    public Mati_CruzasAnimales RetenerAnimal;

    public GameObject cartel;

    public string PC;

    private int divisorCosto = 4;
    [SerializeField] private GameObject ANALYTICS;

    void Start()
    {
        Boton.interactable = false;
        cruzas = Resources.LoadAll<Mati_CruzasAnimales>(""); // Especifica la ruta correcta

        PC = PlayerPrefs.GetString("PrimeraCombinacion", "true");
        ANALYTICS = GameObject.FindGameObjectWithTag("ANALYTICS");
    }

    public void Recibir(Mati_Animales animal)
    {
        if (animales2.Count < 3)
        {
            animales2.Add(animal);
            animales1.Add(animal.nombre);
        }

        if (animales2.Count == 3)
        {
            HayObjetos = true;

            Text TextoMonedas = GameObject.FindGameObjectWithTag("txt_monedas").GetComponent<Text>();
            Text TextoPorcentaje = GameObject.FindGameObjectWithTag("txt_porcentaje").GetComponent<Text>();

            foreach (Mati_CruzasAnimales a in cruzas)
            {
                if (a.nombre.Contains(animales1[0]) && a.nombre.Contains(animales1[1]) && a.nombre.Contains(animales1[2]))
                {
                    if (PlayerPrefs.GetInt("Cruza" + a.id) == 1)
                    {
                        StartCoroutine(DestruirObjeto(cartel));
                        return;
                    }

                    int costo = ((int)a.precio / divisorCosto);
                    TextoMonedas.text = costo.ToString();
                    TextoPorcentaje.text = a.porcentaje.ToString();
                    RetenerAnimal = a;
                    break;
                }
            }

            if (RetenerAnimal && RetenerAnimal.precio / divisorCosto <= PlayerPrefs.GetInt("Moneditas"))
            {
                Boton.interactable = true;
            }
        }
    }

    public void Quitar(Mati_Animales animal)
    {
        animales2.Remove(animal);
        animales1.Remove(animal.nombre);

        if (animales2.Count < 3)
        {
            HayObjetos = false;
            Boton.interactable = false;

            Text TextoMonedas = GameObject.FindGameObjectWithTag("txt_monedas").GetComponent<Text>();
            Text TextoPorcentaje = GameObject.FindGameObjectWithTag("txt_porcentaje").GetComponent<Text>();

            TextoMonedas.text = "0";
            TextoPorcentaje.text = "%";
        }
    }

    public void Craftear()
    {
        PlayerPrefs.SetInt("ImpuestoXDiasSinCruzas", 0);
        int plata = PlayerPrefs.GetInt("Moneditas");
        int total = plata - RetenerAnimal.precio / divisorCosto;
        PlayerPrefs.SetInt("Moneditas", total);

        PlayerPrefs.SetString("animalSlot1", animales1[0]);
        PlayerPrefs.SetString("animalSlot2", animales1[1]);
        PlayerPrefs.SetString("animalSlot3", animales1[2]);

        PlayerPrefs.SetInt("combinarTotales", PlayerPrefs.GetInt("combinarTotales") + 1);

        int random = Random.Range(0, 101);
        PlayerPrefs.SetInt("indexCurrentCruza", RetenerAnimal.id);

        foreach (string a in animales1)
        {
            string cantidad = "Cantidad";

            if (a.Contains("Ara"))
            {
                int restar = PlayerPrefs.GetInt(cantidad + "Arana") - 1;
                PlayerPrefs.SetInt(cantidad + "Arana", restar);
            }
            else if (a == "Ave Secretaria")
            {
                int restar = PlayerPrefs.GetInt(cantidad + "Ave") - 1;
                PlayerPrefs.SetInt(cantidad + "Ave", restar);
            }
            else
            {
                int restar = PlayerPrefs.GetInt(cantidad + a) - 1;
                PlayerPrefs.SetInt(cantidad + a, restar);
            }

             ANALYTICS.SendMessage("cruza");
        }

        if (random > RetenerAnimal.porcentaje)
        {
            if (PlayerPrefs.GetString("PrimeraCombinacion") == "true")
            {
                PlayerPrefs.SetString("PrimeraCombinacion", "false");
                SceneManager.LoadScene(6);
                PlayerPrefs.SetInt("cruzasExito", PlayerPrefs.GetInt("cruzasExito") + 1);

                if (PlayerPrefs.GetInt("Cruza" + RetenerAnimal.id) == 0)
                {
                    PlayerPrefs.SetInt("totalCodex", PlayerPrefs.GetInt("totalCodex") + 1);
                }
            }
            else
            {
                SceneManager.LoadScene(9);
                PlayerPrefs.SetInt("cruzasFalla", PlayerPrefs.GetInt("cruzasFalla") + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(6);
            PlayerPrefs.SetInt("cruzasExito", PlayerPrefs.GetInt("cruzasExito") + 1);

            if (PlayerPrefs.GetInt("Cruza" + RetenerAnimal.id) == 0)
            {
                PlayerPrefs.SetInt("totalCodex", PlayerPrefs.GetInt("totalCodex") + 1);
            }
        }
    }

    private IEnumerator DestruirObjeto(GameObject objeto)
    {
        objeto.SetActive(true);
        yield return new WaitForSeconds(3);
        objeto.SetActive(false);
    }
}