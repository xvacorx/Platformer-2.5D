using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameManager manager;

    private Transform target;

    private bool followPlayer = true;

    float mapLimit = -10;
    public void ToggleFollow(bool state)
    {
        followPlayer = state;
    }

    private void LateUpdate()
    {
        if (followPlayer)
        {
            Vector3 newPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = newPosition;
        }
        if(target.position.y <= mapLimit) { followPlayer = false; manager.Lose(); }
        else { followPlayer = true; }
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }
}