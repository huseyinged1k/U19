using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    int score=0, heart=3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            score += 100;
        }
        else if(collision.tag == "enemy")
        {
            heart--;

        }
    }
}
