using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private int damage = 50;
    private Vector2 direction;

    private Transform target;

    [SerializeField]
    private string TargetTag;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    /*void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);        //This will output in log what the bullet collides with (if anything)
       BlueFlyingEnemy enemy = hitInfo.GetComponent<BlueFlyingEnemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TargetTag)
        {
            collision.GetComponentInParent<IHit>().TakeHit();
            Destroy(gameObject);
        }
    }
}
