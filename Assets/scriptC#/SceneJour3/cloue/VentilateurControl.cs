using UnityEngine;


public class VentilateurControl : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable1;
    private int clousRestants = 4;
    private int clousRetirers = 0;

    public int ClousRetirer()
    { 
        return clousRetirers; 
    }
    public int ClousRestants()
    { 
        return clousRestants; 
    }
    private void OnEnable(){Clou.OnClouEnleve += EnleverUnClou;}

    private void OnDisable(){Clou.OnClouEnleve -= EnleverUnClou;}

    private void Start()
    {
        if (grabInteractable == null)
        {
            grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            grabInteractable1 = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        }

        grabInteractable.enabled = false; // pas grabbable au début
        grabInteractable1.enabled = false; // pas grabbable au début
    }

    private void EnleverUnClou()
    {
        clousRestants--;
        clousRetirers++;

        if (clousRestants <= 0)
        {
            // Si tous les clous sont enlevés, on active le grab interactable
            grabInteractable.enabled = true;
            grabInteractable1.enabled = true;
        }
    }
}
