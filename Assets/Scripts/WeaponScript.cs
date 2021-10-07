using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
   public GameObject [] weaponsList;
   private int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        weaponsList = new GameObject[0];
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("r")){
            if (weaponsList.Length > 0){
                weaponsList[0].SetActive(true);
                weaponsList[currentWeapon].SetActive(false);
                currentWeapon = 0;
            }
        } */
        
    }

        void OnTriggerEnter2D(Collider2D collider){
            if (collider.gameObject.name == "Character"){
                   //Debug.Log("Triggered");
                this.transform.parent = GameObject.Find("Character").transform;
                this.gameObject.SetActive(false);
                resizeArr();
       
            }
        }

        void resizeArr(){
            Debug.Log(weaponsList.Length);
            GameObject [] temp = new GameObject[weaponsList.Length + 1];
            for ( int i = 0; i < weaponsList.Length; i++){
                temp[i] = weaponsList[i];
            }
            temp[weaponsList.Length] = this.gameObject;
            weaponsList = new GameObject[temp.Length];
            weaponsList = temp;
            Debug.Log( weaponsList[0]);
        }
}
