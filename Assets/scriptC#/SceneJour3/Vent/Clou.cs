using UnityEngine;

public class Clou : MonoBehaviour
{
    public delegate void ClouEnleve();
    public static event ClouEnleve OnClouEnleve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pince"))
        {
            OnClouEnleve?.Invoke(); // previent que le clou a été enelevé
            Destroy(gameObject); // on enléve le clou
        }
    }
}
