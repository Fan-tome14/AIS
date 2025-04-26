using UnityEngine;

public class zoneCloue : MonoBehaviour
{
    public Transform positionFinale;
    public bool enPosition = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("visenew"))
        {
            // Positionne le clou au bon endroit
            other.transform.position = positionFinale.position;
            other.transform.rotation = positionFinale.rotation;
            // Met à jour l'état du clou
            enPosition = true; 
            
            // Désactive l'interaction avec le clou
            var grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)grabInteractable.enabled = false;

            // Désactive la gravité et le mouvement du clou
            // Récupère le Rigidbody et le BoxCollider du clou
            var rb = other.GetComponent<Rigidbody>();
            var BoxCollider = other.GetComponent<BoxCollider>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
            if (BoxCollider != null)
            {
                BoxCollider.isTrigger = true;
            }
        }
    }
}
