using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //input vars
    [HideInInspector]public bool left;
    [HideInInspector]public bool right;
    [HideInInspector]public bool up;
    [HideInInspector]public bool down;
    [HideInInspector]public bool jump;
    [HideInInspector]public bool use;

    public bool end_game;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;


    Vector2 moveVector;
    Rigidbody2D rgb2d;
    RayCastDetector groundDetect;

    public GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("Game_maniger");
        groundDetect = GetComponent<RayCastDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        //refresh one shot inputs
        jump = false;
        use = false;

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

        //Move
        transform.Translate(moveVector * speed);

        //Jump
        if (jump && groundDetect.isGrounded) { rgb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); };
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject newItem = null;
        int itemid;

        
        if (other.tag == "Invintory_Item")
        {
            newItem = other.gameObject;
            itemid = newItem.GetComponent<Item>().id;
            GM.GetComponent<Invintory>().getItem(itemid);
            Destroy(other.gameObject);
            //other.transform.position = new Vector2(0, 5000);
        }

        if(other.tag == "bed" && end_game)
        {
            GM.GetComponent<Invintory>().GameEnd();
        }
    }

    
}
