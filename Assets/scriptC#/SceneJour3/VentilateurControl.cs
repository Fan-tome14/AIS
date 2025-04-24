using UnityEngine;


public class VentilateurControl : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
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
            grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        grabInteractable.enabled = false; // pas grabbable au d�but
    }

    private void EnleverUnClou()
    {
        clousRestants--;

        if (clousRestants <= 0)
        {
            grabInteractable.enabled = true;
        }
    }
}
