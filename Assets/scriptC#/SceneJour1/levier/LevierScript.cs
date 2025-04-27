using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LevierScript : MonoBehaviour
{
    public AudioSource soundbutton;
    public GameObject targetObject;
    public float moveSpeed = 3f;
    public AfficheMission AfficheMission;
    public AudioSource VoixTrigger;
    public CheckMissionsGlobal CheckMissionsGlobal;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isMoving = false;
    public bool estActiver { get { return isMoving; } private set { isMoving = value; } }

    private bool isTilted = false; // Nouveau : état bascule (+40 ou -40)

    private const float tiltAmount = 40f; // Rotation en degrés

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (grabInteractable != null)
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
        else
            Debug.LogError("⚠️ XRGrabInteractable manquant sur le levier !");
    }

    private void Update()
    {
        if (isMoving)
        {
            targetObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (AfficheMission != null && !AfficheMission.isPressed)
        {
            VoixTrigger.Play();
            return;
        }

        if (soundbutton != null) soundbutton.Play();
        else Debug.LogWarning("🔇 Aucun soundbutton assigné !");

        float direction = isTilted ? -tiltAmount : tiltAmount; // Si incliné ➔ -40 sinon +40

        transform.Rotate(direction, 0f, 0f, Space.Self); // ➡️ Rotation RELATIVE sur X

        isTilted = !isTilted; // On inverse l'état (bascule)

        isMoving = true;
        CheckMissionsGlobal.ValiderMissions();
    }
}
