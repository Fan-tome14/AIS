using UnityEngine;

public class RepairZone : MonoBehaviour
{
    public SolarPanelRepairManager manager; // à lier dans l'inspecteur
    public string tournevisTag = "Tournevis";
    private bool repaired = false;

    public float targetY = -0.2477f;
    public float rotationSpeed = 360f; // degrés/sec
    public float moveSpeed = 1f;

    private bool isRepairing = false;
    private Vector3 targetPosition;

    public AudioSource repairAudioSource; // Référence à l'AudioSource
    public AudioClip repairSound; // Clip audio à jouer

    private void Start()
    {
        // Position de destination de la vis
        targetPosition = new Vector3(transform.localPosition.x, targetY, transform.localPosition.z);

        // Si un AudioSource n'est pas assigné, en créer un
        if (repairAudioSource == null)
        {
            repairAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // Si le clip n'est pas assigné, afficher un message d'avertissement
        if (repairSound == null)
        {
            Debug.LogWarning("Le clip audio n'est pas assigné !");
        }
    }

    private void Update()
    {
        if (isRepairing)
        {
            // Mouvement vers le bas
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
            // Rotation sur Z
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

            // Jouer l'audio si ce n'est pas déjà joué
            if (!repairAudioSource.isPlaying && repairSound != null)
            {
                repairAudioSource.PlayOneShot(repairSound);
            }

            // Quand elle est vissée complètement
            if (Vector3.Distance(transform.localPosition, targetPosition) < 0.001f)
            {
                isRepairing = false;

                if (manager != null)
                {
                    manager.RegisterRepair();
                }

                // Tu peux désactiver la vis si tu veux :
                // gameObject.SetActive(false);

                // Arrêter le son après la réparation
                repairAudioSource.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!repaired && other.CompareTag(tournevisTag))
        {
            Debug.Log($"{gameObject.name} réparée !");
            repaired = true;
            isRepairing = true;
        }
    }
}
