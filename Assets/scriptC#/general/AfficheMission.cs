using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class AfficheMission : MonoBehaviour
{
    public GameObject canvas;
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
        }
        if (canvas != null)canvas.SetActive(false); // on force le canvas à être désactivé au début
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (isPressed) return; // Si le bouton est déjà pressé, on ne fait rien
        
        isPressed = true; // Sinon marque le bouton comme pressé
        if (canvas != null) canvas.SetActive(true); // Et affiche le canvas des missions
    }
}
