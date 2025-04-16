using UnityEngine;

public class MiseEnCommun : MonoBehaviour
{
    public PositionningFusible2 positionningFusible2; // Référence au script PositionningFusible2
    public PositionningFusible positionningFusible; // Référence au script PositionningFusible
    public GameObject ElectricalSparks;
    public bool Check=false; // Variable pour vérifier si les deux fusibles sont positionnés
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
