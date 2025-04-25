using UnityEngine;

public class zoneCloue : MonoBehaviour
{
    public Transform positionFinale;
    public bool enPosition = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("visenew"))
        {
            other.transform.position = positionFinale.position;
            other.transform.rotation = positionFinale.rotation;
            enPosition = true; 
            var grabInteractable = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.enabled = false;
            }
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
