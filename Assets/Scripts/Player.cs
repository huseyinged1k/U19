using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")] 
    public float Health;

    [Header("Animation States")] 
    public bool isDead;
    public bool isHurt;
    
    [Header("Abilities")]
    public bool isTelekinetic;

    public bool gameOver;
    [SerializeField] private float moveSpeed = 5f;  
    [SerializeField] private float jumpForce = 10f; 
    [SerializeField] private float shrinkScale = 0.5f;  
    [SerializeField] private float growScale = 2f; 

    [HideInInspector] public Rigidbody2D rb; 
    [HideInInspector] public bool isGrounded = false; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDead || isTelekinetic) return;

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveVelocity = rb.velocity;
        moveVelocity.x = moveInput * moveSpeed;
        rb.velocity = moveVelocity;
        if (rb.velocity.x >= 0 && moveInput != 0) gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if(moveInput != 0) gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        
        if (Input.GetButtonDown("Jump") && isGrounded) rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.Q)) transform.localScale *= shrinkScale;
        
        if (Input.GetKeyDown(KeyCode.E)) transform.localScale *= growScale;
    }

    public void TakeDamage(float damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            isHurt = true;
            isTelekinetic = false;
        }
        else isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) isGrounded = false;
    }
}
