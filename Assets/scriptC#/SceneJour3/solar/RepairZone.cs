using UnityEngine;

public class RepairZone : MonoBehaviour
{
    public SolarPanelRepairManager manager;
    public string tournevisTag = "Tournevis";
    private bool repaired = false;

    public float targetY = -0.2477f;
    public float moveSpeed = 1f;
    public float rotationSpeed = 720f; // Vitesse de rotation (plus élevée qu'avant)
    public int totalRotations = 5; // nombre de tours (5 x 360°)

    private bool isRepairing = false;
    private Vector3 targetPosition;
    private float currentRotation = 0f;
    private bool hasMoved = false;

    private void Start()
    {
        targetPosition = new Vector3(transform.localPosition.x, targetY, transform.localPosition.z);
    }

    private void Update()
    {
        if (isRepairing)
        {
            // Mouvement vers le bas (une seule fois)
            if (!hasMoved)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.localPosition, targetPosition) < 0.001f)
                {
                    hasMoved = true;
                }
            }

            // Rotation (jusqu’à totalRotations atteints)
            if (currentRotation < totalRotations * 360f)
            {
                float rotationThisFrame = rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationThisFrame);
                currentRotation += rotationThisFrame;
            }
            else
            {
                isRepairing = false;

                if (manager != null)
                {
                    manager.RegisterRepair();
                }

                // Tu peux désactiver ici :
                // gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!repaired && other.CompareTag(tournevisTag))
        {
            Debug.Log($"{gameObject.name} réparée (avec vissage prolongé) !");
            repaired = true;
            isRepairing = true;
        }
    }
}
