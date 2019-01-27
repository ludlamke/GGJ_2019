using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class stars : MonoBehaviour
{

    public GameObject otherstars;
    public GameObject player;
    public GameObject fade;
    public Vector2 otherstarslocation;
    public bool isusingstars;
    public AudioClip walkStars;
    public AudioSource Asourse;
    private float adiogap;
    // Start is called before the first frame update
    void Start()
    {
        Asourse = GetComponent<AudioSource>();
        adiogap = walkStars.length;
        fade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().use == true && isusingstars)
        {
            player.GetComponent<PlayerController>().use = false;
           
            StartCoroutine(WaitForreset());
            
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
        
        player.SetActive(false);
        Asourse.PlayOneShot(walkStars);
        fade.SetActive(true);
        yield return new WaitForSeconds(adiogap - 3);
        fade.SetActive(false);
        Asourse.Stop();
        player.transform.position = otherstarslocation;
        player.SetActive(true);
    }
}
