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
    private Vector3 initialPosition; // Position initiale du bouton

    public bool estActiver { get { return alarme; } private set { alarme = value; } }

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        initialPosition = transform.localPosition;

        if (grabInteractable != null)
            grabInteractable.selectEntered.AddListener(OnButtonPressed);
        else
            Debug.LogError("⚠️ XRGrabInteractable manquant sur le cube !");
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        // Si les autres tâches n'ont pas été validées, on ne fait rien
        if (scriptMiseEnCommunFuite != null && !scriptMiseEnCommunFuite.Check && scriptMiseEnCommun != null && !scriptMiseEnCommun.Check)
        {
            VoixTrigger.Play();
            return;
        }

        if (scriptMiseEnCommunFuite != null && scriptMiseEnCommunFuite.Check && scriptMiseEnCommun != null && scriptMiseEnCommun.Check)
        {
            if (alarmSystem != null)
                alarmSystem.StopAlarm();

            // Animation d'appui visuel du bouton (modification de la position)
            StartCoroutine(AnimateButtonPress());

            // Alarme désactivée
            alarme = true;

            // Appelle la fonction de validation des missions
            scriptCheckMissions.ValiderMissions();
        }
    }

    private IEnumerator AnimateButtonPress()
    {
        Vector3 targetPosition = initialPosition + new Vector3(0, -0.05f, 0); // Déplacement du bouton sur l'axe Y pour l'enfoncement
        float timeToPress = 0.2f; // Durée de l'appui (en secondes)
        float elapsedTime = 0f;

        // Assurez-vous que le bouton reste visible
        gameObject.SetActive(true);

        // Animation pour simuler l'enfoncement du bouton (modification de la position)
        while (elapsedTime < timeToPress)
        {
            transform.localPosition = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / timeToPress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // S'assurer que le bouton arrive à la position cible
        transform.localPosition = targetPosition;

        yield return new WaitForSeconds(0.2f); // Temps de l'appui avant de revenir à la position initiale

        // Retour à la position initiale
        elapsedTime = 0f;
        while (elapsedTime < timeToPress)
        {
            transform.localPosition = Vector3.Lerp(targetPosition, initialPosition, elapsedTime / timeToPress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Position finale
        transform.localPosition = initialPosition;
    }
}
