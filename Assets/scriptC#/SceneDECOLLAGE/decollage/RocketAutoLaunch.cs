using UnityEngine;

public class RocketAutoLaunch : MonoBehaviour
{
    public Rigidbody rocketRigidbody;  // Assigner le Rigidbody de la fusée
    public float launchForce = 1500f;   // Force de lancement pour reculer
    public float delayBeforeLaunch = 15f;  // Délai avant le décollage
    public AudioSource launchAudio;  // Son de lancement
    public ParticleSystem launchEffect;  // Effet de particules

    void Start()
    {
        // Vérifier si le Rigidbody est bien assigné
        if (rocketRigidbody == null)
        {
            rocketRigidbody = GetComponent<Rigidbody>();
        }

        // Vérifier si l'AudioSource est bien assigné
        if (launchAudio == null)
        {
            launchAudio = GetComponent<AudioSource>();
        }

        // Vérifier si le ParticleSystem est bien assigné
        if (launchEffect == null)
        {
            launchEffect = GetComponentInChildren<ParticleSystem>(); // Récupère le ParticleSystem enfant
        }

        // Geler la fusée au départ
        rocketRigidbody.linearVelocity = Vector3.zero;
        rocketRigidbody.angularVelocity = Vector3.zero;

        // Lancer la fusée après un délai
        Invoke("LaunchRocket", delayBeforeLaunch);
    }

    void LaunchRocket()
    {
        Debug.Log("Décollage... !");

        // Jouer le son de lancement
        if (launchAudio != null)
        {
            launchAudio.Play();
        }
        else
        {
            Debug.LogWarning("Aucun AudioSource trouvé sur l'objet de la fusée !");
        }

        // Activer l'effet de particules
        if (launchEffect != null)
        {
            launchEffect.Play();
        }
        else
        {
            Debug.LogWarning("Aucun ParticleSystem trouvé sur l'objet de la fusée !");
        }

        // Assurer que la fusée n'est plus en mode cinématique
        rocketRigidbody.isKinematic = false;

        // Appliquer la force de lancement
        Vector3 launchDirection = transform.forward;
        rocketRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }
}
