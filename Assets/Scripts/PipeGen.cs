using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGen : MonoBehaviour
{
    public GameObject GenPipe, Obstacles, GeneratedPipes;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GeneratePipe", 0f, 2f);
       
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void GeneratePipe()
    {
        float RandX = Random.Range(13f,17f);
        float RandY = Random.Range(-4.45f, 4.45f); 
        Vector2 pos = new Vector2(transform.position.x+ RandX, RandY);
        transform.position = pos;
        GameObject pipe = Instantiate(GenPipe, transform.position, Quaternion.identity);
        pipe.transform.SetParent(GeneratedPipes.transform);    
    }

}
