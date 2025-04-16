using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 1f;
    private Vector3 rotationAxis;
    private float rotationSpeed;

    void Start()
    {
        // Mouvement dans une direction al�atoire
        direction = Random.onUnitSphere;
        speed = Random.Range(0.5f, 2f); // optionnel : vitesse variable

        // Rotation al�atoire
        rotationAxis = Random.onUnitSphere;
        rotationSpeed = Random.Range(30f, 90f); // degr�s par seconde
    }

    void Update()
    {
        // D�placement
        transform.position += direction * speed * Time.deltaTime;

        // Rotation
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
