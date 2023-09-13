using UnityEngine;

public class PipeGen : MonoBehaviour
{
    [SerializeField] private GameObject PipePrefab;
    [SerializeField] private GameObject GeneratedPipesContainer;
    
    void Start()
    {
        InvokeRepeating(nameof(GeneratePipe), 0f, 2f);
    }
    
    /// <summary>
    /// Generates pipe on a randomised x, y position within the screen
    /// </summary>
    public void GeneratePipe()
    {
        float RandX = Random.Range(13f, 17f);
        float RandY = Random.Range(-3.15f, 4.45f); 
        Vector2 pos = new Vector2(transform.position.x+ RandX, RandY);
        transform.position = pos;
        GameObject pipe = Instantiate(PipePrefab, transform.position, Quaternion.identity);
        pipe.transform.SetParent(GeneratedPipesContainer.transform);    
    }
}
