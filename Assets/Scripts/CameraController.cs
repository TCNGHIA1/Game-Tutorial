using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float start, end;// gioi han map
    void Update()
    {
        var camX = transform.position.x;
        //Check position player and camera
        if(playerTransform.position.x >start && playerTransform.position.x < end)
        {
            camX = playerTransform.position.x;
        }
        else
        {
            if (start > playerTransform.position.x)
            {
                camX = start;
            }
            if(end<playerTransform.position.x)
            {
                camX = end;
            }
        }
        var camY = transform.position.y;
        //Update position for camera
        transform.position = new Vector3(camX,camY,transform.position.z);    
    }
}
