using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")] 
    public float Health;
    public float Mana;

    [Header("Animation States")] 
    public bool isDead;
    
    [Header("Abilities")]
    public bool isTelekinetic;
    
    
    [SerializeField] private float moveSpeed = 5f;  
    [SerializeField] private float jumpForce = 10f; 
    [SerializeField] private float shrinkScale = 0.5f;  
    [SerializeField] private float growScale = 2f; 

    private Rigidbody2D rb; 
    private bool isGrounded = false; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveVelocity = rb.velocity;
        moveVelocity.x = moveInput * moveSpeed;

        rb.velocity = moveVelocity;

        if (Input.GetButtonDown("Jump") && isGrounded) rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.Q)) transform.localScale *= shrinkScale;
        
        if (Input.GetKeyDown(KeyCode.E)) transform.localScale *= growScale;
    }

    public void TakeDamage(float damage)
    {
        if (Health > 0) Health -= damage;
        else isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }
}
