using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class stars : MonoBehaviour
{

    public Transform otherStairs;
    public GameObject player;
    public GameObject fade;
   
    public bool readyToUse;
    public AudioClip walkStairs;
    public AudioSource auSource;
    private float audioGap;
    public GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        auSource = GetComponent<AudioSource>();
        audioGap = walkStairs.length;
        fade.SetActive(false);
        GM = GameObject.Find("Game_maniger");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if Player is near door and "uses" teleport
        if (player.GetComponent<PlayerController>().use && readyToUse)
        {
            StartCoroutine(WaitForreset());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            readyToUse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            readyToUse = false;
        }
    }

    IEnumerator WaitForreset()
    {

        //player.SetActive(false);
        auSource.PlayOneShot(walkStairs);
        fade.SetActive(true);
        yield return new WaitForSeconds(audioGap - 3);
        fade.SetActive(false);
        auSource.Stop();
        player.transform.position = otherStairs.position;
        if (GM.GetComponent<Invintory>().asorse.isPlaying)
        {
            GM.GetComponent<Invintory>().asorse.Stop();
            GM.GetComponent<Invintory>().asorse2.Play();
        }
        else if (GM.GetComponent<Invintory>().asorse2.isPlaying)
        {
            GM.GetComponent<Invintory>().asorse2.Stop();
            GM.GetComponent<Invintory>().asorse.Play();
        }
    }
}
