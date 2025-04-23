using UnityEngine;

public class TriggerReposer : MonoBehaviour
{
    public EquiperCasqueVR casque; // Référence au casque

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Casque"))
        {
            casque.RepositionnerCasque(); // Appel propre
        }
    }
}
