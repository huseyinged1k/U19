
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    int score=0;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "coin")
        {
            score += 100;
        }
        else if(collision.tag == "enemy")
        {
            player.Health -= 1;
        }
    }
}
