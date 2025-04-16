using System.Collections;
using UnityEngine;
using TMPro;

public class HideTitle : MonoBehaviour
{
    public TextMeshPro titleText; // Référence au texte 3D

    void Start()
    {
        if (titleText != null)
        {
            StartCoroutine(HideAfterSeconds(5f)); // Lance la coroutine
        }
        else
        {
            Debug.LogError("⚠ Aucun TextMeshPro assigné !");
        }
    }

    IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        titleText.gameObject.SetActive(false); // Cache le texte après X secondes
    }
}
