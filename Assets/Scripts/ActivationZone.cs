using UnityEngine;

public class ActivationZone : MonoBehaviour
{
    public GameObject doorClosed;  // Referencia al objeto DoorClosed
    public GameObject doorOpened;  // Referencia al objeto DoorOpened

    private bool isBoxOnAltar = false;  // Variable para controlar si la caja está en el altar

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Detectar si la caja entra en el altar
        if (collision.CompareTag("Box"))
        {
            isBoxOnAltar = true;
            UpdateDoorState(); // Actualiza el estado de la puerta
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Detectar si la caja sale del altar
        if (collision.CompareTag("Box"))
        {
            isBoxOnAltar = false;
            UpdateDoorState(); // Actualiza el estado de la puerta
        }
    }

    void UpdateDoorState()
    {
        if (isBoxOnAltar)
        {
            // Abrir puerta
            doorClosed.SetActive(false);
            doorOpened.SetActive(true);
        }
        else
        {
            // Cerrar puerta
            doorClosed.SetActive(true);
            doorOpened.SetActive(false);
        }
    }
}
