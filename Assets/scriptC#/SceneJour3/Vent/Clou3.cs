using UnityEngine;

public class Clou3 : MonoBehaviour
{
    public ClouManager ClouManager;
    public AudioSource sonClou;
    public int coupsRestants = 3;
    public float enfoncementParCoup = 0.01f;
    public bool estFini = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("marteau") && coupsRestants > 0)
        {
            coupsRestants--;
            sonClou.Play();
            transform.position -= new Vector3(enfoncementParCoup, 0, 0);

            if (coupsRestants == 0 && !estFini)
            {
                estFini = true;
                ClouManager.CheckClou();
            }
        }
    }
}
