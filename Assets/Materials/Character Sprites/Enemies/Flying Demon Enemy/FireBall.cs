using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float dieTime, damage,speed;
    private  Vector2 direction;

    private Transform target;

    [SerializeField]
    private string TargetTag;

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
