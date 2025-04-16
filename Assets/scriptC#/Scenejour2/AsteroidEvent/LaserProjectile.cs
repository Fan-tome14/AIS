using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float lifetime = 15f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject); // détruire le laser aussi
        }
    }
}
