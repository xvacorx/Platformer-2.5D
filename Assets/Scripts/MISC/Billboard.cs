using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private void Update()
    {
        Vector3 directionToCamera = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
    }
}
