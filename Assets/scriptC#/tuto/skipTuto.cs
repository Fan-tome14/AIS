using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class skipTuto : MonoBehaviour
{
    public Animator porte;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Vector3 initialPosition; // Position initiale du bouton
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        initialPosition = transform.localPosition;
        if (grabInteractable != null)
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {

        // Animation d'appui visuel du bouton (modification de la position)
        StartCoroutine(AnimateButtonPress());
        porte.Play("Open"); // Déclenche l'animation d'ouverture de la porte
    }

    private IEnumerator AnimateButtonPress()
    {
        Vector3 targetPosition = initialPosition + new Vector3(0, -0.05f, 0); // Déplacement du bouton sur l'axe Y pour l'enfoncement
        float timeToPress = 0.2f; // Durée de l'appui (en secondes)
        float elapsedTime = 0f;

        // Assurez-vous que le bouton reste visible
        gameObject.SetActive(true);

        // Animation pour simuler l'enfoncement du bouton (modification de la position)
        while (elapsedTime < timeToPress)
        {
            transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / timeToPress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // S'assurer que le bouton arrive à la position cible
        transform.localPosition = targetPosition;

        yield return new WaitForSeconds(0.2f); // Temps de l'appui avant de revenir à la position initiale

        // Retour à la position initiale
        elapsedTime = 0f;
        while (elapsedTime < timeToPress)
        {
            transform.localPosition = Vector3.Lerp(targetPosition, initialPosition, elapsedTime / timeToPress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Position finale
        transform.localPosition = initialPosition;
    }
}
