using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThermometerController : MonoBehaviour
{
    public TextMeshProUGUI tempDisplay;
    public Image backgroundImage; // 👉 Image de fond du Canvas
    public int currentTemp = 30;
    public int minTemp = 0;
    public int maxTemp = 30;

    public GameController gameController;

    private void Start()
    {
        UpdateDisplay();
    }

    public void IncreaseTemp()
    {
        if (currentTemp < maxTemp)
        {
            currentTemp++;
            UpdateDisplay();
            gameController.UpdateTotalTemp(); // 👉 On informe le contrôleur principal
        }
    }

    public void DecreaseTemp()
    {
        if (currentTemp > minTemp)
        {
            currentTemp--;
            UpdateDisplay();
            gameController.UpdateTotalTemp(); // 👉 On informe le contrôleur principal
        }
    }

    void UpdateDisplay()
    {
        tempDisplay.text = currentTemp + "°C";
    }
}
