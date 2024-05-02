using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    float stompAreaRadius = 2f;

    PowerUpActions powerUpActions;
    private void Start()
    {
        powerUpActions = GetComponent<PowerUpActions>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyManager enemy))
        {
            if (powerUpActions.isDashing || powerUpActions.isStomping)
            {
                enemy.Defeated();
            }
            else { Debug.Log("Recibe Daño"); }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (powerUpActions.IsStomping() && collision.gameObject.CompareTag("Ground"))
        {
            powerUpActions.isStomping = false;
            StompAreaDamage();
        }
    }

    private void StompAreaDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, stompAreaRadius);
        foreach (Collider enemy in hitEnemies)
        {
            if (enemy.gameObject.TryGetComponent(out EnemyManager enemies))
            {
                enemies.Defeated();
            }
        }
    } // Stomp area damage
}
