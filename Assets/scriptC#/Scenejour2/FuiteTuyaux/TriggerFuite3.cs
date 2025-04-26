using UnityEngine;

public class TriggerFuite3 : MonoBehaviour
{   
    public AudioSource steamSound; // Référence à la source audio de la fuite de vapeur
    public bool isTriggered = false;
    public GameObject PressurisedSteam;
    public GameObject Tape;
    public GameObject groundFog;
    public AudioSource VoixTrigger;
    public AfficheMission AfficheMission;

    void Start()
    {
        Tape.SetActive(false); // on désactive le rouleau sur le tube
        PressurisedSteam.SetActive(true); // On active la fuite de vapeur au départ
    }

    private void OnTriggerEnter(Collider other)
    {
        if (AfficheMission != null && !AfficheMission.isPressed)
        {
            VoixTrigger.Play();
            Debug.Log("🔊 Voix déclenchée !");
            return;
        }
        if (other.CompareTag("tape"))
        {
            groundFog.SetActive(false); // Désactiver le brouillard au sol 1
            Tape.SetActive(true); // Désactiver le GameObject "tape"
            steamSound.Stop(); // Arrêter le son de la fuite de vapeur
            PressurisedSteam.SetActive(false); // Désactiver la fuite de vapeur
            isTriggered = true; // Marquer le déclencheur comme activé
        }
    }
}
