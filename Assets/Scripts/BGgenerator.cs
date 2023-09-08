using UnityEngine;

public class BGgenerator : MonoBehaviour
{
    [SerializeField] private GameObject GenBG;
    [SerializeField] private GameObject GeneratedBG;
    [SerializeField] private Transform RefPoint; 
    
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
