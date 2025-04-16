using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PressOnSelect : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;
    private Button3D button;

    void Start()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        button = GetComponent<Button3D>();

        interactable.selectEntered.AddListener(OnSelect);
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        button.Press();
    }
}
