using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float dieTime, damage,speed;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
;   }
    IEnumerator CountDownTimer() {
        yield return new WaitForSeconds(1);
        Die();
    }
    public void Die() {
        Destroy(gameObject);
    }
}
