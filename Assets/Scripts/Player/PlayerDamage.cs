using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    public int MaxHealth;
    [SerializeField]
    public int CurrentHealth;

    private bool hasTakenDebugDamage = false;
    public delegate void RegisterPlayerDamage(int maxHealth, int currentHealth);
    private RegisterPlayerDamage playerDamageHandlers;
    private Button.ButtonClickedEvent takeDamageDebugDelegate;

    public void TakeDamageDebug() {
        if (!hasTakenDebugDamage) {
            TakeDamage(1);
        }
        hasTakenDebugDamage = true;
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
