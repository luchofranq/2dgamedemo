using UnityEngine;
using TMPro;

public class TreasureChest : MonoBehaviour
{
    public GameObject closedChest; // Cofre cerrado
    public GameObject openedChest; // Cofre abierto
    public TextMeshPro interactionText; // Texto de interacción

    private PlayerInventory playerInventory; // Referencia al inventario del jugador
    private bool canInteract = false; // Si el jugador puede interactuar con el cofre

    void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();

        if (playerInventory == null)
        {
            Debug.LogError("No se encontró el componente PlayerInventory en la escena.");
        }

        closedChest.SetActive(true);
        openedChest.SetActive(false);

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
                interactionText.text = playerInventory.hasKey ? 
                    "Presiona E para abrir el cofre" : 
                    "Presiona E para intentar abrir el cofre (llave necesaria)";
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
            InteractWithChest();
        }
    }

    private void InteractWithChest()
    {
        if (playerInventory.hasKey)
        {
            OpenChest();
        }
        else
        {
            if (interactionText != null)
            {
                interactionText.text = "No tienes la llave para abrir el cofre.";
            }
            Debug.Log("Intentaste abrir el cofre, pero no tienes la llave.");
        }
    }

    private void OpenChest()
    {
        closedChest.SetActive(false);
        openedChest.SetActive(true);

        if (interactionText != null)
        {
            interactionText.text = "¡El cofre está abierto!";
        }

        Debug.Log("¡Has abierto el cofre!");
        Invoke("ChangeScene", 2f); // Cambiar de escena tras 2 segundos
    }

    private void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }
}
