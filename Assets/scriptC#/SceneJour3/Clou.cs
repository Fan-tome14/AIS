using UnityEngine;

public class Clou : MonoBehaviour
{
    public delegate void ClouEnleve();
    public static event ClouEnleve OnClouEnleve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pince"))
        {
            OnClouEnleve?.Invoke(); // prévient que ce clou est enlevé
            Destroy(gameObject); // on enlève le clou
        }
    }
}
