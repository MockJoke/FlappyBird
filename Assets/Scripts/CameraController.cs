using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform TargetBird;
    private Vector3 offset;     //To keep distance bw bird & camera because our focus object - bird isn't in the center of the screen 
    
    void Start()
    {
        //Calculated distance offset between camera & bird pos
        offset = transform.position - TargetBird.position;
    }
    
    void Update()
    {
        //Constantly updated the camera pos based on the bird pos in x direction
        Vector3 CameraPos = new Vector3(TargetBird.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = CameraPos; 
    }
}
