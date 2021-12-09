using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject sparkBulletPrefab;
    public GameObject crossBulletPrefab;
    public GameObject chargedBulletPrefab;
    public int crossUnlock; //starts at 0 and changes to 1 when charged item is pickup during level
    public int chargedUnlock; //starts at 0 and changes to 1 when charged item is pickup during level

    [SerializeField]
    public int bulletType = 0;     //Default bullet type is 0. 0 = spark, 1 = cross, 2 = charged

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletType = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && crossUnlock == 1) //can only be switched to once unlocked
        {
            bulletType = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && chargedUnlock == 1) //can only be switched to once unlocked
        {
            bulletType = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.tag == "CrossPickup")
        {
            bulletType = 1;
            crossUnlock = 1;
        }

        if (collision.tag == "ChargedPickup")
        {
            bulletType = 2;
            chargedUnlock = 1;
        }
    }

    void Shoot()
    {
        if (bulletType == 0)
        {
            GameObject bullet = Instantiate(sparkBulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bullet, 1);
        }
        if (bulletType == 1)
        {
            GameObject bullet = Instantiate(crossBulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bullet, 1.75f);
        }
        if (bulletType == 2)
        {
            GameObject bullet = Instantiate(chargedBulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bullet, 2);

        }
    }
}
   
