using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class BlackButton2 : MonoBehaviour
{
    public EquiperCasqueVR2 casque; // Référence au casque
    public AudioSource audioSource; // Référence au son à jouer
    public RedButton2 redButton; // Référence au bouton rouge
    public AudioSource VoixTrigger; // Référence au son de la voix à jouer

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Vector3 initialPosition; // Position de base du bouton

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
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
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        // Vérifier si le casque est déjà équipé avant de procéder
        if (!casque.estEquipe)
        {
            Debug.Log("⚠️ Le casque n'est pas encore équipé !");
            // Optionnellement, jouer un son d'avertissement si défini
            if (audioSource != null)
            {
                audioSource.Play();
            }
            return; // Ne pas continuer si le casque n'est pas équipé
        }

        // 🔊 Lancer le son si la source audio est définie
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("🔇 Aucun AudioSource assigné !");
        }
        

        // ▶️ Animation d'appui physique du bouton
        StartCoroutine(AnimateButtonPress());

        // Repositionner le casque si la référence existe
        if (casque != null)
        {
            casque.RepositionnerCasque();
        }
        else
        {
            Debug.LogError("❌ Aucun casque assigné dans l'inspecteur !");
        }
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("🛑 Le joueur survole le cube.");
    }

    private IEnumerator AnimateButtonPress()
    {
        // Descendre le bouton
        transform.localPosition += new Vector3(0, -0.01f, 0);
        yield return new WaitForSeconds(0.2f); // Durée de l'appui
        // Revenir à la position initiale
        transform.localPosition = initialPosition;
    }
}
