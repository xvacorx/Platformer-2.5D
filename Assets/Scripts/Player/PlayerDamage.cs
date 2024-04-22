using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float stompAreaRadius = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (IsDashing())
            {
                Destroy(other.gameObject);
            }

            if (IsStomping())
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsStomping() && collision.gameObject.CompareTag("Ground"))
        {
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
    }

    private bool IsDashing()
    {
        // Implementa la l�gica para verificar si el jugador est� dasheando
        return false; // Placeholder, reempl�zalo con tu l�gica real
    }

    private bool IsStomping()
    {
        // Implementa la l�gica para verificar si el jugador est� haciendo stomp
        return false; // Placeholder, reempl�zalo con tu l�gica real
    }
}
