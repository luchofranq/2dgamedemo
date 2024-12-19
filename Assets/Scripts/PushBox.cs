using UnityEngine;

public class PushBox : MonoBehaviour
{
    public float pushForce = 5f; // Fuerza aplicada al empujar

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Detectar si el jugador está empujando una caja
        if (collision.collider.CompareTag("Box"))
        {
            // Obtener dirección del empuje
            Vector2 pushDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

            // Aplicar fuerza si hay movimiento del jugador
            if (pushDirection != Vector2.zero)
            {
                Rigidbody2D boxRigidbody = collision.collider.GetComponent<Rigidbody2D>();
                if (boxRigidbody != null)
                {
                    boxRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Force);
                }
            }
        }
    }
}
