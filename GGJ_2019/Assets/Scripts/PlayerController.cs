using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //input vars
    bool left;
    bool right;
    bool up;
    bool down;
    bool jump;
    bool use;

    public float jumpForce;
    public float speed;

    Vector2 moveVector;
    Rigidbody2D rgb2d;

    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Inputs
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);
        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        jump = Input.GetKeyDown(KeyCode.Space);
        use = Input.GetKeyDown(KeyCode.RightControl);

        //Update move vector
        //Zero
        moveVector = Vector2.zero;

        //Apple Vector from inputs
        if (left) { moveVector += Vector2.left; }
        if (right) { moveVector += Vector2.right; }

        Debug.Log(moveVector);

        //Move
        transform.Translate(moveVector * speed);

        //Jump
        if (jump) { rgb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); Debug.Log("Jumped"); };
    }
}
