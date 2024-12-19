using UnityEngine;
using TMPro;

public class InterestObject : MonoBehaviour
{
    public TextMeshPro interactionText; // Texto que muestra al interactuar
    [TextArea] public string interestMessage = "Este objeto parece interesante."; // Mensaje de interés
    private bool isPlayerNear = false; // Indica si el jugador está cerca

    void Start()
    {
        // Asegurarnos de que el texto esté oculto al inicio
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Verificar si el jugador presiona "E" mientras está cerca del objeto
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ShowInterestMessage();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el jugador entra en el área de interacción
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = "Presiona E para observar";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Si el jugador sale del área de interacción
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }

    private void ShowInterestMessage()
    {
        if (interactionText != null)
        {
            interactionText.text = interestMessage;
            Debug.Log(interestMessage); // Registrar el mensaje en la consola (opcional)
        }
    }
}
