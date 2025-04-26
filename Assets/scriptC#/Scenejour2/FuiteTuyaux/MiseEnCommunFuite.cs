using UnityEngine;

public class MiseEnCommunFuite : MonoBehaviour
{
    public TriggerFuite1 triggerFuite1; // Référence au script TriggerFuite1
    public TriggerFuite2 triggerFuite2; // Référence au script TriggerFuite2
    public TriggerFuite3 triggerFuite3; // Référence au script TriggerFuite2
    public bool Check=false; 


    void Update()
    {
        if(triggerFuite1.isTriggered && triggerFuite2.isTriggered&& triggerFuite3.isTriggered)
        {
            Check = true; // Chaque fuite est bouchée

        }
    }
}
