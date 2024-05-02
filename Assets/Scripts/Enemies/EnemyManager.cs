using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject deathEffect;

    public Vector3 effectRotation;
    public void Defeated()
    {
        Quaternion rotationQuat = Quaternion.Euler(effectRotation);

        GameObject death = Instantiate(deathEffect, transform.position, rotationQuat);
        Destroy(death, 3f);

        Destroy(gameObject);
    }
}
