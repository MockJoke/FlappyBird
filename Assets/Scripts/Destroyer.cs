using UnityEngine;

/// <summary>
/// Destroys the generated bg & pipes which are in behind out of the screen
/// </summary>
public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bg") || collision.gameObject.CompareTag("pipes"))
        {
            Destroy(collision.gameObject);
        }
    }
}
