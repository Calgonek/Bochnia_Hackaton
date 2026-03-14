using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;

public class MirrorInteract : MonoBehaviour
{
    [Header("Obrazy na kolejne dni")]
    public Sprite[] dailyImages; 
    public Image revealImageComponent; 

    [Header("Reszta ustawieñ")]
    public float zasiegInterakcji = 2f;
    public GameObject napisE;
    public Transform punktPowrotu;
    public Transform player;
    public CanvasGroup fadeGroup;
    public CanvasGroup revealGroup;
    public float fadeDuration = 0.5f;

    private bool isPlayerNear = false;
    private bool isInteracting = false;

    void Update()
    {
        if (isInteracting || player == null) return;

        float dystans = Vector2.Distance(transform.position, player.position);

        if (dystans <= zasiegInterakcji)
        {
            if (!isPlayerNear) { isPlayerNear = true; napisE.SetActive(true); }
            if (Input.GetKeyDown(KeyCode.E)) StartCoroutine(MirrorRoutine());
        }
        else
        {
            if (isPlayerNear) { isPlayerNear = false; napisE.SetActive(false); }
        }
    }

    IEnumerator MirrorRoutine()
    {
        isInteracting = true;
        napisE.SetActive(false);

       
        int dayIndex = DayManager.Instance.currentDay - 1; 

        if (dayIndex >= 0 && dayIndex < dailyImages.Length)
        {
            revealImageComponent.sprite = dailyImages[dayIndex];
        }

        yield return StartCoroutine(Fade(fadeGroup, 0, 1, fadeDuration));
        yield return new WaitForSeconds(1f);

        fadeGroup.alpha = 0;
        revealGroup.alpha = 1;

        yield return new WaitForSeconds(3f);

        yield return StartCoroutine(Fade(revealGroup, 1, 0, fadeDuration));

        if (punktPowrotu != null) player.position = punktPowrotu.position;

        yield return StartCoroutine(Fade(fadeGroup, 1, 0, fadeDuration));
        isInteracting = false;
    }

    IEnumerator Fade(CanvasGroup group, float start, float end, float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            group.alpha = Mathf.Lerp(start, end, timer / duration);
            yield return null;
        }
        group.alpha = end;
    }
}