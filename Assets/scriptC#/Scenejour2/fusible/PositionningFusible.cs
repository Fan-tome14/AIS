using UnityEngine;

public class PositionningFusible : MonoBehaviour
{
    public Transform positionFinale;
    public AudioSource VoixTrigger;
    public RedButton2 redButton; // Référence au script RedButton

    public bool enPosition = false; // Variable pour savoir si le fusible est positionné
    private void OnTriggerEnter(Collider other)
    {
       /* if (redButton != null && !redButton.isPressed)
        {
            VoixTrigger.Play();
            Debug.Log("🔊 Voix déclenchée !");
            return;
        }*/
        if (other.CompareTag("fuse"))
        {
            // Repositionne le fusible
            other.transform.position = positionFinale.position;
            other.transform.rotation = positionFinale.rotation;
            enPosition = true; // Met à jour l'état du fusible
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
        }
    }
}
