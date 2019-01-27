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
    Scene currentSean;
    string sceneName;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        ASorce = GetComponent<AudioSource>();

        play_lenth = button_Click.length;

        currentSean = SceneManager.GetActiveScene();

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = currentSean.name;

        if (sceneName == "GameOver")
        {

            timer += Time.deltaTime;
            if(timer >= 10 && Input.anyKey)
            {
               SceneManager.LoadScene("Main_Menu");
            }
            
        }
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
