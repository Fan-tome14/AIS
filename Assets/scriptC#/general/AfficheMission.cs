using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using UnityEngine.Video;


public class AfficheMission : MonoBehaviour
{
    public GameObject canvas;
    public bool isPressed = false;
    public CheckMissionsGlobal checkMissionsGlobal; // Référence au script CheckMissionsGlobal
    public GameObject ecran2;

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
        if (isPressed&&!CheckMissionsGlobal.finishedday) return; // Si le bouton est déjà pressé, on ne fait rien
        else if (isPressed && CheckMissionsGlobal.finishedday) // Si le bouton est pressé et que la journée est finie, on le remet à sa position initiale
        {
            ecran2.SetActive(true); // Affiche l'écran 2
            var screen = ecran2.GetComponent<VideoPlayer>();
            if (screen != null) screen.Play(); // Joue la vidéo sur l'écran 2
            if (canvas != null) canvas.SetActive(false); // Et cache le canvas des missions
            return;
        }
        
        isPressed = true; // Sinon marque le bouton comme pressé
        if (canvas != null) canvas.SetActive(true); // Et affiche le canvas des missions
    }
}
