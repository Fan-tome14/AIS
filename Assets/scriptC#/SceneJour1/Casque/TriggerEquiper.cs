using UnityEngine;

public class TriggerEquiper : MonoBehaviour
{
    public EquiperCasqueVR casque; // Référence au casque

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Casque"))
        {
            casque.EquiperManuellement(); // Appel propre
        }
    }


}
