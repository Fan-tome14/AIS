using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EquiperCasqueVR : MonoBehaviour
{
    public Transform pointAttach; // Tête du joueur
    public Transform socleCasque; // Socle où replacer le casque
    public AudioSource sonCasqueEquipe; // Son lorsqu'on met le casque
    public AfficheMission AfficheMission; // Référence au script RedButton
    public AudioSource VoixTrigger;
    public CheckMissionsGlobal  scriptCheckMissions; // Référence au script CheckMissions

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public bool estEquipe = false;
    private bool aEquiperLecasque = false;
    private bool aReposer = false;

    public bool AEteEquipe { get { return aEquiperLecasque; } private set { aEquiperLecasque = value; } }
    public bool AEteRepose { get { return aReposer; } private set { aReposer = value; } }

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        transform.SetParent(null); // Le casque n'a plus de parent
        Debug.Log("👋 Casque attrapé, détaché de son parent.");
    }


    public void EquiperManuellement()
    {
        if (AfficheMission != null && !AfficheMission.isPressed)
        {
            VoixTrigger.Play();
            RepositionnerCasqueError();
            Debug.Log("🔊 Voix déclenchée (équiper manuel bloqué) !");
            return;
        }

            Debug.Log("🎧 Casque équipé via Trigger !");
            CancelGrab(); // Annule le grab si le casque est déjà en cours de manipulation
            transform.SetParent(pointAttach);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            estEquipe = true;
            AEteEquipe = true;

            if (sonCasqueEquipe != null)
            {
                sonCasqueEquipe.Play();
            }

            scriptCheckMissions.ValiderMissions();

    }
    private void CancelGrab()
    {
        grabInteractable.enabled = false; // Désactive le grab interactable pour éviter les conflits
        grabInteractable.enabled = true; // Réactive le grab interactable après l'équipement
        Debug.Log("❌ Grab annulé pour éviter les conflits !");
    }



    public void RepositionnerCasque()
    {
        Debug.Log("🔄 Tentative de repositionnement du casque...");

        if (estEquipe)
        {
            CancelGrab(); // Annule le grab si le casque est déjà en cours de manipulation
            Debug.Log("📌 Casque repositionné sur le socle !");
            estEquipe = false;
            aReposer = true;  // Le casque a été reposé
            transform.SetParent(null);
            transform.position = socleCasque.position;
            transform.rotation = socleCasque.rotation;
            grabInteractable.enabled = true;  // Réactive le grab interactable
            Debug.Log("🔄 Le casque a été reposé !");
            scriptCheckMissions.ValiderMissions(); // Appel de la méthode pour valider les missions

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
