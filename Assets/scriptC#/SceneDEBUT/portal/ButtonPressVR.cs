using UnityEngine;

public class ButtonPressVR : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.Log("Bouton pressé !");
            objectToActivate.SetActive(!objectToActivate.activeSelf);
        }
    }
}
