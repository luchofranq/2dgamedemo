using System.Collections; // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroductionManager : MonoBehaviour
{
    public Image[] storyImages; // Imágenes de la introducción
    public TMP_Text storyText; // Texto que muestra la historia
    public TMP_Text blinkingText; // Texto parpadeante ("Presiona ESPACIO para continuar")

    [TextArea(3, 5)]
    public string[] storyTexts; // Textos para cada imagen

    public float typingSpeed = 0.05f; // Velocidad de escritura del texto
    public float blinkingInterval = 0.5f; // Intervalo de parpadeo para el texto

    private int currentIndex = 0; // Índice actual en la secuencia de imágenes/textos
    private bool isTyping = false; // Para evitar interrupciones al escribir el texto
    private Coroutine typingCoroutine; // Para controlar el texto progresivo

    private void Start()
    {
        blinkingText.gameObject.SetActive(true); // Mostrar texto parpadeante al inicio
        StartCoroutine(BlinkText()); // Iniciar parpadeo continuo
        ShowStoryImage(0); // Mostrar la primera imagen y texto
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // Si el texto está escribiéndose, mostrar todo de inmediato
                StopCoroutine(typingCoroutine);
                CompleteText();
            }
            else
            {
                // Si el texto ya terminó, avanzar al siguiente
                AdvanceStory();
            }
        }
    }

    private void ShowStoryImage(int index)
    {
        // Ocultar todas las imágenes
        foreach (var img in storyImages)
        {
            img.gameObject.SetActive(false);
        }

        // Mostrar la imagen actual
        storyImages[index].gameObject.SetActive(true);

        // Iniciar la escritura del texto asociado
        storyText.text = ""; // Limpiar el texto previo
        typingCoroutine = StartCoroutine(TypeText(storyTexts[index])); // Escribir texto progresivamente
    }

    private IEnumerator TypeText(string text)
    {
        isTyping = true;

        foreach (char c in text)
        {
            storyText.text += c; // Añadir cada carácter
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false; // Finalizó la escritura
    }

    private void CompleteText()
    {
        // Completar el texto actual instantáneamente
        storyText.text = storyTexts[currentIndex];
        isTyping = false;
    }

    private void AdvanceStory()
    {
        currentIndex++;

        if (currentIndex < storyImages.Length)
        {
            ShowStoryImage(currentIndex); // Mostrar la siguiente imagen y texto
        }
        else
        {
            // Cambiar a la siguiente escena cuando se acaben las imágenes
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        }
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            blinkingText.enabled = !blinkingText.enabled; // Alternar visibilidad
            yield return new WaitForSeconds(blinkingInterval);
        }
    }
}
