using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    private Vector2 MovementVector = Vector2.zero;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isAttackHeld = false;
    private float swordAttackCooldownRemaining = 0f;

    private bool hasTakenDebugDamage = false;
    public delegate void RegisterPlayerDamage(int maxHealth, int currentHealth);
    private RegisterPlayerDamage playerDamageHandlers;
    private Button.ButtonClickedEvent takeDamageDebugDelegate;

    [SerializeField]
    public float MovementSpeed = 5;
    [SerializeField]
    public Sword Sword;
    [SerializeField]
    public float SwingSpeed = 0.2f;
    [SerializeField]
    public float SwordAttackCooldownTime = 0.1f;
    [SerializeField]
    public int CurrentHealth = 6;
    [SerializeField]
    public int MaxHealth = 6;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        animator.SetFloat("MovementX", 0f);
        animator.SetFloat("MovementY", -1f);
    }

    void Update() {
        if (swordAttackCooldownRemaining <= 0) {
            if (animator.GetBool("IsAttacking")) {
                Sword.gameObject.SetActive(true);
                Sequence sequence = DOTween.Sequence();
                if (animator.GetFloat("MovementY") > 0) {
                    Sword.transform.localEulerAngles = new Vector3(0f, 0f, 50f);
                    sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 310f), SwingSpeed));
                } else if (animator.GetFloat("MovementY") < 0) {
                    Sword.transform.localEulerAngles = new Vector3(0f, 0f, 220f);
                    sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 130f), SwingSpeed));
                } else if (animator.GetFloat("MovementX") < 0) {
                    Sword.transform.localEulerAngles = new Vector3(0f, 0f, 130f);
                    sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 50f), SwingSpeed));
                } else {
                    Sword.transform.localEulerAngles = new Vector3(0f, 0f, 310f);
                    sequence.Append(Sword.transform.DOLocalRotate(new Vector3(0f, 0f, 220f), SwingSpeed));
                }
                sequence.OnComplete(StopAttack);
                sequence.Play();
            } else if (isAttackHeld) {
                animator.SetBool("IsAttacking", true);
            }
        } else {
            swordAttackCooldownRemaining -= Time.deltaTime;
        }
    }

    public void FixedUpdate() {
        if (animator.GetBool("IsMoving")) {
            Vector3 movePosition = rb.position + (MovementVector * MovementSpeed * Time.fixedDeltaTime);
            rb.MovePosition(movePosition);
        }
    }

    public void MoveCharacter(InputAction.CallbackContext callbackContext) {
        MovementVector = callbackContext.ReadValue<Vector2>();

        if (MovementVector == Vector2.zero) {
            animator.SetBool("IsMoving", false);
        } else {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MovementX", MovementVector.x);
            animator.SetFloat("MovementY", MovementVector.y);
        }
    }

    public void Attack(InputAction.CallbackContext callbackContext) {
        if (callbackContext.started) {
            isAttackHeld = true;
        } else if (callbackContext.canceled) {
            isAttackHeld = false;
        }
    }

    public void StopAttack() {
        animator.SetBool("IsAttackingSword", false);
        animator.SetBool("IsAttacking", false);
        Sword.gameObject.SetActive(false);
        swordAttackCooldownRemaining = SwordAttackCooldownTime;
    }

    public void TakeDamageDebug(InputAction.CallbackContext callbackContext) {
        if (callbackContext.started) {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int amount) {
        CurrentHealth -= amount;
        playerDamageHandlers(MaxHealth, CurrentHealth);

        if (CurrentHealth <= 0) {
            // Handle player death here.
        }
    }

    public void RegisterPlayerDamageHandler(RegisterPlayerDamage handler) {
        playerDamageHandlers += handler;
    }

    public void UnregisterPlayerDamageHandler(RegisterPlayerDamage handler) {
        playerDamageHandlers -= handler;
    }
}
