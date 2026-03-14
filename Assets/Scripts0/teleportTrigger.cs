using UnityEngine;

public class teleportTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject destination;

    private TeleportDialog teleportDialog; // Odwołanie do skryptu dialogowego

    private void Awake()
    {
        teleportDialog = GetComponent<TeleportDialog>();
        if (teleportDialog == null)
        {
            teleportDialog = GetComponentInChildren<TeleportDialog>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            if (teleportDialog != null)
            {
                teleportDialog.ShowDialog();
            }
            else
            {
                Debug.LogWarning("TeleportDialog component not found on teleport trigger object.");
            }

            if (destination != null)
            {
                // Teleport the player root transform (safe if the player has a parent structure)
                Transform root = collision.transform.root;
                root.position = destination.transform.position;
            }
            else
            {
                Debug.LogWarning("Destination not assigned in teleportTrigger.");
            }
        }
    }
}
