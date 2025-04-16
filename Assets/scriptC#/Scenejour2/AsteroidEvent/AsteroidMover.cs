using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 1f;
    private Vector3 rotationAxis;
    private float rotationSpeed;

    void Start()
    {
        // Mouvement dans une direction aléatoire
        direction = Random.onUnitSphere;
        speed = Random.Range(0.5f, 2f); // optionnel : vitesse variable

        // Rotation aléatoire
        rotationAxis = Random.onUnitSphere;
        rotationSpeed = Random.Range(30f, 90f); // degrès par seconde
    }

    void Update()
    {
        // Déplacement
        transform.position += direction * speed * Time.deltaTime;

        // Rotation
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
