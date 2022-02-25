using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    [SerializeField]
    public Image HealthFullPrefab;
    [SerializeField]
    public Image HealthEmptyPrefab;
    [SerializeField]
    public Image HealthHalfPrefab;

    // Start is called before the first frame update
    void Start()
    {
        HeroController heroController = FindObjectOfType<HeroController>();
        heroController.RegisterPlayerDamageHandler(HandlePlayerHealthUpdate);
        HandlePlayerHealthUpdate(heroController.MaxHealth, heroController.CurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandlePlayerHealthUpdate(int maxHealth, int currentHealth) {
        foreach (Transform existingHealthIndicator in transform) {
            Destroy(existingHealthIndicator.gameObject);
        }
        int currentlyDisplayedMaxHealth = 0;
        int currentlyDisplayedCurrentHealth = 0;
        while (currentlyDisplayedMaxHealth < maxHealth) {
            if (currentlyDisplayedCurrentHealth + 2 <= currentHealth) {
                Instantiate(HealthFullPrefab, transform);
                currentlyDisplayedCurrentHealth += 2;
            } else if (currentlyDisplayedCurrentHealth + 1 <= currentHealth) {
                Instantiate(HealthHalfPrefab, transform);
                currentlyDisplayedCurrentHealth += 1;
            } else {
                Instantiate(HealthEmptyPrefab, transform);
            }
            currentlyDisplayedMaxHealth += 2;
        }
    }
}
