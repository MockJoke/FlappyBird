using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform TargetBird;
    Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - TargetBird.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CameraPos = new Vector3(TargetBird.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = CameraPos; 
    }
}
