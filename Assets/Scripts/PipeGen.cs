using UnityEngine;

public class PipeGen : MonoBehaviour
{
    [SerializeField] private GameObject GenPipe;
    [SerializeField] private GameObject Obstacles;
    [SerializeField] private GameObject GeneratedPipes;
    
    void Start()
    {
        InvokeRepeating(nameof(GeneratePipe), 0f, 2f);
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
