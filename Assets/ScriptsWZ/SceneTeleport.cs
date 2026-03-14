using UnityEngine;
using System.Collections;

public class TeleportInside : MonoBehaviour
{
    public Transform celTeleportu;
    public CanvasGroup fadeGroup; 
    public float czasFade = 0.5f;

    private bool isTeleporting = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTeleporting)
        {
            StartCoroutine(DoTeleport(other.transform));
        }
    }

    IEnumerator DoTeleport(Transform player)
    {
        isTeleporting = true;

       
        float timer = 0;
        while (timer < czasFade)
        {
            timer += Time.deltaTime;
            if (fadeGroup != null) fadeGroup.alpha = timer / czasFade;
            yield return null;
        }

       
        player.position = celTeleportu.position;

        
        yield return new WaitForSeconds(0.5f);

       
        timer = 0;
        while (timer < czasFade)
        {
            timer += Time.deltaTime;
            if (fadeGroup != null) fadeGroup.alpha = 1 - (timer / czasFade);
            yield return null;
        }

        isTeleporting = false;
    }
}