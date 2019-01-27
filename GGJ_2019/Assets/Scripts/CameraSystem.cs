﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public float panSpeed;
    public float yOffset;
    public float xOffset;


    public Transform target;
    private Transform currentTrans;

    public enum TrackModes { XLock, YLock, Pin};
    public TrackModes trackMode;

	// Use this for initialization
	void Start () {
        currentTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        switch (trackMode) {
            case TrackModes.YLock:
                TrackX();
                break;
            case TrackModes.XLock:
                TrackY();
                break;
            case TrackModes.Pin:
                TrackAll();
                break;
        }       
    }

    void TrackX() {
        if(target.position.x > transform.position.x) {
            //transform.position = new Vector3(target.position.x, currentTrans.position.y, currentTrans.position.z);
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
    }

    void TrackY() {
        if (target.position.y > transform.position.y) {
            transform.position = new Vector3(currentTrans.position.x, target.position.y, currentTrans.position.z);
        }
    }

    void TrackAll() {
        transform.position = new Vector3(target.position.x, target.position.y, currentTrans.position.z);
    }
}
