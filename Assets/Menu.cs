using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    GameObject names;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        names = GameObject.Find("Creator Names");
        names.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void reveal(){
         if (active == false){
            names.SetActive(true);
            active = true;
         }
         else {
             names.SetActive(false);
             active = false;
         }
    }

    public void playGame(){
        SceneManager.LoadScene("Level1");
    }

   
}
