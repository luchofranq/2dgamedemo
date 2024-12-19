using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D
    private Animator animator; // Referencia al Animator
    private Vector2 movement; // Movimiento del jugador

    // Parámetros de animación
    private static readonly int WalkDown = Animator.StringToHash("WalkDown");
    private static readonly int WalkLeft = Animator.StringToHash("WalkLeft");
    private static readonly int WalkRight = Animator.StringToHash("WalkRight");
    private static readonly int WalkUp = Animator.StringToHash("WalkUp");
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");

    void Start()
    {
        // Obtener el componente Rigidbody2D y Animator
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Leer las entradas de teclado para mover al jugador
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Actualizar los parámetros del Animator
        animator.SetFloat(Horizontal, movement.x);
        animator.SetFloat(Vertical, movement.y);

        // Solo activamos la animación de caminar si el jugador se mueve
        bool isWalking = movement.sqrMagnitude > 0; // Comprobamos si hay movimiento
        animator.SetBool(IsWalking, isWalking); // Solo camina si hay movimiento
    }

    void FixedUpdate()
    {
        // Mover al jugador con el Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
