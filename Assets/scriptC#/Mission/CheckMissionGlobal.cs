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
    public TextMeshProUGUI texteCheckMark4;
    public TextMeshProUGUI[] missionsJour = new TextMeshProUGUI[3];

    public AudioSource terminer;

    // Jour 1
    public EquiperCasqueVR scriptCasqueVR;
    public LevierScript scriptLevier;

    // Jour 2
    public MiseEnCommunFuite scriptMiseEnCommunFuite;
    public MiseEnCommun scriptMiseEnCommun;
    public GreenButton scriptButtonGreen;

    // Jour 3
    public CommunPanneauSolaire CommunPanneauSolaire;
    public GameController GameController;
    public ClouManager ClouManager;
    public VentilateurControl scriptVentilateurControl;
    public zone scriptZone;

    private int etape = 1;
    public static bool finishedday = false;
    public static bool dejaValider = false;

    void Start()
    {
        finishedday = false;
        dejaValider = false;

        if (VRCanvasController.numjours == 1)
        {
            missionsJour[0].text = "Équiper le casque";
            missionsJour[1].text = "Reposer le casque";
            missionsJour[2].text = "Démarrer le vaisseau";
        }
        else if (VRCanvasController.numjours == 2)
        {
            missionsJour[0].text = $"Réparer les fuites de vapeur ({scriptMiseEnCommunFuite.fixedCount}/3)";
            missionsJour[1].text = $"Retrouver les fusibles ({scriptMiseEnCommun.nbFusible}/2)";
            missionsJour[2].text = "Éteindre l'alarme";
        }
        else if (VRCanvasController.numjours == 3)
        {
            missionsJour[0].text = "Régler la température du vaisseau dans la salle des machines";
            missionsJour[1].text = $"Reserrer les boulons des 4 plaques en dehors du vaisseau ({CommunPanneauSolaire.repairedCount}/4)";
            missionsJour[2].text = "Remplacer le ventilateur du satellite";
            texteCheckMark4.text = $"Étape {etape} : Retirer les clous du ventilateur ({scriptVentilateurControl.ClousRetirer()}/4)";
        }

        texteCheckMark1.text = missionsJour[0].text;
        texteCheckMark2.text = missionsJour[1].text;
        texteCheckMark3.text = missionsJour[2].text;

        monCheckMark1.isOn = false;
        monCheckMark2.isOn = false;
        monCheckMark3.isOn = false;
    }

    void Update()
    {
        if (VRCanvasController.numjours == 2 && scriptMiseEnCommunFuite != null && scriptMiseEnCommun != null)
        {
            missionsJour[1].text = $"Retrouver les fusibles ({scriptMiseEnCommun.nbFusible}/2)";
            texteCheckMark2.text = missionsJour[1].text;

            missionsJour[0].text = $"Réparer les fuites de vapeur ({scriptMiseEnCommunFuite.fixedCount}/3)";
            texteCheckMark1.text = missionsJour[0].text;
        }

        if (VRCanvasController.numjours == 3 && CommunPanneauSolaire != null)
        {
            CommunPanneauSolaire.CheckPanneauSolaire();

            missionsJour[1].text = $"Viser les boulons des 4 plaques en dehors du vaisseau ({CommunPanneauSolaire.repairedCount}/4)";
            texteCheckMark2.text = missionsJour[1].text;

            if (scriptVentilateurControl != null && scriptZone != null && ClouManager != null)
            {
                if (etape == 1)
                {
                    texteCheckMark4.text = $"Étape {etape} : Retirer les clous du ventilateur ({scriptVentilateurControl.ClousRetirer()}/4)";

                    if (scriptVentilateurControl.ClousRestants() == 0)
                    {
                        etape++;
                    }
                }
                else if (etape == 2)
                {
                    texteCheckMark4.text = $"Étape {etape} : Changer le ventilateur ({scriptZone.GetEnPosition()}/1)";

                    if (scriptZone.GetEnPosition() == 1)
                    {
                        etape++;
                    }
                }
                else if (etape == 3)
                {
                    texteCheckMark4.text = $"Étape {etape} : Clouter la ventilation avec le marteau ({ClouManager.clousPlacer}/4)";
                }
            }
        }

        if (!dejaValider)
            ValiderMissions();
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
        }
        else if (VRCanvasController.numjours == 3 && CommunPanneauSolaire != null && GameController != null)
        {
            m1 = GameController.hasPlayedSound;
            m2 = CommunPanneauSolaire.isRepaired;
            m3 = ClouManager.isDone;
        }

        monCheckMark1.isOn = m1;
        monCheckMark2.isOn = m2;
        monCheckMark3.isOn = m3;

        Debug.Log($"📝 Validation missions : {m1}, {m2}, {m3}");

        if (m1 && m2 && m3 && !dejaValider)
        {
            if (terminer != null)
                terminer.Play();

            dejaValider = true;
            finishedday = true;

            Debug.Log("✅ Toutes les missions de la journée sont validées !");
        }
    }
}
