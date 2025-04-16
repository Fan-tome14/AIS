using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EquiperCasqueVR3 : MonoBehaviour
{
    public Transform pointAttach; // Tête du joueur
    public Transform socleCasque; // Socle où replacer le casque
    public AudioSource sonCasqueEquipe; // Son lorsqu'on met le casque
    public RedButton2 redButton; // Référence au script RedButton
    public AudioSource VoixTrigger;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public bool estEquipe = false;

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        //setGrabbable(false);  // Désactiver le grab interactable au départ

        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(EquiperCasqueSurTete);
        }
        else
        {
            Debug.LogError("⚠️ XRGrabInteractable manquant sur le casque !");
        }
    }

    private void EquiperCasqueSurTete(SelectExitEventArgs args)
    {
        if (!estEquipe)
        {
            Debug.Log("🎧 Casque équipé !");
            transform.SetParent(pointAttach);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            estEquipe = true;
            grabInteractable.enabled = false;
            if (sonCasqueEquipe != null)
            {
                sonCasqueEquipe.Play();
            }
        }
    }

    public void RepositionnerCasque()
    {
        Debug.Log("🔄 Tentative de repositionnement du casque...");

        if (estEquipe)
        {
            Debug.Log("📌 Casque repositionné sur le socle !");
            estEquipe = false;
            transform.SetParent(null);
            transform.position = socleCasque.position;
            transform.rotation = socleCasque.rotation;
            grabInteractable.enabled = true;  // Réactive le grab interactable
            Debug.Log("🔄 Le casque a été reposé !");
        }
        else
        {
            Debug.Log("⚠️ Le casque n'était pas équipé, repositionnement inutile.");
        }
    }

    public void RepositionnerCasqueError()
    {
        transform.SetParent(null);
        transform.position = socleCasque.position;
        transform.rotation = socleCasque.rotation;
    }
}
