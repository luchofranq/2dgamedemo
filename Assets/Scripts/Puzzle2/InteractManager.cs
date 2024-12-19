using UnityEngine;
using TMPro;

public class InteractManager : MonoBehaviour
{
    public string objectType; // Tipo de objeto ("Vasija", "Caja", etc.)
    public TextMeshPro interactionText; // Texto de interacción
    public bool canInteract = false; // Si el jugador puede interactuar
    public bool hasBeenInteracted = false; // Si ya se interactuó con este objeto

    private PlayerInventory playerInventory; // Referencia al inventario del jugador

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();

        if (playerInventory == null)
        {
            Debug.LogError("No se encontró el componente PlayerInventory en la escena.");
        }

        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;

            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = hasBeenInteracted ? "Aquí no hay nada" : "Presiona E para interactuar";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;

            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Interact();
        }
    }

    private void Interact()
    {
        if (hasBeenInteracted)
        {
            Debug.Log("Aquí no hay nada.");
            interactionText.text = "Aquí no hay nada";
            return;
        }

        if (objectType == "Vasija")
        {
            // Si es una vasija, el jugador encuentra la llave
            playerInventory.hasKey = true;
            hasBeenInteracted = true;
            interactionText.text = "Wow! Una llave!";
            Debug.Log("Has encontrado la llave en la vasija.");
        }
        else
        {
            // Para otros objetos
            hasBeenInteracted = true;
            interactionText.text = "Aquí no hay nada";
            Debug.Log("Aquí no hay nada.");
        }
    }
}
