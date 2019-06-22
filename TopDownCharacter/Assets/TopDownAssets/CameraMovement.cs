using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraMvmt;

    [SerializeField]
    private Vector3 cameraOffset;

    public void CameraPosition(Vector3 playerPosition)
    {
        transform.position = playerPosition + cameraOffset;
        transform.LookAt(playerPosition);
    }

    
    void Update()
    {
        
    }
}
