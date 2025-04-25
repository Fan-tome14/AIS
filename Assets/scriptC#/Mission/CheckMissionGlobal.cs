using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckMissionsGlobal : MonoBehaviour
{
    public Toggle monCheckMark1;
    public Toggle monCheckMark2;
    public Toggle monCheckMark3;

    public TextMeshProUGUI texteCheckMark1;
    public TextMeshProUGUI texteCheckMark2;
    public TextMeshProUGUI texteCheckMark3;
    public TextMeshProUGUI[] missionsJour = new TextMeshProUGUI[3];

    public AudioSource terminer;

    // Jour 1
    public EquiperCasqueVR scriptCasqueVR;
    public LevierScript scriptLevier;

    // Jour 2
    public MiseEnCommunFuite scriptMiseEnCommunFuite;
    public MiseEnCommun scriptMiseEnCommun;
    public GreenButton2 scriptButtonGreen;

    //Jour 3
    public CommunPanneauSolaire CommunPanneauSolaire;
    public GameController GameController;
    public ClouManager ClouManager;

    public static bool finishedday = false;
    public static bool dejaValider = false;

    void Start()
    {
        // Réinitialisation à chaque jour
        finishedday = false;
        dejaValider = false;
        // Init missions selon le jour
        if (VRCanvasController.numjours == 1)
        {
            missionsJour[0].text = "Equiper le casque";
            missionsJour[1].text = "Reposer le casque";
            missionsJour[2].text = "Demarrer le vaisseau";
        }
        else if (VRCanvasController.numjours == 2)
        {
            missionsJour[0].text = "Reparer les fuites de vapeur";
            missionsJour[1].text = "Retrouver les fusibles";
            missionsJour[2].text = "Eteindre l alarme";
        }else if(VRCanvasController.numjours == 3)
        {
            missionsJour[0].text = "Régler la température du vaisseau dans la salle des machines";
            missionsJour[1].text = "Viser les boulons des 4 plaques en dehors du vaisseau  ("+CommunPanneauSolaire.repairedCount+"/4)";
            missionsJour[2].text = "Changer le ventilateur du téléscope par le nouveau";
        }

        // Affecter les textes aux checkmarks
        texteCheckMark1.text = missionsJour[0].text;
        texteCheckMark2.text = missionsJour[1].text;
        texteCheckMark3.text = missionsJour[2].text;

        // Désactiver les cases à cocher
        monCheckMark1.isOn = false;
        monCheckMark2.isOn = false;
        monCheckMark3.isOn = false;
    }

    void Update()
    {
        if (VRCanvasController.numjours == 3 && CommunPanneauSolaire != null)
        {
            CommunPanneauSolaire.CheckPanneauSolaire(); // Met à jour repairedCount
            string missionText = "Viser les boulons des 4 plaques en dehors du vaisseau  (" + CommunPanneauSolaire.repairedCount + "/4)";
            missionsJour[1].text = missionText;
            texteCheckMark2.text = missionText;
        }
        if (!dejaValider) ValiderMissions();
    }

    public void ValiderMissions()
    {
        bool m1 = false, m2 = false, m3 = false;

        if (VRCanvasController.numjours == 1 && scriptCasqueVR != null && scriptLevier != null)
        {
            m1 = scriptCasqueVR.AEteEquipe;
            m2 = scriptCasqueVR.AEteRepose;
            m3 = scriptLevier.estActiver;
        }
        else if (VRCanvasController.numjours == 2 && scriptMiseEnCommunFuite != null && scriptMiseEnCommun != null && scriptButtonGreen != null)
        {
            m1 = scriptMiseEnCommunFuite.Check;
            m2 = scriptMiseEnCommun.Check;
            m3 = scriptButtonGreen.estActiver;
        }else if(VRCanvasController.numjours == 3 && CommunPanneauSolaire != null && GameController != null)
        {
            m1 = GameController.hasPlayedSound;
            m2 = CommunPanneauSolaire.isRepaired;
            m3 = ClouManager.isDone;
        }
        if (m1) monCheckMark1.isOn = true;
        if (m2) monCheckMark2.isOn = true;
        if (m3) monCheckMark3.isOn = true;

        Debug.Log($"État des missions : {m1}, {m2}, {m3}");

        if (m1 && m2 && m3)
        {
            if (terminer != null && !dejaValider)
            {
                terminer.Play();
                dejaValider = true;
                finishedday = true;
                Debug.Log("✅ Toutes les missions du jour sont validées !");
            }
        }
    }
}
