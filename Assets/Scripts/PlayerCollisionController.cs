
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionController : MonoBehaviour
{
    int score=0;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            score += 100;
        }
        else if(collision.gameObject.tag == "enemy")
        {
            player.TakeDamage(10);
        }
        else if (collision.gameObject.tag == "End")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy") player.isHurt = false;
    }
}
