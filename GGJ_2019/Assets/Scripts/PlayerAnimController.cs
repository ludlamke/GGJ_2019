using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    Animator anim;
    PlayerController player;

    bool moving;

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update(){
        //See if moving left or right
        if(player.left || player.right) {
            moving = true;
        } else {
            moving = false;
        }

        //update anim parameters
        anim.SetBool("isMoving", moving);

        //look to see if player is facing left or right
        if (player.left) {
            transform.localScale = new Vector2(-1, 1);
        } else if (player.right) {
            transform.localScale = new Vector2(1, 1);
        }


    }
}
