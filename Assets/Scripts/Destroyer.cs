using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bg") || collision.gameObject.CompareTag("pipes"))
        {
            Destroy(collision.gameObject);
        }

        //if (collision.gameObject.tag == "Destroyer")
        //{
        //    Destroy(collision.gameObject);
        //}
    }
}
