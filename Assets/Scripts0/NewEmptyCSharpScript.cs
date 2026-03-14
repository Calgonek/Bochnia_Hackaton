using UnityEngine;
using UnityEngine.UI; // Wymagane dla komponentu UI Image

public class ImageSequenceTrigger : MonoBehaviour
{
    [Header("Ustawienia UI")]
    [Tooltip("Obiekt Canvas lub Panel, na którym znajduje się obrazek.")]
    [SerializeField] private GameObject imageCanvas;
    
    [Tooltip("Komponent Image, w którym będzie podmieniane zdjęcie.")]
    [SerializeField] private Image displayImage;

    [Header("Baza Zdjęć")]
    [Tooltip("Przeciągnij tutaj swoje zdjęcia (typu Sprite).")]
    [SerializeField] private Sprite[] imagesSequence;

    [Header("Ustawienia Gracza")]
    [Tooltip("Tag obiektu gracza.")]
    [SerializeField] private string playerTag = "Player";

    // Zmienna zapamiętująca, przy którym zdjęciu jesteśmy
    private int currentIndex = 0; 

    private void Start()
    {
        // Na starcie wyłączamy Canvas, żeby zdjęcie nie było widoczne
        if (imageCanvas != null)
        {
            imageCanvas.SetActive(false);
        }
    }

    // Ważne: w 2D używamy OnTriggerEnter2D i Collider2D!
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzamy, czy wszedł gracz ORAZ czy dodaliśmy jakieś zdjęcia do tablicy
        if (other.CompareTag(playerTag) && imagesSequence.Length > 0)
        {
            // 1. Podmieniamy grafikę w komponencie Image na tę z obecnego indeksu
            displayImage.sprite = imagesSequence[currentIndex];
            
            // 2. Włączamy Canvas, żeby gracz zobaczył zdjęcie
            imageCanvas.SetActive(true);

            // 3. Zwiększamy licznik o 1, aby przygotować następne zdjęcie na kolejny raz
            currentIndex++;

            // 4. (Opcjonalnie) Jeśli pokazaliśmy już wszystkie zdjęcia, zapętlamy od nowa (wracamy do 0)
            if (currentIndex >= imagesSequence.Length)
            {
                currentIndex = 0; 
                // Jeśli wolisz, żeby po ostatnim zdjęciu nic się już nie działo, 
                // zamiast 'currentIndex = 0' możesz użyć np. zniszczenia obiektu: Destroy(gameObject);
            }
        }
    }

    // Dodatek: gdy gracz odejdzie z triggera, ukrywamy zdjęcie
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag) && imageCanvas != null)
        {
            imageCanvas.SetActive(false);
        }
    }
}