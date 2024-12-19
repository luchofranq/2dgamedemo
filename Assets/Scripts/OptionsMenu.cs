using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Referencia al panel de opciones
    public GameObject optionsPopup;

    // Referencias a los botones para cambiar las configuraciones
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    // Almacena las resoluciones disponibles
    private Resolution[] resolutions;

    void Start()
    {
        // Configurar las opciones de resolución
        SetupResolutionOptions();

        // Configurar el estado inicial del popup (cerrado)
        optionsPopup.SetActive(false);

        // Sincronizar los valores iniciales de las opciones
        fullscreenToggle.isOn = Screen.fullScreen;
    }

    /// <summary>
    /// Abre el popup de opciones.
    /// </summary>
    public void OpenOptions()
    {
        optionsPopup.SetActive(true);
        Debug.Log("Popup de opciones abierto.");
    }

    /// <summary>
    /// Cierra el popup de opciones.
    /// </summary>
    public void CloseOptions()
    {
        optionsPopup.SetActive(false);
        Debug.Log("Popup de opciones cerrado.");
    }

    /// <summary>
    /// Configura las opciones de resolución en el Dropdown.
    /// </summary>
    private void SetupResolutionOptions()
    {
        resolutions = Screen.resolutions; // Obtiene las resoluciones soportadas por el monitor
        resolutionDropdown.ClearOptions(); // Limpia opciones previas

        // Convierte las resoluciones a una lista de texto
        var resolutionOptions = new System.Collections.Generic.List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            // Detecta la resolución actual
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions); // Agrega opciones al Dropdown
        resolutionDropdown.value = currentResolutionIndex; // Selecciona la resolución actual
        resolutionDropdown.RefreshShownValue(); // Refresca el Dropdown
    }

    /// <summary>
    /// Cambia la resolución del juego basada en el Dropdown.
    /// </summary>
    /// <param name="resolutionIndex">Índice de la resolución seleccionada.</param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        Debug.Log("Resolución cambiada a: " + selectedResolution.width + "x" + selectedResolution.height);
    }

    /// <summary>
    /// Activa o desactiva el modo de pantalla completa.
    /// </summary>
    /// <param name="isFullscreen">Estado del toggle de pantalla completa.</param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Pantalla completa: " + isFullscreen);
    }
}
