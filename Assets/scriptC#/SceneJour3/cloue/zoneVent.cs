using UnityEngine;

public class zone : MonoBehaviour
{
    public Transform positionFinale;
    public bool enPosition = false; // Variable pour savoir si le fusible est positionn�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fan"))
        {
            // Positionne le cloue dans la zone de la zone de ventilation
            other.transform.position = positionFinale.position;
            other.transform.rotation = positionFinale.rotation;
            
            enPosition = true; // Met a jour l'état du cloue
            var grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)grabInteractable.enabled = false;
            
            // Désactive le Rigidbody pour éviter les interactions physiques
            var rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }
}
