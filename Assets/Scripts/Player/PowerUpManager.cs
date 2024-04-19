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
        if (other.gameObject.CompareTag("Jump")) { jumps++; Destroy(other.gameObject); }
        else if (other.gameObject.CompareTag("Dash")) { dashes++; Destroy(other.gameObject); }
        else if (other.gameObject.CompareTag("Stomp")) { stomps++; Destroy(other.gameObject); }
        else if (other.gameObject.CompareTag("Collectible")) { Debug.Log("Collected"); Destroy(other.gameObject); }
        else { Debug.Log("Unkown Item"); }
    }
}