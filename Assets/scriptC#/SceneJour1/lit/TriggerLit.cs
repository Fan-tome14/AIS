using UnityEngine;

public class TriggerLit : MonoBehaviour
{
    public VRCanvasController CanvasController;
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("🚪 On entre dans le lit !");
        CanvasController.finishDay();
    }
}
