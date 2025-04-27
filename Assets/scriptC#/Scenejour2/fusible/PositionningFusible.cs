using UnityEngine;

public class PositionningFusible : MonoBehaviour
{
    public Transform positionFinale;
    public AudioSource VoixTrigger;
    public AfficheMission AfficheMission; // Référence au script RedButton
    public MiseEnCommun scriptMiseEnCommun;

    public bool enPosition = false; // Variable pour savoir si le fusible est positionné
    private void OnTriggerEnter(Collider other)
    {
        if (AfficheMission != null && !AfficheMission.isPressed)
        {
            VoixTrigger.Play();
            Debug.Log("🔊 Voix déclenchée !");
            return;
        }
        if (other.CompareTag("fuse"))
        {
            enPosition = true; // Met à jour l'état du fusible
            // Repositionne le fusible
            other.transform.position = positionFinale.position;
            other.transform.rotation = positionFinale.rotation;
            var grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false;
            }
            var rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            scriptMiseEnCommun.CheckFusible();
        }
    }
}
