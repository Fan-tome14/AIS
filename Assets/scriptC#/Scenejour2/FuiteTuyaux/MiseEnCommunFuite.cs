using UnityEngine;

public class MiseEnCommunFuite : MonoBehaviour
{
    public TriggerFuite1 triggerFuite1; // Référence au script TriggerFuite1
    public TriggerFuite2 triggerFuite2; // Référence au script TriggerFuite2
    public TriggerFuite3 triggerFuite3; // Référence au script TriggerFuite2
    public bool Check=false; 
    public int fixedCount = 0; // Compteur pour le nombre de fuites réparées


    public void CheckFuite()
    {
        fixedCount = 0; // Réinitialiser le compteur à chaque vérification
        if(triggerFuite1.isTriggered)fixedCount++;
        if(triggerFuite2.isTriggered)fixedCount++;
        if(triggerFuite3.isTriggered)fixedCount++;
        if(triggerFuite1.isTriggered && triggerFuite2.isTriggered&& triggerFuite3.isTriggered)
        {
            Check = true; // Chaque fuite est bouchée
        }
    }
}
