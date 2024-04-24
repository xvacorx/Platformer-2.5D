using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float stompAreaRadius = 1f;

    PowerUpActions powerUpActions;
    private void Start()
    {
        powerUpActions = GetComponent<PowerUpActions>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (powerUpActions.IsDashing())
            {
                Destroy(other.gameObject);
            }

            if (powerUpActions.IsStomping())
            {
                Destroy(other.gameObject);
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
            if (enemy.CompareTag("Enemy"))
            {
                Destroy(enemy.gameObject);
            }
        }
    } // Stomp area damage
}
