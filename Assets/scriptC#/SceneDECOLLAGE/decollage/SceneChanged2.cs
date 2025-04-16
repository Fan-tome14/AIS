using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanged3 : MonoBehaviour
{
    public Image fadeImage; // Image noire pour l'effet de fondu
    public float fadeDuration = 2f; // Dur�e du fondu
    public float delayBeforeFadeOut = 15f; // Temps avant le d�but du fondu

    void Start()
    {
        // D�marre avec un fondu d'ouverture
        StartCoroutine(FadeIn());

        // Lance le fondu de sortie apr�s 15 secondes
        Invoke("StartFadeOut", delayBeforeFadeOut);
    }

    IEnumerator FadeIn()
    {
        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    void StartFadeOut()
    {
        StartCoroutine(FadeOutAndChangeScene());
    }

    IEnumerator FadeOutAndChangeScene()
    {
        float alpha = 0f;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Change de sc�ne apr�s le fondu
        SceneManager.LoadScene("jour1");
    }
}
