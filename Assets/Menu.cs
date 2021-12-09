using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    GameObject names;
    GameObject menu;
    GameObject controls;
    bool active;
   
    // Start is called before the first frame update
    void Start()
    {
        names = GameObject.Find("Creator Names");
        menu = GameObject.Find("Menu");
        controls = GameObject.Find("ControlsTab");
        controls.SetActive(false);
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

    public void showControls(){
        menu.SetActive(false);
        controls.SetActive(true);
    }

    public void goBack(){
        menu.SetActive(true);
        controls.SetActive(false);
    }

   
}
