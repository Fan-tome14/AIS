using UnityEngine;


public class VentilateurControl : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable1;
    private int clousRestants = 4;

    private void OnEnable()
    {
        Clou.OnClouEnleve += EnleverUnClou;
    }

    private void OnDisable()
    {
        Clou.OnClouEnleve -= EnleverUnClou;
    }

    private void Start()
    {
        if (grabInteractable == null)
        {
            grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
            grabInteractable1 = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        }

        grabInteractable.enabled = false; // pas grabbable au d�but
        grabInteractable1.enabled = false; // pas grabbable au d�but
    }

    private void EnleverUnClou()
    {
        clousRestants--;

        if (clousRestants <= 0)
        {
            grabInteractable.enabled = true;
            grabInteractable1.enabled = true;
        }
    }
}
