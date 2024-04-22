using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int jumps = 0;
    public int dashes = 0;
    public int stomps = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jump"))
        {
            jumps++; Destroy(other.gameObject); if (jumps >= 3) { jumps = 3; }
        } // Jumps Manager

        else if (other.gameObject.CompareTag("Dash"))
        {
            dashes++; Destroy(other.gameObject); if (dashes >= 3) { dashes = 3; }
        } // Dashes Manager

        else if (other.gameObject.CompareTag("Stomp"))
        {
            stomps++; Destroy(other.gameObject); if (stomps >= 3) { stomps = 3; }
        } // Stomps Manager

        else if (other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Collected"); Destroy(other.gameObject);
        } // Collectibles Manager

        else
        {
            Debug.Log("Unkown Item");
        }
    }
}