using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent onPressed;
    public AudioSource buttonSound; // 🎵 Son du bouton

    public void Press()
    {
        // Joue le son s'il est assigné
        if (buttonSound != null)
        {
            buttonSound.Play();
        }
        else
        {
            Debug.LogWarning("🔇 Aucun son assigné au bouton !");
        }

        // Invoque les événements liés
        onPressed.Invoke();
    }
}
