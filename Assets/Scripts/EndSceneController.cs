using UnityEngine;
using UnityEngine.SceneManagement;  // Para cargar escenas

public class EndSceneController : MonoBehaviour
{
    // Opcional: Puedes usar un texto para un mensaje o título al final
    public GameObject endText; // Un GameObject de texto que se activa en la escena final
    private float timer = 5f; // Tiempo que esperará antes de cambiar de escena (en segundos)

    void Start()
    {
        // Opcional: Si tienes un texto, activarlo cuando inicie la escena
        if (endText != null)
        {
            endText.SetActive(true);
        }
    }

    void Update()
    {
        // Temporizador para cambiar de escena automáticamente después de 5 segundos
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            // Cambiar a la escena de inicio, puedes personalizar el nombre de la escena aquí
            SceneManager.LoadScene("MainMenu");  // Reemplaza "StartScene" con tu escena de inicio
        }
    }
}
