using UnityEngine;

public class teleportTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            
            collision.gameObject.transform.parent.position = destination.transform.position;
        }
    }
}
