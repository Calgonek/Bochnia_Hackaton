using UnityEngine;
using System.Collections;

public class TeleportInside : MonoBehaviour
{
    public Transform celTeleportu; // Przeci¹gnij tutaj obiekt docelowy
    public CanvasGroup fadeGroup;  // Przeci¹gnij tutaj czarny ekran
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

        // 1. Œciemnianie
        float timer = 0;
        while (timer < czasFade)
        {
            timer += Time.deltaTime;
            if (fadeGroup != null) fadeGroup.alpha = timer / czasFade;
            yield return null;
        }

        // 2. Teleportacja
        player.position = celTeleportu.position;

        // 3. Krótka pauza na czarnym ekranie
        yield return new WaitForSeconds(0.5f);

        // 4. Rozjaœnianie
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