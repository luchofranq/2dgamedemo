using UnityEngine;

public class PushableBox : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // El Rigidbody2D ya maneja la física, no necesitamos lógica extra aquí.
        // Asegúrate de que el jugador pueda empujar moviéndose hacia la caja.
    }
}
