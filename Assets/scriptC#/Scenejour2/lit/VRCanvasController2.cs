using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class VRCanvasController2 : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 2f;
    public float darkDuration = 3f;
    public AudioSource pasPret;
    public AudioSource audioSource;
    public RedButton2 redButton;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable interactable;

    void Start()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrab);
            Debug.Log("Listener ajouté à l'objet interactable.");
        }
        else
        {
            Debug.LogError("L'objet ne possède pas de XRGrabInteractable.");
        }

 
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (!CheckMissions2.finishedday)
        {
            Debug.Log("🚫 La journée n'est pas encore terminée !");
            pasPret.Play();
            return;
        }

        Debug.Log("✅ La journée est terminée, on peut aller se coucher !");
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
      
        SceneManager.LoadScene("jour3");
    }
}
