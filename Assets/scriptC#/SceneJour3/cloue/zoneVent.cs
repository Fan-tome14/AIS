using UnityEngine;

public class zone : MonoBehaviour
{
    public Transform positionFinale;
    public bool enPosition = false; // Variable pour savoir si le ventilateur est positionné

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fan"))
        {
            // Positionne le ventilateur dans la zone 
            other.transform.position = positionFinale.position;
            other.transform.rotation = positionFinale.rotation;
            
            enPosition = true; // Met a jour l'état du ventilateur
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
    public int GetEnPosition()
    {
        return enPosition ? 1 : 0; // Retourne 1 si le ventilateur est en position, sinon 0
    }
}
