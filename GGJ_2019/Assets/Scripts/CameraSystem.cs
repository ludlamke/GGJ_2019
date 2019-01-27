using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public float yOffset;

    public Transform target;
    private Vector3 currentPos;

    private void Update() {
        currentPos = new Vector3(target.position.x, transform.position.y + yOffset, -10);

        transform.position = currentPos;
    }
}