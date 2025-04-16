using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneChanger32 : MonoBehaviour
{
    public Image fadeImage; // Image noire pour l'effet de fondu
    public float fadeDuration = 2f; // Dur�e du fondu

    void Start()
    {
        // D�marre avec un fondu d'ouverture
        StartCoroutine(FadeIn());
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
}
