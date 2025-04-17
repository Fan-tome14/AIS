using UnityEngine;

public class SolarPanelRepairManager : MonoBehaviour
{
    public Animator panneauAnimator;
    public int totalRepairs = 4; // � ajuster dans l'inspecteur si besoin
    private int currentRepairs = 0;

    public void RegisterRepair()
    {
        currentRepairs++;
        Debug.Log($"R�paration enregistr�e : {currentRepairs}/{totalRepairs}");

        if (currentRepairs >= totalRepairs)
        {
            Debug.Log("Toutes les r�parations sont faites, ouverture du panneau !");
            panneauAnimator.SetTrigger("Open");
        }
    }
}
