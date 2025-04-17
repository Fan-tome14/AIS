using UnityEngine;

public class SolarPanelRepairManager : MonoBehaviour
{
    public Animator panneauAnimator;
    public int totalRepairs = 4; // à ajuster dans l'inspecteur si besoin
    private int currentRepairs = 0;

    public void RegisterRepair()
    {
        currentRepairs++;
        Debug.Log($"Réparation enregistrée : {currentRepairs}/{totalRepairs}");

        if (currentRepairs >= totalRepairs)
        {
            Debug.Log("Toutes les réparations sont faites, ouverture du panneau !");
            panneauAnimator.SetTrigger("Open");
        }
    }
}
