using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = -1.8f;
    private  Vector2 direction;
    public Rigidbody2D rb;

    private Transform target;

    [SerializeField]
    private string TargetTag;
    public void Start()
    {
        if (GetComponent<SpriteRenderer>().flipX) { 
            speed *= 1;

        }
        else if (!GetComponent<SpriteRenderer>().flipX) {
            speed *= -1;
        }
        rb.velocity = transform.right * speed;
    
    }

    public void Setup(Vector2 direction) {
        this.direction = direction;
        GetComponent<SpriteRenderer>().flipX = direction.x == 1 ? false : true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TargetTag)
        {
            collision.GetComponentInParent<IHit>().TakeHit();
        }
    }

}
