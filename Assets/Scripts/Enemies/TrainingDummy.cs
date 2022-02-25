using UnityEngine;

public class TrainingDummy : MonoBehaviour, IEnemy
{
    [SerializeField]
    public int MaxHealth = 1;
    [SerializeField]
    public int CurrentHealth = 1;

    private void Start() {
        CurrentHealth = MaxHealth;
    }

    private void Update() {
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    public void TakeDamage(int damageAmount) {
        CurrentHealth -= damageAmount;
    }

    public void Die() {
        Destroy(gameObject);
    }

    public void EnemyMove()
    {

    }
}
