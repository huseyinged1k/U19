using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float speed = 3f;
    public float attackRange = 1f; 
    public float damage = 1f;
    public float visionRange = 5f;

    [Header("Animation States")] 
    public bool isIdle;
    public bool isAttack;
    public bool isRun;
    
    private Transform player;
    private Vector2 startPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange) Attack();
        else if (distanceToPlayer <= visionRange)
        {
            LookAtPlayer();
            MoveTowardsPlayer();
        }
        else if (!isIdle) MoveToStartPosition();
        
        
    }

    void MoveToStartPosition()
    {
        isRun = true;
        transform.position = Vector2.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, startPosition) <= 0.1f)
        {
            isIdle = true;
            isRun = false;
            transform.rotation = Quaternion.identity;
        }
    }
    void MoveTowardsPlayer()
    {
        isRun = true;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void LookAtPlayer()
    {
        Vector2 direction = (Vector2)player.position - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Attack()
    {
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            isRun = false;
            isAttack = true;
            playerScript.TakeDamage(damage);
            return;
        }

        isAttack = false;
    }
}
