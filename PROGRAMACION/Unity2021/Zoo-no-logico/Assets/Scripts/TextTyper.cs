using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TextTyper : MonoBehaviour
{
    public float interval = 0.02f;
    public string[] messages;
    public Text textGameObject;
    public UnityEvent onDialogComplete; // Evento que se dispara cuando los diálogos terminan
    public GameObject[] dialogObjects;
    private int currentMessageIndex = 0;
    private int currentDialogIndex = 0;

    void Start()
    {
        textGameObject.text = "";
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        while (currentMessageIndex < messages.Length)
        {
            string message = messages[currentMessageIndex];
            textGameObject.text = "";

            foreach (char letter in message.ToCharArray())
            {
                textGameObject.text += letter;
                yield return new WaitForSeconds(interval);
            }

            currentMessageIndex++;
            yield return new WaitForSeconds(1.0f); // Espera antes de la próxima oración
        }
        onDialogComplete?.Invoke(); // Dispara el evento cuando los diálogos terminan
    }

   public void ResetDialog()
    {
        currentMessageIndex = 0;
        textGameObject.text = "";
        StartCoroutine(Type());
    }
}
