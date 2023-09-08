using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform TargetBird;
    private Vector3 offset; 
    
    void Start()
    {
        offset = transform.position - TargetBird.position;
    }
    
    void Update()
    {
        Vector3 CameraPos = new Vector3(TargetBird.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = CameraPos; 
    }
}
