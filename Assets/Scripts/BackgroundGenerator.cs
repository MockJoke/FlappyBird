using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject BgPrefab;
    [SerializeField] private GameObject GeneratedBgContainer;
    [SerializeField] private Transform RefPoint; 
    
    void Update()
    {
        //Generate a bg when the ref point on camera goes ahead of the current bg so that at a point of time the current screen is never empty
        if(transform.position.x < RefPoint.position.x)
        {
             GenerateBg();
        }
    }
    
    //Generates Bg at an approx distance of bg size in x
    private void GenerateBg()
    {
        //Move ahead the 
        transform.position = new Vector2(transform.position.x + 20f, transform.position.y);
        GameObject bg = Instantiate(BgPrefab, transform.position, Quaternion.identity);
        bg.transform.SetParent(GeneratedBgContainer.transform);
    }
}
