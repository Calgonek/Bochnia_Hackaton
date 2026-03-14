using UnityEngine;
using UnityEngine.SceneManagement; 
using System.Collections;
namespace test
{

    public class Teleport : MonoBehaviour
    {
        public string targetSceneName;
        public CanvasGroup fadeGroup;
        public float fadeDuration = 1f;

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Player"))
            {
                StartCoroutine(FadeAndTeleport());
            }
        }

        IEnumerator FadeAndTeleport()
        {
            float timer = 0;


            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                fadeGroup.alpha = timer / fadeDuration;
                yield return null;
            }

            fadeGroup.alpha = 1;


            SceneManager.LoadScene(targetSceneName);
        }
    }
}