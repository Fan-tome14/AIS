using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class LevierScript : MonoBehaviour
{
    public AudioSource soundbutton;
    public GameObject targetObject; // Le GameObject que on va déplacer
    public float moveSpeed = 3f;    // Vitesse de déplacement
    public AfficheMission AfficheMission; // Référence au script RedButton
    public AudioSource VoixTrigger;
    public CheckMissionsGlobal CheckMissionsGlobal; // Référence au script CheckMissions

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isMoving = false;  // Détermine si le vaisseau doit bouger ou non
    public bool estActiver { get { return isMoving; } private set { isMoving = value; } }
    private Quaternion initialRotation; // Rotation initiale du levier

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    
        if (grabInteractable != null)grabInteractable.selectEntered.AddListener(OnButtonPressed);
        else Debug.LogError("⚠️ XRGrabInteractable manquant sur le levier !");
        
        initialRotation = transform.localRotation; // Enregistre la rotation initiale du levier
    }

    private void Update()
    {
        // Si le vaisseau doit bouger, on le déplace
        if (isMoving) targetObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        // si les missions n'ont été affichées on ne fait rien
        if(AfficheMission != null && !AfficheMission.isPressed)
        {
            VoixTrigger.Play();
            return;
        }
        // 🔊 Lancer le son si la source audio est définie
        if (soundbutton != null)soundbutton.Play(); 
        else Debug.LogWarning("🔇 Aucun soundbutton assigné !");
        
        // déplacer le levier
        if(transform.localRotation != initialRotation)transform.localRotation = initialRotation; // Réinitialiser la rotation du levier
        else  transform.localRotation = Quaternion.Euler(40, 0.018f, 0.002f); // Sinon Déplacer le levier vers le bas
 
        // Commencer à déplacer le vaisseau
        isMoving = true;
        CheckMissionsGlobal.ValiderMissions(); 

    }
}