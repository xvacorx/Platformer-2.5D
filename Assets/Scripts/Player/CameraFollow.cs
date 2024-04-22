using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    private bool followPlayer = true;
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
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }
}