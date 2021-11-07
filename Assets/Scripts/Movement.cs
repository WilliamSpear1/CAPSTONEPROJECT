using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.3f;
    
    [SerializeField]
    private Vector3[] positions;

    private int index;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], Time.fixedDeltaTime * speed);

        if (transform.position == positions[index]) {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else {
                index++;
            }
        }
    }
}
