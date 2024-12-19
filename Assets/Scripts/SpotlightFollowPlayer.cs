using UnityEngine;

public class SpotlightFollowPlayer : MonoBehaviour
{
    public Transform player;  // Asigna el Transform del jugador desde el Inspector.
    public Vector3 offset = new Vector3(0, 3, 0);  // Ajusta este valor para la distancia entre el jugador y la luz.
    public float followSpeed = 5.0f;  // Velocidad con la que la luz sigue al jugador.

    void Update()
    {
        // Comprobar si el jugador está asignado
        if (player != null)
        {
            // Actualizar la posición del Spotlight para seguir al jugador con el offset especificado.
            Vector3 targetPosition = player.position + offset;

            // Usar Lerp para suavizar el movimiento de la luz y hacer que siga al jugador
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Aquí eliminamos cualquier rotación sobre el eje X o Y
            transform.rotation = Quaternion.Euler(0, 0, 0); // Esto asegura que no haya rotación en los ejes X, Y o Z
        }
    }
}
