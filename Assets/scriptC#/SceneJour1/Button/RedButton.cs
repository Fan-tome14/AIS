using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class RedButton : MonoBehaviour
{
    public AudioSource soundbutton;
    public AudioSource audioSource2;
    public GameObject canvas;
    public EquiperCasqueVR casqueVRSCRIPT;
    public BlackButton blackButton; // Référence au bouton noir
    public bool isPressed = false;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // Changed the type
    private Vector3 initialPosition;

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(); // Corrected this line
        initialPosition = transform.localPosition;

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
            grabInteractable.hoverEntered.AddListener(OnHoverEntered);
        }
        else
        {
            Debug.LogError("⚠️ XRGrabInteractable manquant sur le cube !");
        }

        // Assurez-vous que le canvas est désactivé au départ
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        isPressed = true;        
        if (soundbutton != null)
        {
            soundbutton.Play();
        }
        else
        {
            Debug.LogWarning("🔇 Aucun sondbutton assigné !");
        }

        // 🔊 Lancer le son si la source audio est définie
        if (audioSource2 != null)
        {
            audioSource2.Play();
        }
        else
        {
            Debug.LogWarning("🔇 Aucun audioSource2 assigné !");
        }

        // Afficher le canvas
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
        StartCoroutine(AnimateButtonPress());
    }

    private IEnumerator AnimateButtonPress()
    {
        // Descendre le bouton
        transform.localPosition += new Vector3(0, -0.01f, 0);
        yield return new WaitForSeconds(0.2f); // Durée de l'appui
        // Revenir à la position initiale
        transform.localPosition = initialPosition;
    }
    public void setGrabbable(bool grabbable)
    {
        if (grabInteractable != null)
        {
            grabInteractable.enabled = grabbable;  // Assurez-vous que grabbable est un booléen
            Debug.Log(grabbable ? "🔵 est maintenant attrapable." : "🔴 Le casque n'est plus attrapable.");
        }
        else
        {
            Debug.LogError("⚠️ XRGrabInteractable manquant sur l'objet !");
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Vous pouvez ajouter des effets de survol ici
        Debug.Log("🟡 Hover sur le bouton !");
    }
}
