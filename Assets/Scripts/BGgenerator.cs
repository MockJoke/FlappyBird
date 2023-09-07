using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGgenerator : MonoBehaviour
{
    public GameObject GenBG, GeneratedBG;
    public Transform RefPoint; 

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < RefPoint.position.x)
        {
            transform.position = new Vector2(transform.position.x + 17.9f, transform.position.y);
            GameObject bg = Instantiate(GenBG, transform.position, Quaternion.identity);
            bg.transform.SetParent(GeneratedBG.transform); 
        }
    }
}
