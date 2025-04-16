using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class RedButton : MonoBehaviour
{
    public AudioSource soundbutton;
    public AudioSource audioSource2;
    public GameObject canvas;
    public EquiperCasqueVR casqueVRSCRIPT;
    public BlackButton blackButton;
    public bool isPressed = false;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    
    private Vector3 initialPosition;

    private void Awake()
    {
        // Vérifie et ajoute les composants si nécessaires
        if (GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>() == null)
            gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

    }

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        
        initialPosition = transform.localPosition;

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
            grabInteractable.hoverEntered.AddListener(OnHoverEntered);
        }



        if (canvas != null)
            canvas.SetActive(false);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (isPressed) return;

        isPressed = true;

        if (soundbutton != null) soundbutton.Play();
        else Debug.LogWarning("🔇 Aucun soundbutton assigné !");

        if (audioSource2 != null) audioSource2.Play();
        else Debug.LogWarning("🔇 Aucun audioSource2 assigné !");

        if (canvas != null) canvas.SetActive(true);

        StartCoroutine(AnimateButtonPress());
    }

    private IEnumerator AnimateButtonPress()
    {
        transform.localPosition += new Vector3(0, -0.01f, 0);
        yield return new WaitForSeconds(0.2f);
        transform.localPosition = initialPosition;
        
    }

    public void setGrabbable(bool grabbable)
    {
        if (grabInteractable != null)
        {
            grabInteractable.enabled = grabbable;
            Debug.Log(grabbable ? "🔵 est maintenant attrapable." : "🔴 Le bouton n'est plus attrapable.");
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("🟡 Hover sur le bouton !");
    }
}
