using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellBeast : MonoBehaviour
{
    /*[SerializeField]
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

    private int health = 100;

    private void //Update()
    {
        Attack();
        LookAtTarget();
    }
    private void Attack()
    {
        if (!canAttack)
        {
            timeSinceLastAttack += Time.deltaTime;

        }

        if (timeSinceLastAttack >= coolDown)
        {
            canAttack = true;
        }

        if (canAttack && target != null )
        {
            canAttack = false;
            timeSinceLastAttack = 0;
            animator.SetBool("Attack", true);
        }
    }
    public void StopShooting()
    {
        animator.SetBool("Attack", false);
    }

    public void Shoot()
    {
        GameObject go = Instantiate(fireBreathPrefab, mouth.position, Quaternion.identity);
        Vector3 direction = new Vector3(transform.localScale.x, 0);
        go.GetComponent<FireBall>().Setup(direction);
        Destroy(go, 1);
    }

    private void LookAtTarget()
    {
        if (target != null)
        {
            Vector3 scale = transform.localScale;
            scale.x = target.transform.position.x < transform.position.x ? 1 : -1;
            transform.localScale = scale;
        }
    }
    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "BattleArea" && other.tag == "Player")
        {
            if (target == null)
            {
                this.target = other.transform;
            }
        }
        if (colliderName == "shotPos" && other.tag == "Player")
        {
            Debug.Log("inside if statment");
            other.GetComponent<Megabot>().TakeHit();
        }
    }

    public void CollisionExit(string colliderName, GameObject other)
    {
        if (colliderName == "BattleArea" && other.tag == "Player")
        {
            target = null;
        }
    }

    public void TakeHit()
    {
        health -= 50;


        if (health == 0)
            animator.SetBool("Dead", true);
    }*/

}
