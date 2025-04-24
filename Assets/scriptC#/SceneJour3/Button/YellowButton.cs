using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class YellowButton : MonoBehaviour
{
    public Transform porte; // Glisse la porte ici depuis l'inspecteur
    public EquiperCasqueVR scriptCasqueVR; // Référence au script EquiperCasqueVR
    public AudioSource VoixTrigger; // Son de la porte


    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    
    private Vector3 positionCible = new Vector3(0f, 1.729f, -1.442f);
    private Quaternion rotationCible = Quaternion.Euler(-50f, 0f, 0f);

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (scriptCasqueVR != null && !scriptCasqueVR.estEquipe)
        {
            VoixTrigger.Play();
            return;
        }
        if (porte != null)
        {
            Debug.Log("Grab détecté ! Démarrage de l'ouverture animée...");
            StartCoroutine(TransitionPorte());
        }
    }

    private IEnumerator TransitionPorte()
    {
        Vector3 startPosition = porte.localPosition;
        Quaternion startRotation = porte.localRotation;

        float duration = 3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            porte.localPosition = Vector3.Lerp(startPosition, positionCible, t);
            porte.localRotation = Quaternion.Lerp(startRotation, rotationCible, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Assure qu'on termine exactement à la position/rotation cible
        porte.localPosition = positionCible;
        porte.localRotation = rotationCible;
    }
}
