using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public GameObject healthB;
   public Slider bar;
    
    // Start is called before the first frame update
    void Start()
    {
      healthB = GameObject.Find("Megabot");
      bar = GetComponent<Slider>();
      bar.maxValue = 100;
      bar.value = 100;
      //Debug.Log(this.transform.parent.name);
    }
    //
    // Update is called once per frame
    void Update()
    {
        bar.value = healthB.GetComponent<Megabot>().newhealth;
        
    }

   
}
