using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    public int DamageAmount = 1;

    private List<int> HitEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() {
        HitEnemies = new List<int>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        foreach (var component in collision.gameObject.GetComponents<MonoBehaviour>()) {
            if (component is IEnemy) {
                IEnemy enemy = (IEnemy) component;
                if (HitEnemies.Contains(component.GetInstanceID())) {
                    continue;
                }
                enemy.TakeDamage(DamageAmount);
                HitEnemies.Add(component.GetInstanceID());
            }
        }
    }
}
