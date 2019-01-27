using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    float originY;

    //Thank you  fafase on Unity Answers for the Sine animations
        float amplitudeY = 0.06f;
        float omegaY = 1.0f;
        float index;

    void Start() {
        originY = transform.position.y;
    }

    // Update is called once per frame
    void Update() {


        //Animate item to make it stand out
        //Again, thanks, fafase
            index += Time.deltaTime;
            float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
            transform.localPosition = new Vector2(transform.position.x, originY + y);
    }
}
