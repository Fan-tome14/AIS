using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand")) // Vérifie si la main touche le bouton
        {
            LoadMainScene();
        }
    }

    public void LoadMainScene()
    {
        Debug.Log("Chargement de la sc�ne main...");
        SceneManager.LoadScene("decolage"); // Charge la scéne "decolage"
    }
}