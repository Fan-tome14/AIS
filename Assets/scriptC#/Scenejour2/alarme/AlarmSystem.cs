using UnityEngine;
using System.Collections;

public class AlarmSystem : MonoBehaviour
{
    public Light[] lights; // Tableau des lumières à manipuler
    public AudioSource alarmSound; // Source du son de l'alarme
    public Color alarmColor = Color.red; // Couleur des lumières lorsque l'alarme se déclenche
    public Color normalColor = Color.white; // Couleur des lumières au normal
    public float blinkSpeed = 0.5f; // Vitesse du clignotement des lumières
    private bool isAlarmActive = false;

    public GreenButton2 buttonScript; // Référence au script du bouton
    private Coroutine blinkCoroutine;

    private void Start()
    {
        // Initialisation de l'état des lumières
        SetLightsColor(normalColor);

        // Démarrer le clignotement des lumières et le son d'alarme au début
        TriggerAlarm();
    }

    private void TriggerAlarm()
    {
        if (!isAlarmActive)
        {
            isAlarmActive = true;
            // Changer la couleur des lumières et démarrer le clignotement
            blinkCoroutine = StartCoroutine(BlinkLights());
            // Démarrer l'alarme
            if (alarmSound != null)
            {
                alarmSound.Play();
            }
        }
    }

    private IEnumerator BlinkLights()
    {
        while (isAlarmActive)
        {
            SetLightsColor(alarmColor); // Lumières rouges
            yield return new WaitForSeconds(blinkSpeed);
            SetLightsColor(normalColor); // Lumières blanches
            yield return new WaitForSeconds(blinkSpeed);
        }
    }

    private void SetLightsColor(Color color)
    {
        foreach (Light light in lights)
        {
            light.color = color;
        }
    }

    public void StopAlarm()
    {
        // Arrêter le clignotement des lumières et le son de l'alarme
        isAlarmActive = false;
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }
        SetLightsColor(normalColor); // Remettre les lumières en blanc

        // Arrêter le son si nécessaire
        if (alarmSound != null)
        {
            alarmSound.Stop();
        }
    }
}
