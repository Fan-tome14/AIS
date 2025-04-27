using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class VRCanvasController : MonoBehaviour
{
    public static int numjours = 3;
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
        // On cache le texte au début
        messageText.gameObject.SetActive(false);
        // On vérifie que chaque light d'alarme est bien désactivée
        foreach (Light light in alarmLights)light.enabled = false;
    }

    public void finishDay(){
        // On vérifie que le joueur a bien terminé toutes les missions avant de passer au jour suivant 
        // Si le joueur n'a pas terminé toutes les missions, on joue un son et on ne fait rien
        if (!CheckMissionsGlobal.finishedday)
        {
            pasPret.Play();
            return;
        }
        audioSource.Play();
        StartCoroutine(FadeToDark());
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
        if (numjours > 3)
        {
            SceneManager.LoadScene("fin");
        }
        // on modifie le texte du message pour indiquer le jour suivant et on l'affiche
        messageText.text = "Jour " + numjours;
        messageText.gameObject.SetActive(true);
        CheckMissionsGlobal.finishedday = false;
        SceneManager.LoadScene("jour" + numjours);
    }
}