using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    /// <summary>
    /// Carga la escena de introducción.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("IntroductionScene"); // Cambia "IntroductionScene" por el nombre de tu escena de introducción.
    }

    /// <summary>
    /// Cierra el juego.
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
