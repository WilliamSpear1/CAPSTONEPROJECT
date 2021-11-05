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
    public float health = 100;
    bool isHit = false;
    float timer = 10;

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

        healthGen();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);    
    }

    void LateUpdate()
    {
        if(dirX > 0 && !facingRight) //If input is right, but character is facing left, flip.
        { 
           Flip();
        }

        if(dirX < 0 && facingRight) //If input is left, but character is facing right, flip.
        {
            Flip();
        }
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

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);

        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        //if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        //localScale.x *= -1;
     
        //transform.localScale = localScale;
    }

       /*void OnTriggerEnter2D(Collider2D collider){
            if (collider.gameObject.name.Substring(0,17) == "Blue Flying Enemy"){ //checks the name of the object that hits the character
                   health -= 20;
                   isHit = true;
                  // Debug.Log(health);
                
       
            }
        }*/
        void TakeHit() { 
    
        }

        void healthGen(){
            if (health < 100 && health > 0){ //if player is still alive but not at max health
                if ( isHit == true){ //if player gets hit, resets timer countdowon for regeneration of health
                    timer = 10;
                    isHit = false;
                }
                else {
                    if (timer >= 0){
                        timer -= Time.deltaTime; //counts down from whatever timer is set at
                    }
                    else{
                        if (health + 2 > 100){ //if health goes over max, player has max health
                            health = 100;
                        }
                        else {
                            timer = 1;
                            health += 2; //adds two points to players health after every 1 second
                        }
                    }
                }
               // Debug.Log(timer);
               // Debug.Log(health);
            }
            
        }

        
}
