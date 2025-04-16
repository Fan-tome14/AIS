using UnityEngine;

public class TriggerReposer : MonoBehaviour
{
    public EquiperCasqueVR casque; // Référence au casque
    public static int nbFois=0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Casque"))
        {
            // Vérifier si le casque est déjà équipé avant de procéder
            if (casque.AEteEquipe)
            {
                Debug.Log("⚠️ Le casque est déjà équipé !");
                return; // Ne pas continuer si le casque est déjà équipé
            }

            // Réinitialiser la position du casque à son socle
            Transform socleCasque = casque.socleCasque;
            if (socleCasque != null &&nbFois%2==0)
            {
                nbFois++;
                Debug.Log("🔄 Tentative de repositionnement du casque...");
                other.transform.SetParent(null); // Détacher le casque de son parent actuel
                other.transform.position = socleCasque.position; // Positionner le casque sur le socle
                other.transform.rotation = socleCasque.rotation; // Rotation du casque sur le socle
                Debug.Log("📌 Casque repositionné sur le socle !");
            }else
            {
                Debug.LogError("⚠️ Socle du casque non trouvé !");
            }
        }
    }
}
