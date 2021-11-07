using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDemon : MonoBehaviour,ICollsionHandler,IHit
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject fireBreathPrefab;

    [SerializeField]
    private Transform mouth;

    private Transform target;
    private bool canAttack = true;

    [SerializeField]
    private float coolDown;
    private float timeSinceLastAttack;

    public Rigidbody2D rb;

    [SerializeField]
    private float speed = 0.17f;

    [SerializeField]
    private Vector3[] positions;

    private int index;
    private int health = 100;

    private void Update()
    {
        Attack();
        LookAtTarget();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        if (canAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.fixedDeltaTime * speed);

            if (transform.position == positions[index])
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
    }

    private void Attack() {
        if (!canAttack) {
            timeSinceLastAttack += Time.deltaTime;

        }
        
        if (timeSinceLastAttack >= coolDown)
        {
            canAttack = true;
        }

        if (canAttack && target != null && Mathf.Abs(target.transform.position.y - transform.position.y) <= .1f){
            canAttack = false;
            timeSinceLastAttack = 0;
            animator.SetBool("Attack", true);
        }
    }

    public void StopShooting() {
        animator.SetBool("Attack", false);
    }

    public void Shoot() {
            GameObject go = Instantiate(fireBreathPrefab, mouth.position, Quaternion.identity);
            Vector3 direction = new Vector3(transform.localScale.x, 0);
            go.GetComponent<FireBreath>().Setup(direction);
            Destroy(go, 1);
    }

    private void LookAtTarget() {
        if (target != null) {
            Vector3 scale = transform.localScale;
            scale.x = target.transform.position.x < transform.position.x ? 1 : -1;
            transform.localScale = scale; 
        }
    }

    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "Sight" && other.tag == "Player") {
            if (target == null) {
                this.target = other.transform;
            }
        }
        if (colliderName == "Fire" && other.tag == "Player") {
            Debug.Log("inside if statment");
            other.GetComponent<Megabot>().TakeHit();
        }
    }

    public void CollisionExit(string colliderName, GameObject other)
    {
        if (colliderName == "Sight" && other.tag == "Player")
        {
            target = null;
        }
    }

    public void TakeHit()
    {
            health -= 50;


        if (health == 0)
            animator.SetBool("Dead", true);
    }
}
