using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void TakeDamage(int damageTaken);
    void Die();
    void EnemyMove();
}
