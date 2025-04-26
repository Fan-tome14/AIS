using UnityEngine;

public class TriggerLit : MonoBehaviour
{
    public VRCanvasController CanvasController;

    void OnTriggerEnter(Collider other)
    {
        CanvasController.finishDay(); // on appelle la fonction quand le player entre dans la zone
    }
}
