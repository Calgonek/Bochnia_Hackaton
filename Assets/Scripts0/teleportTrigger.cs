using UnityEngine;

public class teleportTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject destination;

    private TeleportDialog teleportDialog; // Odwołanie do skryptu dialogowego

    private void Awake()
    {
        teleportDialog = GetComponent<TeleportDialog>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            teleportDialog.ShowDialog();
            collision.gameObject.transform.parent.position = destination.transform.position;
        }
    }
}
