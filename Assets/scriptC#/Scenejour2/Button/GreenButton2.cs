using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class GreenButton2 : MonoBehaviour
{
    public AudioSource soundbutton;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private Vector3 initialPosition; // Position de base du bouton
    public MiseEnCommunFuite scriptMiseEnCommunFuite; // Référence au script de mise en commun de fuite
    public AlarmSystem alarmSystem; // Référence au script de l'alarme
    public AudioSource VoixTrigger; // Référence à la source audio
    public CheckMissions2 scriptCheckMissions; // Référence au script CheckMissions
    private bool alarme = false;  // Détermine si le vaisseau doit bouger ou non
    public bool estActiver { get { return alarme; } private set { alarme = value; } }

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        initialPosition = transform.localPosition;

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
            grabInteractable.hoverEntered.AddListener(OnHoverEntered);
        }
        else
        {
            Debug.LogError("⚠️ XRGrabInteractable manquant sur le cube !");
        }

    }


    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (scriptMiseEnCommunFuite != null && !scriptMiseEnCommunFuite.Check)
        {
            VoixTrigger.Play();
            Debug.Log("🔴 Alarme déjà désactivée !");
            return;
        }
        Debug.Log("🟢 Bouton Pressé, arrêt de l'alarme et des lumières...");
        if (alarmSystem != null)
        {
            alarmSystem.StopAlarm();
        }

        // 🔊 Lancer le son si la source audio est définie
        if (soundbutton != null)
        {
            soundbutton.Play();
        }
        else
        {
            Debug.LogWarning("🔇 Aucun sondbutton assigné !");
        }

        // ▶️ Animation d'appui physique du bouton
        StartCoroutine(AnimateButtonPress());

        // Commencer à déplacer le vaisseau
        alarme = true;

        Debug.Log("etat de l'alarme : " + estActiver);
        scriptCheckMissions.ValiderMissions();
    }

    private IEnumerator AnimateButtonPress()
    {
        // Descendre le bouton
        transform.localPosition += new Vector3( -0.1f , 0, 0);
        yield return new WaitForSeconds(0.2f); // Durée de l'appui
        // Revenir à la position initiale
        transform.localPosition = initialPosition;
    }

    private void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Vous pouvez ajouter des effets de survol ici
        Debug.Log("🟡 Hover sur le bouton !");
    }
}
