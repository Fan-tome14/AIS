using UnityEngine;

public class cloue2 : MonoBehaviour
{
    public Transform positionFinale;
    public bool enPosition = false; // Variable pour savoir si le fusible est positionné
    private int max = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("visenew"))
        {
            if (max == 1)
            {
                return;
            }
            // Repositionne le fusible
            max++;
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
