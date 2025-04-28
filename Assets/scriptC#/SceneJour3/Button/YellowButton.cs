using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class YellowButton : MonoBehaviour
{
    public Transform porte; 
    public EquiperCasqueVR scriptCasqueVR; // Référence au script EquiperCasqueVR
    public AudioSource VoixTrigger; 


    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    
    private Quaternion rotationCible = Quaternion.Euler(-50f, 0f, 0f);

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // On vérifie que le joueur a équiper le casque sinon on ne fait rien
        if (scriptCasqueVR != null && !scriptCasqueVR.estEquipe)
        {
            VoixTrigger.Play();
            return;
        }
        if (porte != null) StartCoroutine(TransitionPorte());
    }

    private IEnumerator TransitionPorte()
    {
        Quaternion startRotation = porte.localRotation;

        float duration = 3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            porte.localRotation = Quaternion.Lerp(startRotation, rotationCible, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Assure qu'on termine exactement à la position/rotation cible
        porte.localRotation = rotationCible;
    }
}
