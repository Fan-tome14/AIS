using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class GreenButton2 : MonoBehaviour
{
    public AudioSource soundbutton;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable buttonInteractable;
    public MiseEnCommunFuite scriptMiseEnCommunFuite;
    public MiseEnCommun scriptMiseEnCommun;
    public AlarmSystem alarmSystem;
    public AudioSource VoixTrigger;
    public CheckMissionsGlobal scriptCheckMissions;

    private bool alarme = false;
    public bool estActiver { get { return alarme; } private set { alarme = value; } }

    private void Start()
    {
        buttonInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        
        if (buttonInteractable != null)
        {
            buttonInteractable.selectEntered.AddListener(OnButtonPressed);
            buttonInteractable.hoverEntered.AddListener(OnHoverEntered);
        }
        else
        {
            Debug.LogError("❌ XRSimpleInteractable manquant !");
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (scriptMiseEnCommunFuite != null && !scriptMiseEnCommunFuite.Check && scriptMiseEnCommun != null && !scriptMiseEnCommun.Check)
        {
            VoixTrigger.Play();
            Debug.Log("🔴 Alarme déjà désactivée !");
            return;
        }

        Debug.Log("🟢 Bouton Pressé, arrêt de l'alarme et des lumières...");
        alarmSystem?.StopAlarm();
        soundbutton?.Play();
        StartCoroutine(AnimateButtonPress());

        alarme = true;
        Debug.Log("etat de l'alarme : " + estActiver);
        scriptCheckMissions.ValiderMissions();
    }

    private IEnumerator AnimateButtonPress()
    {
        transform.localPosition += new Vector3(0f, -0.02f, 0f);
        yield return new WaitForSeconds(0.15f);
        transform.localPosition -= new Vector3(0f, 0f, 0f);
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        Debug.Log("🟡 Hover sur le bouton !");
    }
}
