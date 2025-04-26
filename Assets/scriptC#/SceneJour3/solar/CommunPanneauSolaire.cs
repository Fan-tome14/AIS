using UnityEngine;

public class CommunPanneauSolaire : MonoBehaviour
{
    public SolarPanelRepairManager scriptSolarPanelRepairManager;
    public SolarPanelRepairManager scriptSolarPanelRepairManager2;
    public SolarPanelRepairManager scriptSolarPanelRepairManager3;
    public SolarPanelRepairManager scriptSolarPanelRepairManager4;

    public bool isRepaired = false; // Indique si tous les panneaux sont réparés
    public int repairedCount = 0;   // Nombre de panneaux réparés

    public void CheckPanneauSolaire()
    {
        repairedCount = 0; // On remet à zéro avant de compter

        if (scriptSolarPanelRepairManager.isRepaired) repairedCount++;
        if (scriptSolarPanelRepairManager2.isRepaired) repairedCount++;
        if (scriptSolarPanelRepairManager3.isRepaired) repairedCount++;
        if (scriptSolarPanelRepairManager4.isRepaired) repairedCount++;

        isRepaired = (repairedCount == 4); // Tous réparés ?
    }
}
