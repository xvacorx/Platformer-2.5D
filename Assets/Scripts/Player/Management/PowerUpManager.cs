using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class PowerUpManager : MonoBehaviour
{
    public int jumps = 0;
    public int dashes = 0;
    public int stomps = 0;

    VisualBehaviours visual;
    private void Start()
    {
        visual = GetComponent<VisualBehaviours>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Jump":
                jumps++;
                Destroy(other.gameObject);
                if (jumps >= 3) jumps = 3;
                Debug.Log("Jump collected");
                break; // Jumps

            case "Dash":
                dashes++;
                Destroy(other.gameObject);
                if (dashes >= 3) dashes = 3;
                Debug.Log("Dash collected");
                break; // Dashes

            case "Stomp":
                stomps++;
                Destroy(other.gameObject);
                if (stomps >= 3) stomps = 3;
                Debug.Log("Stomp collected");
                break; // Stomps

            case "Collectible":
                Debug.Log("Collectible collected");
                visual.CollectableEffect();
                Destroy(other.gameObject);
                break; // Collectibles

            default:
                Debug.Log("Unknown item");
                break;
        }
    }
}