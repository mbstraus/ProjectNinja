using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemy
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField]
    public float MovementSpeed = 5;
    [SerializeField]
    public int MaxHealth = 2;
    [SerializeField]
    public int CurrentHealth = 2;
    [SerializeField]
    public Vector2 MovementVector = Vector2.zero;

   public void Start()
        {
            CurrentHealth = MaxHealth;
            MovementVector = Vector2.up;
            rb = GetComponent<Rigidbody2D>();
        }
    public void FixedUpdate()
        {
        rb.MovePosition(rb.position + (MovementVector * MovementSpeed * Time.fixedDeltaTime));     
        if (CurrentHealth <= 0)
            {
                Die();
            }
        }

    public  void TakeDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;
        }

    public void Die()
        {
            Destroy(gameObject);
        }

    public void EnemyMove()
        {
   
    
        }

    public void OnCollisionEnter2D(Collision2D col)
        {
            if (MovementVector == Vector2.up)
            {
                MovementVector = Vector2.down;
            }
            else
            {
                MovementVector = Vector2.up;
            }
        }
    }