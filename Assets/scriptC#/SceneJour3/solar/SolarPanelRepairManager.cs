using UnityEngine;

public class SolarPanelRepairManager : MonoBehaviour
{
    public Animator panneauAnimator;
    public int totalRepairs = 4;
    public CommunPanneauSolaire CommunPanneauSolaire;
    private int currentRepairs = 0;
    public bool isRepaired = false;  // indique si le panneau est réparé

    public void RegisterRepair()
    {
        currentRepairs++; // Incrémenter le nombre de réparations effectuées
        if (currentRepairs >= totalRepairs)
        {
            isRepaired = true; // Le panneau est réparé
            // lancer l'animation d'ouverture du panneau puis vérifier l'état du panneau solaire
            panneauAnimator.SetTrigger("Open");
            CommunPanneauSolaire.CheckPanneauSolaire(); 
        }
    }
}
