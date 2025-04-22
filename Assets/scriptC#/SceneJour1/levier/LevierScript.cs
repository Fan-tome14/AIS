using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class LevierScript : MonoBehaviour
{
    public AudioSource soundbutton;
    public GameObject targetObject; // Le GameObject que vous voulez déplacer (votre vaisseau)
    public float moveSpeed = 3f;    // Vitesse de déplacement
    public AfficheMission AfficheMission; // Référence au script RedButton
    public AudioSource VoixTrigger;
    public CheckMissions scriptCheckMissions; // Référence au script CheckMissions

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isMoving = false;  // Détermine si le vaisseau doit bouger ou non
    public bool estActiver { get { return isMoving; } private set { isMoving = value; } }

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
            grabInteractable.hoverEntered.AddListener(OnHoverEntered);
        }
        else
        {
            Debug.LogError("⚠️ XRGrabInteractable manquant sur le levier !");
        }
    }

    private void Update()
    {
        
        // Si le vaisseau doit bouger, on le déplace
        if (isMoving)
        {
            targetObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if(AfficheMission != null && !AfficheMission.isPressed)
        {
            VoixTrigger.Play();
            return;
        }
        Debug.Log("🟢 Levier Saisi, le vaisseau démarre...");

        // 🔊 Lancer le son si la source audio est définie
        if (soundbutton != null)
        {
            soundbutton.Play();
            
        }
        else
        {
            Debug.LogWarning("🔇 Aucun soundbutton assigné !");
        }
        transform.localRotation *= Quaternion.Euler(-40, 0, 0);

        // Commencer à déplacer le vaisseau
        isMoving = true;
        Debug.Log("etat du vaisseau : " + estActiver);
        scriptCheckMissions.ValiderMissions(); 

    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("🟡 Hover sur le levier !");
    }
}