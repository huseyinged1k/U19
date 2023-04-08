
using UnityEngine;

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
            player.Health -= 1;
        }
    }
}
