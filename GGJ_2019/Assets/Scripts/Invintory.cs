using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class Invintory : MonoBehaviour
{
   
    public int number_of_things = 1;

    public bool[] things;
    public GameObject[] UI_itemshow;
    public AudioSource asorse;
    public AudioSource asorse2;
    public AudioClip door;
    // Start is called before the first frame update
    void Start()
    {
        //asorse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void getItem(int invintoryItemID)
    {
       
       // number_of_things = number_of_things + 1;
        
        
            things[invintoryItemID] = true;

        UI_itemshow[invintoryItemID].SetActive(true);
        
    }

    public void GameEnd()
    {
        SceneManager.LoadScene("GameOver");
    }
}
