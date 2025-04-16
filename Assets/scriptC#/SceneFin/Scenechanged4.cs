using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SceneChanged4 : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 2f;
    public float blinkSpeed = 0.2f;
    public float minAlphaAfterFade = 0.2f;
    public float waitBeforeBlackout = 5f;

    public TextMeshProUGUI messageText;
    public string message = "THE END";
    public float textFadeInDuration = 2f;

    void Start()
    {
        StartCoroutine(PlayIntroEffect());
    }

    IEnumerator PlayIntroEffect()
    {
        yield return StartCoroutine(FadeIn());

        yield return new WaitForSeconds(0.02f);
        yield return StartCoroutine(BlinkOnce());

        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(BlinkOnce());

        // 🕒 Attendre  5secondes avec voile
        yield return new WaitForSeconds(waitBeforeBlackout);

        // 🔁 Repasser en noir complet
        yield return StartCoroutine(FadeToBlack());

        // 📝 Afficher texte TextMeshPro
        yield return StartCoroutine(FadeInText());

        // 🚪 Quitter le jeu après l'animation
        Quit();
    }

    IEnumerator FadeIn()
    {
        float alpha = 1f;
        fadeImage.color = new Color(0, 0, 0, alpha);

        while (alpha > minAlphaAfterFade)
        {
            alpha -= Time.deltaTime / fadeDuration;
            alpha = Mathf.Max(alpha, minAlphaAfterFade);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator BlinkOnce()
    {
        float alpha = minAlphaAfterFade;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime / blinkSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(0.05f);

        while (alpha > minAlphaAfterFade)
        {
            alpha -= Time.deltaTime / blinkSpeed;
            alpha = Mathf.Max(alpha, minAlphaAfterFade);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeToBlack()
    {
        float alpha = minAlphaAfterFade;

        while (alpha < 1f)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeInText()
    {
        messageText.text = message;
        messageText.alpha = 0f;

        float t = 0f;
        while (t < textFadeInDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / textFadeInDuration);
            messageText.alpha = alpha;
            yield return null;
        }

        messageText.alpha = 1f;
    }

    // Fonction pour quitter le jeu
    public void Quit()
    {
        // Arrête le jeu (ne fonctionne pas en mode éditeur Unity)
        Application.Quit();

        // Logique de fermeture si tu es en mode éditeur
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
