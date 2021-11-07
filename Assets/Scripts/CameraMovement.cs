using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //public GameObject player;
    //public float offsetSmoothing;
    //private Vector3 playerPosition;
    Transform CamTransform;
    public Transform Player;
    float followspeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        CamTransform = Camera.main.transform;
    }

    // Update is called once per frame
<<<<<<< HEAD
    void LateUpdate()
=======
    void FixedUpdate()
>>>>>>> platforms
    {
        Vector3 targetPosition = new Vector3(Player.position.x, CamTransform.position.y, CamTransform.position.z);
        CamTransform.position = Vector3.Lerp(CamTransform.position, targetPosition, Time.deltaTime * followspeed);

        //playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
