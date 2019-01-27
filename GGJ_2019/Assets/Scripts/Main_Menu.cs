using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Main_Menu : MonoBehaviour
{
    [SerializeField] private AudioSource ASorce;
    [SerializeField] private AudioClip button_Click;
     private float play_lenth;
    // Start is called before the first frame update
    void Start()
    {
        ASorce = GetComponent<AudioSource>();

        play_lenth = button_Click.length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void New_Game()
    {
        
        // function for game start button
        
        
        

        StartCoroutine(WaitForButtonSound()); 


        
        
        

    }

    IEnumerator WaitForButtonSound()
    {
        ASorce.PlayOneShot(button_Click);
        yield return new WaitForSeconds(play_lenth + (19/20));
        SceneManager.LoadScene("House");
    }
}
