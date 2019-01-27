using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    PlayerController player;
    Invintory inventory;
    SpriteRenderer flashLight;

    bool on = false;

    // Start is called before the first frame update
    void Start(){
        inventory = GameObject.Find("Game_maniger").GetComponent<Invintory>();
        player = GetComponentInParent<PlayerController>();
        flashLight = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update(){

        if(inventory.things[0]) {
            //if (!on) {
                flashLight.enabled = true;
                //on = true;
            //} 
            //else {
            //    flashLight.enabled = false;
            //    on = false;
            //}
        }


    }
}
