﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDetector : MonoBehaviour {

    public bool isGrounded;
    public bool leftWall;
    public bool rightWall;

    Vector2 baseCoord;

    RaycastHit2D[] groundHit = new RaycastHit2D[3];
    RaycastHit2D[] leftWallHit = new RaycastHit2D[3];
    RaycastHit2D[] rightWallHit = new RaycastHit2D[3];

    LayerMask groundMask;


    // Use this for initial8lization
    void Start () {
        groundMask = LayerMask.GetMask("Ground");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        isGrounded = GroundCast();
        WallCast();
	}

    //This method creates and displays Raycasts to detect ground under the player
    bool GroundCast() {
         //We need to clear the array everytime loop
        Array.Clear(groundHit, 0, 3);

        //Cast rays and store hit info in groundHit array
        groundHit[1] = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.1f), Vector2.down, 0.2f, groundMask);
        groundHit[2] = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.1f), Vector2.down, 0.2f, groundMask);
        groundHit[0] = Physics2D.Raycast(new Vector2(transform.position.x - 0.5f, transform.position.y + 0.1f), Vector2.down, 0.2f, groundMask);

            //Displays rays
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 0.1f), Vector2.down * 0.2f);
            Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y + 0.1f), Vector2.down * 0.2f);
            Debug.DrawRay(new Vector2(transform.position.x - 0.5f, transform.position.y + 0.1f), Vector2.down * 0.2f);

        int loop = 0;
        foreach (RaycastHit2D hit in groundHit) {
            if (hit.transform != null) {
                return true;
            }
            loop++;
        }
        return false;
    }

    //This method creates and displays Raycasts to detect if there's a wall infornt of the player
    void WallCast() {
        //refresh wall bools
        rightWall = false;
        leftWall = false;


        //Cast towards right
        rightWallHit[1] = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y + 0.5f), Vector2.right, 0.12f, groundMask);
        rightWallHit[2] = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y + 1f), Vector2.right, 0.12f, groundMask);
        rightWallHit[0] = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y), Vector2.right, 0.12f, groundMask);

        //Displays rays
        Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y), Vector2.right * 0.12f);
        Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y + 0.5f), Vector2.right * 0.12f);
        Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y + 1f), Vector2.right * 0.12f);

        foreach (RaycastHit2D hit in rightWallHit) {
            if (hit.transform != null) {
                rightWall = true;
            }

        }


        //Cast towards left
        leftWallHit[0] = Physics2D.Raycast(new Vector2(transform.position.x - 0.4f, transform.position.y), Vector2.left, 0.12f, groundMask);
        leftWallHit[1] = Physics2D.Raycast(new Vector2(transform.position.x - 0.4f, transform.position.y + 0.5f), Vector2.left, 0.12f, groundMask);
        leftWallHit[2] = Physics2D.Raycast(new Vector2(transform.position.x - 0.4f, transform.position.y + 1f), Vector2.left, 0.12f, groundMask);

        //Displays rays
        Debug.DrawRay(new Vector2(transform.position.x - 0.4f, transform.position.y), Vector2.left * 0.12f);
        Debug.DrawRay(new Vector2(transform.position.x - 0.4f, transform.position.y + 0.5f), Vector2.left * 0.12f);
        Debug.DrawRay(new Vector2(transform.position.x - 0.4f, transform.position.y + 1f), Vector2.left * 0.12f);

        foreach (RaycastHit2D hit in leftWallHit) {
            if (hit.transform != null) {
                //TEST: see if array defualts as NULL before hitting object
                leftWall = true;
            }

        }

    }
}
    