using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class stars : MonoBehaviour
{

    public GameObject otherstars;
    public GameObject player;
    public Vector2 otherstarslocation;
    public bool isusingstars;
    public AudioClip walkStars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().use == true && isusingstars)
        {
            player.GetComponent<PlayerController>().use = false;
            StartCoroutine(WaitForreset());
            player.transform.position = otherstarslocation;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isusingstars = true;
            player = other.gameObject;
            otherstarslocation = otherstars.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isusingstars = true;
            player = null;
            otherstarslocation = gameObject.transform.position;
        }
    }

    IEnumerator WaitForreset()
    {
        
        yield return new WaitForSeconds(1);
        
    }
}
