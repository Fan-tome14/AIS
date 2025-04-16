using UnityEngine;

public class TriggerFuite1 : MonoBehaviour
{
    public bool isTriggered = false;
    public GameObject PressurisedSteam;
    public AudioSource steamSound; // Référence à la source audio de la fuite de vapeur
    public GameObject Tape1; // Référence au GameObject "tape"
    public GameObject groundFog1;
    public GameObject groundFog2;
    public GameObject groundFog3;
    public GameObject groundFog4;
    public RedButton2 redButton; // Référence au script RedButton
    public AudioSource VoixTrigger;

    void Start()
    {
        Tape1.SetActive(false); // Assurez-vous que le GameObject "tape" est désactivé au départ
        PressurisedSteam.SetActive(true); // Assurez-vous que la fuite de vapeur est activée au départ
    }

    private void OnTriggerEnter(Collider other)
    {
        if (redButton != null && !redButton.isPressed)
        {
            VoixTrigger.Play();
            Debug.Log("🔊 Voix déclenchée !");
            return;
        }
        if (other.CompareTag("tape"))
        {
            groundFog1.SetActive(false); // Désactiver le brouillard au sol 1
            groundFog2.SetActive(false); // Désactiver le brouillard au sol 2
            groundFog3.SetActive(false); // Désactiver le brouillard au sol 3
            groundFog4.SetActive(false); // Désactiver le brouillard au sol 4
            Tape1.SetActive(true); // Désactiver le GameObject "tape"
            steamSound.Stop(); // Arrêter le son de la fuite de vapeur
            PressurisedSteam.SetActive(false); // Désactiver la fuite de vapeur
            isTriggered = true; // Marquer le déclencheur comme activé
            Debug.Log("Escape sequence triggered!");
        }
    }
}
