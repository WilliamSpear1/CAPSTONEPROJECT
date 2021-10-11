using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFlyingEnemy : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    Transform player;

    [SerializeField]
    float argoRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    [SerializeField]
    public int health = 100;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer > argoRange)
        {
            ChasePlayer();
        }
        else 
        {
            StopChasingPlayer();
        }
    }

    private void StopChasingPlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //Enemy is to the left side of player move to the right
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }
        else 
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
        
    }

    private void ChasePlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
    public void TakeDamage(int damage) {
        health -= damage;
        if (health < 0) {
            Die();
        }
    }

    void Die() {
        anim.SetBool("isHit", true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Megabot megabot = collision.collider.GetComponent<Megabot>();
        Bullet bullet = collision.collider.GetComponent<Bullet>();

        if (megabot != null)
        {
            anim.SetBool("isHit", true); 
    
        }
       
    }
    
}
