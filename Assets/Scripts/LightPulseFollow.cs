using UnityEngine;

public class LightPulseFollow : MonoBehaviour
{
    public GameObject player;         // El personaje que seguirá la luz
    public Light lightSource;         // La luz que se moverá y cambiará de intensidad
    public float minIntensity = 1f;   // Intensidad mínima de la luz
    public float maxIntensity = 3f;   // Intensidad máxima de la luz
    public float pulseSpeed = 1f;     // Velocidad de la palpitación (el tiempo para un ciclo completo)
    public float followSpeed = 5f;    // Velocidad con la que la luz sigue al jugador

    private float time = 0f;

    void Update()
    {
        // Hacer que la luz siga al personaje (jugador)
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Calcular la intensidad de la luz (basado en un ciclo de palpitación)
        time += Time.deltaTime * pulseSpeed;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(time) + 1f) / 2f);

        // Aplicar la intensidad calculada a la luz
        lightSource.intensity = intensity;
    }
}
