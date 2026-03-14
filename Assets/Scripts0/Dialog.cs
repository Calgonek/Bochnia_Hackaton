using UnityEngine;
using TMPro; // Wymagane dla TextMeshPro w Unity 6+
using System.Collections;

public class TeleportDialog : MonoBehaviour
{
    [Header("Ustawienia UI")]
    [Tooltip("Obiekt Canvas lub Panel, który ma się pojawić.")]
    [SerializeField] private GameObject dialogCanvas;
    
    [Tooltip("Komponent tekstowy, w którym wyświetli się wiadomość.")]
    [SerializeField] private TextMeshProUGUI dialogText;

    [Header("Ustawienia Dialogu")]
    [TextArea(3, 5)]
    [Tooltip("Tekst przemyśleń bohatera.")]
    [SerializeField] private string thoughtText = "Hmm ciekawe jak wyglądam w lustrze...";
    
    [Tooltip("Czas w sekundach, po którym tekst zniknie (wpisz 0, aby nie znikał).")]
    [SerializeField] private float displayDuration = 4f;



    private void Start()
    {
        // Upewniamy się, że na start Canvas z tekstem jest wyłączony
        if (dialogCanvas != null)
        {
            dialogCanvas.SetActive(false);
        }
    }

    public void ShowDialog()
    {
        if (dialogCanvas != null && dialogText != null)
        {
            dialogText.text = thoughtText;
            dialogCanvas.SetActive(true);

            // Jeśli czas jest większy od 0, uruchamiamy odliczanie do wyłączenia
            if (displayDuration > 0)
            {
                StartCoroutine(HideDialogAfterTime());
            }
        }
        else
        {
            Debug.LogWarning("Brakuje przypisań w skrypcie TeleportDialog!");
        }
    }

    private IEnumerator HideDialogAfterTime()
    {
        yield return new WaitForSeconds(displayDuration);
        
        if (dialogCanvas != null)
        {
            dialogCanvas.SetActive(false);
        }
    }
}