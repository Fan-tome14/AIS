using UnityEngine;

public class MiseEnCommunFuite : MonoBehaviour
{
    public TriggerFuite1 triggerFuite1; // Référence au script TriggerFuite1
    public TriggerFuite2 triggerFuite2; // Référence au script TriggerFuite2
    public bool Check=false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerFuite1.isTriggered && triggerFuite2.isTriggered)
        {
            Check = true; // Les deux fusibles sont positionnés

        }
    }
}
