using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public ThermometerController[] thermometers;

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

        Color targetColor = (total == 21) ? Color.green : Color.red;

        // Met à jour chaque fond d’image
        foreach (var thermo in thermometers)
        {
            if (thermo.backgroundImage != null)
            {
                thermo.backgroundImage.color = targetColor;
            }
        }
    }
}
