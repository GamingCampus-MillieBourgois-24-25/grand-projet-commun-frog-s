using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WelcomeScreen : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public float fadeDuration = 1.5f; // Durée du fondu en secondes

    private bool isFading = false;

    void Start()
    {
        // Ajoute un CanvasGroup si pas déjà présent
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    void Update()
    {
        if (!isFading && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;

        float elapsed = 0f;
        float startAlpha = canvasGroup.alpha;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsed / fadeDuration);
            yield return null;
        }

        // Fin du fade
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        gameObject.SetActive(false);
    }
}
