using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Megabot : MonoBehaviour,IHit
{
    Rigidbody2D rb;
    Animator anim;
    float dirX, moveSpeed = 1.5f;
    float firing, fireRate = 1f;
    bool facingRight = true;
    bool isHit = false;
    float timer = 10;
    Renderer rend;
    Color c;
  


    Vector3 localScale;
    Vector3 startPos;

    [SerializeField]
    public static int health = 100;
    public  int newhealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        startPos = transform.position;
        //getGameObjects();
        health = 100;
        newhealth = 100;
        //mega = GameObject.Find("Megabot");
       // Debug.Log(mega);
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
        if (dirX > 0 && !facingRight) //If input is right, but character is facing left, flip.
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

    public void TakeHit()
    {
        Debug.Log("hit");
        if (health > 0 || newhealth > 0)
        {
            health -= 25;
            newhealth -= 25;
        }
        
       /* if(health <= 0)
        {
            Debug.Log("death");

        }*/

        die();
    }

    void die(){
        if ( newhealth <= 0){
           // health = 100;
           //newhealth = 100;
          // GameObject.Find("Megabot").SetActive(false);
       

           
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           transform.position = startPos;
           health = 100;
           newhealth = 100;
           //Debug.Log("DEAD");
         
        }
    }

 

    void healthGen(){
        if (health < 100 && health > 0){ //if player is still alive but not at max health
            if (isHit == true){ //if player gets hit, resets timer countdowon for regeneration of health
                timer = 15;
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
                        newhealth += 2;
                    }
                }
            }
            // Debug.Log(timer);
            // Debug.Log(health);
        }
            
    }
}
