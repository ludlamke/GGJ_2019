using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invintory : MonoBehaviour
{
    public GameObject[] things;
    public int number_of_things = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void getItem(GameObject invintoryItem)
    {
        
        number_of_things = number_of_things + 1;
        things = new GameObject[number_of_things];
        
            things[number_of_things - 1] = invintoryItem;
        
        
    }
}
