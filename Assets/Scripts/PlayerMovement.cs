using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private float movementX = 0f;
    private float movementY = 0f; 
    private Rigidbody2D rigidBody;
    public int health = 100;
    


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
  
        moveWithKeys();
       
    }

    void moveWithKeys(){
        movementX = Input.GetAxis("Horizontal");
        if (movementX > 0f){
            rigidBody.velocity = new Vector2(movementX*speed,rigidBody.velocity.y);
        }
        else if (movementX < 0f) {
            rigidBody.velocity = new Vector2(movementX*speed, rigidBody.velocity.y);
        }
        else{
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
        }

        movementY = Input.GetAxis("Vertical");
        if (movementY > 0f){
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,movementY*speed);
        }
        else if (movementY < 0f) {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, movementY*speed);
        }
        else{
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
        }
    }
}
