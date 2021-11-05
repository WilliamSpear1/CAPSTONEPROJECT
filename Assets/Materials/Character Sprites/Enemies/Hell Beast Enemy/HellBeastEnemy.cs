using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBeastEnemy : MonoBehaviour
{
    Animator anim;

    Rigidbody2D rb2d;
    private bool canShoot;
    public float timeBTWShots,shootspeed;

    [SerializeField]
    public int health = 100;

    [SerializeField]
    public float argoRange;

    [SerializeField]
    Transform player,shootPos;
 

    public GameObject fireBall;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        canShoot = true;
     
    }
    private void LateUpdate()
    {
        
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= argoRange){
            if (canShoot) { 
            StartCoroutine(Shoot());
            
            }
        }
    }
    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }


    
    IEnumerator Shoot() {
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newfireBall = Instantiate(fireBall, shootPos.position, Quaternion.identity);
        newfireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.position.x * shootspeed * Time.fixedDeltaTime, 0f);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetBool("isNear", true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Megabot megabot = collision.collider.GetComponent<Megabot>();
        Bullet bullet = collision.collider.GetComponent<Bullet>();

        if (megabot != null)
        {
            anim.SetBool("isNear", true);

        }

    }
}
