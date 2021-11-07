using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonTrigger : MonoBehaviour
{


    private ICollsionHandler handler;
    private void Start()
    {
        handler = GetComponentInParent<ICollsionHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        handler.CollisionEnter(gameObject.name, collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        handler.CollisionExit(gameObject.name, collision.gameObject);
    }
}
