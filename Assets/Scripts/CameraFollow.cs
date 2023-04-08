using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 0.1f;
    public Vector3 offset;    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

    
    void LateUpdate()
    {
        Vector3 targetLocation = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetLocation, followSpeed);
    }
}
