using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool IsCharacterMoving = false;
    private Vector2 MovementVector = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    public float MovementSpeed = 5;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Is Moving", false);
    }

    public void FixedUpdate() {
        rb.MovePosition(rb.position + (MovementVector * MovementSpeed * Time.fixedDeltaTime));
    }

    public void MoveCharacter(InputAction.CallbackContext callbackContext) {
        MovementVector = callbackContext.ReadValue<Vector2>();
        if (MovementVector == Vector2.zero) {
            IsCharacterMoving = false;
        } else {
            IsCharacterMoving = true;
        }
        animator.SetBool("Is Moving", IsCharacterMoving);
        animator.SetFloat("Horizontal", MovementVector.x);
        animator.SetFloat("Vertical", MovementVector.y);
    }
}
