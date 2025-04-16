using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckMissions3 : MonoBehaviour
{
    public Toggle monCheckMark1;
    public Toggle monCheckMark2;
    public Toggle monCheckMark3;
    public MiseEnCommunFuite scriptMiseEnCommunFuite;
    public MiseEnCommun scriptMiseEnCommun;
    public GreenButton2 scriptButtonGrenne;
    public AudioSource terminer;
    public VRCanvasController2 cycleJourNuit;

    public static bool finishedday = false;
    public static bool dejaValider = false;

    public TextMeshProUGUI texteCheckMark1;
    public TextMeshProUGUI texteCheckMark2;
    public TextMeshProUGUI texteCheckMark3;

    // Tableaux pour les missions, chaque élément doit être un composant TextMeshProUGUI que vous connectez dans l'éditeur Unity
    public TextMeshProUGUI[] missionsJour = new TextMeshProUGUI[3];  // Taille du tableau défini à 3


    void Start()
    {
        missionsJour[0].text = "Reparer les fuites de vapeur";
        missionsJour[1].text = "Retrouver les fusibles et les replacer";
        missionsJour[2].text = "Eteindre l alarme";
        texteCheckMark1.text = missionsJour[0].text;
        texteCheckMark2.text = missionsJour[1].text;
        texteCheckMark3.text = missionsJour[2].text;
        Debug.Log("Jour 2 : " + missionsJour[0].text + ", " + missionsJour[1].text + ", " + missionsJour[2].text);

        // Initialisation des checkmarks à l'état désactivé
        if (monCheckMark1 != null)
        {
            monCheckMark1.isOn = false;
        }
        if (monCheckMark2 != null)
        {
            monCheckMark2.isOn = false;
        }
        if (monCheckMark3 != null)
        {
            monCheckMark3.isOn = false;
        }
    }

    void Update()
    {
        if (!dejaValider) ValiderMissions();
    }

    public void ValiderMissions()
    {
        if (scriptMiseEnCommunFuite != null)
        {
            if (scriptMiseEnCommunFuite.Check)
            {
                Debug.Log("Le casque a été équipé !// en refonte");
                if (monCheckMark1 != null)
                {
                    monCheckMark1.isOn = true;
                }
            }

            if (scriptMiseEnCommun.Check)
            {
                Debug.Log("Les fusibles ont été positionnés !");
                if (monCheckMark2 != null)
                {
                    monCheckMark2.isOn = true;
                }
            }
            if (scriptButtonGrenne.estActiver)
            {
                Debug.Log("L'alarme a été désactivée !");
                if (monCheckMark3 != null)
                {
                    monCheckMark3.isOn = true;
                }
            }
            Debug.Log("état des missions : " + scriptButtonGrenne.estActiver + ", " + scriptButtonGrenne.estActiver + ", " + scriptMiseEnCommun.Check);
            if (scriptButtonGrenne.estActiver && scriptMiseEnCommun.Check && scriptButtonGrenne.estActiver)
            {
                if (terminer != null)
                {
                    terminer.Play();
                    dejaValider = true;
                    finishedday = true;

                }
            }
        }
    }
}