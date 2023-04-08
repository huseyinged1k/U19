using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 0.1f;
    public float camRange;    
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        camRange = transform.position - player.position;
    }

    
    void LateUpdate()
    {
        Vector3 targetLocation = player.position + camRange;
        transform.position = Vector3.Lerp(transform.position, targetLocation, followSpeed);
    }
}
