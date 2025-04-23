using UnityEngine;

public class SolarPanelRepairManager : MonoBehaviour
{
    public Animator panneauAnimator;
    public int totalRepairs = 4; // � ajuster dans l'inspecteur si besoin
    public CommunPanneauSolaire CommunPanneauSolaire;
    private int currentRepairs = 0;
    public bool isRepaired = false; // Indique si le panneau est r�par� ou non

    public void RegisterRepair()
    {
        currentRepairs++;
        Debug.Log($"R�paration enregistr�e : {currentRepairs}/{totalRepairs}");

        if (currentRepairs >= totalRepairs)
        {
            isRepaired = true; // Le panneau est r�par�
            Debug.Log("Toutes les r�parations sont faites, ouverture du panneau !");
            panneauAnimator.SetTrigger("Open");
            CommunPanneauSolaire.CheckPanneauSolaire(); 
        }
    }
}
