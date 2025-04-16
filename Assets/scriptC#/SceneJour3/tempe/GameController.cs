using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public ThermometerController[] thermometers;
    public AudioSource successSound; // 🔊 Son à jouer quand c’est vert

    private bool hasPlayedSound = false; // Pour ne pas jouer le son plusieurs fois

    private void Start()
    {
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

        bool shouldBeGreen = (total == 21);
        Color targetColor = shouldBeGreen ? Color.green : Color.red;

        foreach (var thermo in thermometers)
        {
            if (thermo.backgroundImage != null)
            {
                thermo.backgroundImage.color = targetColor;
            }
        }

        // 🎵 Joue le son quand ça devient vert
        if (shouldBeGreen && !hasPlayedSound)
        {
            if (successSound != null)
            {
                successSound.Play();
            }
            hasPlayedSound = true;
        }
        else if (!shouldBeGreen)
        {
            hasPlayedSound = false; // Reset pour rejouer plus tard
        }
    }
}
