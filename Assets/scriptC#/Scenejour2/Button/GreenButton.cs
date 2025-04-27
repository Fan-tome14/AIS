using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class GreenButton : MonoBehaviour
{
    public MiseEnCommunFuite scriptMiseEnCommunFuite; // Référence au script de mise en commun de fuite
    public MiseEnCommun scriptMiseEnCommun; // Référence au script de mise en commun
    public CheckMissionsGlobal scriptCheckMissions; // Référence au script CheckMissions

    public AlarmSystem alarmSystem; // Référence au script de l'alarme
    public AudioSource VoixTrigger; // Référence à la source audio
    private bool alarme = false;  
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Vector3 initialPosition; // Position de base du bouton

    public bool estActiver { get { return alarme; } private set { alarme = value; } }

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        initialPosition = transform.localPosition;

        if (grabInteractable != null)grabInteractable.selectEntered.AddListener(OnButtonPressed);
        else Debug.LogError("⚠️ XRGrabInteractable manquant sur le cube !");
    }


    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        // Si les autres n'ont pas été validées taches on ne fait rien
        if (scriptMiseEnCommunFuite != null && !scriptMiseEnCommunFuite.Check && scriptMiseEnCommun != null && !scriptMiseEnCommun.Check)
        {
            VoixTrigger.Play();
            return;
        }
        if (alarmSystem != null)alarmSystem.StopAlarm();
        
        // Animation d'appui physique du bouton
        StartCoroutine(AnimateButtonPress());

        // Alarme désactivée
        alarme = true;
        // appelle la fonction de validation des missions
        scriptCheckMissions.ValiderMissions();
    }

    private IEnumerator AnimateButtonPress()
    {
        // Descendre le bouton
        transform.localPosition += new Vector3(0, 0, -0.1f); 
        yield return new WaitForSeconds(0.2f); // Durée de l'appui
        // Revenir à la position initiale
        transform.localPosition = initialPosition;
    }
}
