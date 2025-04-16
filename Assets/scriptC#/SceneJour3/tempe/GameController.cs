using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public ThermometerController[] thermometers;
    public AudioClip successClip; // Son à jouer quand total == 21
    private AudioSource audioSource;

    private bool hasPlayedSound = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Tous les fonds commencent rouges
        foreach (var thermo in thermometers)
        {
            if (thermo.backgroundImage != null)
            {
                thermo.backgroundImage.color = Color.red;
            }
        }

        UpdateTotalTemp(); // Mise à jour initiale
    }

    public void UpdateTotalTemp()
    {
        int total = 0;

        foreach (var thermo in thermometers)
        {
            total += thermo.currentTemp;
        }

        Debug.Log("🌡️ Température totale : " + total);

        Color targetColor = (total == 21) ? Color.green : Color.red;

        // Met à jour chaque fond d’image
        foreach (var thermo in thermometers)
        {
            if (thermo.backgroundImage != null)
            {
                thermo.backgroundImage.color = targetColor;
            }
        }

        // Jouer le son si la température est 21 et qu'on ne l’a pas déjà joué
        if (total == 21 && !hasPlayedSound)
        {
            if (audioSource != null && successClip != null)
            {
                audioSource.PlayOneShot(successClip);
                hasPlayedSound = true;
            }
        }
        else if (total != 21)
        {
            hasPlayedSound = false;
        }
    }
}
