using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class VRCanvasController : MonoBehaviour
{
    public static int numjours = 1;
    public Image fadeImage;
    public TextMeshProUGUI messageText;
    public float fadeDuration = 2f;
    public float darkDuration = 3f;
    public AudioSource pasPret;
    public AudioSource audioSource;
    public List<Light> alarmLights; // 💡 Lumières rouges d'alarme
    public CheckMissionsGlobal checkMissions;

    private Coroutine alarmCoroutine;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable interactable;

    void Start()
    {
        messageText.gameObject.SetActive(false);

        // Assurez-vous que les lumières d'alarme sont éteintes au début
        foreach (Light light in alarmLights)
        {
            light.enabled = false;
        }
    }

    public void finishDay(){
        if (!CheckMissionsGlobal.finishedday)
        {
            Debug.Log("🚫 La journée n'est pas encore terminée !");
            pasPret.Play();
            return;
        }

        Debug.Log("✅ La journée est terminée, on peut aller se coucher !");
        audioSource.Play();
        StartCoroutine(FadeToDark());
        Debug.Log("Nombre de jours : " + numjours);
    }

    IEnumerator FadeToDark()
    {
        float elapsedTime = 0f;
        while (elapsedTime < darkDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / darkDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        numjours++;
        messageText.text = "Jour " + numjours;
        messageText.gameObject.SetActive(true);
        SceneManager.LoadScene("jour" + numjours);
    }
}