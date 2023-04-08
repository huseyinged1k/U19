using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 0.1f;
    public Vector3 offset;
    public float camShiftX = 5;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        camShiftX = 5f;
        followSpeed = 0.01f;
    }

    
    void LateUpdate()
    {
        if (player.GetComponent<Player>().rb.velocity.x > 1) offset.x = camShiftX;
        else if(player.GetComponent<Player>().rb.velocity.x < -1) offset.x = -camShiftX;
        Vector3 targetLocation = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetLocation, followSpeed);
    }
}
