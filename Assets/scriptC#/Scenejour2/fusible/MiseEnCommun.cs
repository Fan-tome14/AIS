using UnityEngine;

public class MiseEnCommun : MonoBehaviour
{
    public PositionningFusible2 positionningFusible2; // Référence au script PositionningFusible2
    public PositionningFusible positionningFusible; // Référence au script PositionningFusible
    public GameObject ElectricalSparks;
    public bool Check=false; // Variable pour vérifier si les deux fusibles sont positionnés
    public int nbFusible = 0; // Nombre de fusibles positionnés

    public void CheckFusible()
    {
        nbFusible = 0; // Réinitialiser le compteur à chaque vérification
        if(positionningFusible2.enPosition)nbFusible++;
        if(positionningFusible.enPosition)nbFusible++;
        if(positionningFusible2.enPosition && positionningFusible.enPosition)
        {
            
            this.Check = true; // Les deux fusibles sont positionnés
            if (ElectricalSparks != null)
            {
                ElectricalSparks.SetActive(false); // Désactiver les étincelles électriques
            }            
        }
    }
}
