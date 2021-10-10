using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megabot : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 1.5f;
    float firing, fireRate = 1f;
    bool facingRight = true;

    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * 200f);

        SetAnimationState();

        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        firing = Input.GetAxisRaw("Fire1") * fireRate;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);    
    }

    void LateUpdate()
    {
        CheckWhereToFace();    
    }

    void SetAnimationState()
    {
        if(dirX == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkShooting", false);

            if (Mathf.Abs(firing) == 1)
                anim.SetBool("isIdleShooting", true);
            else
                anim.SetBool("isIdleShooting", false);
        }

        if (rb.velocity.y == 0)
            anim.SetBool("isJumping", false);

        if (Mathf.Abs(dirX) == 1.5 && rb.velocity.y == 0)
        {
            anim.SetBool("isIdleShooting", false);

            if (Mathf.Abs(firing) == 1)
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isWalkShooting", true);
            }
            else
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isWalkShooting", false);
            }
        }

        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);

    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }
}
