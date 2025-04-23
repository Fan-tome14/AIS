using UnityEngine;

public class CommunPanneauSolaire : MonoBehaviour
{
    public SolarPanelRepairManager scriptSolarPanelRepairManager;
    public SolarPanelRepairManager scriptSolarPanelRepairManager2;
    public SolarPanelRepairManager scriptSolarPanelRepairManager3;
    public SolarPanelRepairManager scriptSolarPanelRepairManager4;

    public bool isRepaired = false; // Indique si le panneau est réparé ou non

    public void CheckPanneauSolaire()
    {
        if (scriptSolarPanelRepairManager.isRepaired && scriptSolarPanelRepairManager2.isRepaired && scriptSolarPanelRepairManager3.isRepaired && scriptSolarPanelRepairManager4.isRepaired)
        {
            isRepaired = true; // Le panneau est réparé
        }
    }
}
